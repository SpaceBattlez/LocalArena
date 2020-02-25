using SpaceBattlez.Dto;
using SpaceBattlez.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceBattlez.Bots
{
	public class Kamikaze : IBot
	{
		public List<FleetCommandDto> GameUpdate(GameStateDto state)
		{
			const int me = 1;
			var output = new List<FleetCommandDto>();

			foreach (var myPlanet in state.Planets.Where(x => x.OwnerID == me))
			{
				var enemy = state.Planets.Where(x => x.OwnerID > 0 && x.OwnerID != me).OrderBy(x => Distance(myPlanet.Position, x.Position)).FirstOrDefault();

				if (enemy != null)
				{
					output.Add(new FleetCommandDto(myPlanet.ID, enemy.ID, myPlanet.NumberOfShips - 1));
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