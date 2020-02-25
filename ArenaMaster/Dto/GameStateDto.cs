using System.Collections.Generic;
using System.Linq;
using SpaceBattlez.GameElements;

namespace SpaceBattlez.Dto
{
	public class GameStateDto
	{
		public List<BotDto> Bots;
		public List<PlanetDto> Planets;
		public List<FleetDto> Fleets;

	    public GameStateDto()
	    {
	        
	    }

		public GameStateDto(GameState state, int mainId = -1)
		{
			Bots = state.Bots.Select(x => new BotDto(x.ID == mainId ? 1 : x.ID, x.Name)).ToList();
			Planets = state.Planets.Select(x => new PlanetDto(x.ID, x.OwnerID == mainId ? 1 : x.OwnerID, x.Position, x.NumberOfShips, x.GrowthRate)).OrderBy(x => x.ID).ToList();
			Fleets = state.Fleets.Select(x => new FleetDto(x.ID, x.OwnerID == mainId ? 1 : x.OwnerID, x.NumberOfShips, x.TicksToDestination, x.DestinationPlanetID, x.SourcePlanetID, x.Position)).ToList();
		}
    }
}