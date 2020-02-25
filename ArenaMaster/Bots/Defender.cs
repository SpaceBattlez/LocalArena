using SpaceBattlez.Dto;
using SpaceBattlez.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceBattlez.Bots
{
	public class Defender : IBot
	{
		public List<FleetCommandDto> GameUpdate(GameStateDto state)
		{
			const int me = 1;
			var output = new List<FleetCommandDto>();

			foreach (var myPlanet in state.Planets.Where(x => x.OwnerID == me && x.NumberOfShips > (x.GrowthRate * 10)))
			{
				var spareFleet = (myPlanet.NumberOfShips - 1) - (myPlanet.GrowthRate * 10);
				var neutral = state.Planets.Where(x => x.OwnerID == 0).OrderBy(x => Distance(myPlanet.Position, x.Position)).FirstOrDefault();

				if (neutral != null)
				{
					output.Add(new FleetCommandDto(myPlanet.ID, neutral.ID, spareFleet));
				}
			}

			return output;
		}

		private double Distance(Vector p1, Vector p2)
		{
			return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
		}
	}
}