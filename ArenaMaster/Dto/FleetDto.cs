using SpaceBattlez.GameElements;

namespace SpaceBattlez.Dto
{
	public class FleetDto
	{
		public int ID { get;}
		public int OwnerID { get; }
		public int NumberOfShips { get; }
		public int TicksToDestination { get; }
		public int DestinationPlanetID { get; }
		public int SourcePlanetID { get; }
	    public Vector Position { get; }

	    public FleetDto(int id, int ownerId, int numberOfShips, int ticksToDestination, int destinationPlanetId, int sourcePlanetId, Vector position)
		{
			ID = id;
			OwnerID = ownerId;
			NumberOfShips = numberOfShips;
			TicksToDestination = ticksToDestination;
			DestinationPlanetID = destinationPlanetId;
			SourcePlanetID = sourcePlanetId;
		    Position = position;
		}
	}
}