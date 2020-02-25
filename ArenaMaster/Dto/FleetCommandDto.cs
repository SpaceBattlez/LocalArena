namespace SpaceBattlez.Dto
{
	public class FleetCommandDto
	{
		public int SourcePlanetID { get; set; }
		public int DestinationPlanetID { get; set; }
		public int NumberOfUnits { get; set; }

		public FleetCommandDto(int sourcePlanetID, int destinationPlanetID, int numberOfUnits)
		{
			SourcePlanetID = sourcePlanetID;
			DestinationPlanetID = destinationPlanetID;
			NumberOfUnits = numberOfUnits;
		}
	}
}