using System.Drawing;
using Newtonsoft.Json;

namespace SpaceBattlez.GameElements
{
	public class Fleet
	{
		public int ID;
		public int OwnerID;
		public int NumberOfShips;

		public Vector Position;

		public int TicksToDestination;

		public int DestinationPlanetID => DestinationPlanet.ID;
		public int SourcePlanetID => SourcePlanet.ID;

		[JsonIgnore]
		public Planet SourcePlanet;

		[JsonIgnore]
		public Planet DestinationPlanet;

		public Fleet()
		{

		}

		public Fleet(Fleet fleet)
		{
			ID = fleet.ID;
			OwnerID = fleet.OwnerID;
			NumberOfShips = fleet.NumberOfShips;
			Position = fleet.Position;
			TicksToDestination = fleet.TicksToDestination;
			SourcePlanet = fleet.SourcePlanet;
			DestinationPlanet = fleet.DestinationPlanet;
		}
	}
}