using SpaceBattlez.Dto;
using SpaceBattlez.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceBattlez.Bots
{
	public class Score : IBot
	{
		const int me = 1;

		public List<FleetCommandDto> GameUpdate(GameStateDto state)
		{			
			var output = new List<FleetCommandDto>();

			foreach (var myPlanet in state.Planets.Where(x => x.OwnerID == me))
			{
				var enemies = state.Planets
					.Where(x => x.OwnerID != me)
					.Select(x => (Planet: x, Score: GetFleetNeeded(myPlanet, x, state)))
					.Where(x => x.Score >= 0)
					.OrderBy(x => x.Score);

				if (enemies.Any())
				{
					var enemy = enemies.First();
					var fleetNeeded = enemy.Score + 1;

					output.Add(new FleetCommandDto(myPlanet.ID, enemy.Planet.ID, Math.Min(fleetNeeded, myPlanet.NumberOfShips - 1)));
				}
			}

			return output;
		}

		private int GetFleetNeeded(PlanetDto myPlanet, PlanetDto enemy, GameStateDto state)
		{
			var output =	enemy.NumberOfShips +
							GetIncomingEnemies(enemy, state) -
							GetIncomingSupport(enemy, state);

			if(enemy.OwnerID != 0)
			{
				output += TravelTime(myPlanet.Position, enemy.Position) * enemy.GrowthRate;
			}

			return output;
		}

		private int GetIncomingSupport(PlanetDto planet, GameStateDto state)
		{
			return state.Fleets.Where(x => x.OwnerID == me && x.DestinationPlanetID == planet.ID).Sum(x => x.NumberOfShips);
		}

		private int GetIncomingEnemies(PlanetDto planet, GameStateDto state)
		{
			return state.Fleets.Where(x => x.OwnerID != me && x.DestinationPlanetID == planet.ID).Sum(x => x.NumberOfShips);
		}

		private int TravelTime(Vector p1, Vector p2)
		{
			return (int)Math.Ceiling(Distance(p1, p2) / 20.0);
		}

		private double Distance(Vector p1, Vector p2)
		{
			return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
		}
	}
}