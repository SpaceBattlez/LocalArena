using SpaceBattlez.GameElements;

namespace SpaceBattlez.Dto
{
	public class PlanetDto
	{
		public int ID { get; }
		public int OwnerID { get; }
		public Vector Position { get; }
		public int NumberOfShips { get; set; }
	    public int GrowthRate { get; }

		public PlanetDto(int id, int ownerId, Vector position, int numberOfShips, int growthRate)
		{
			ID = id;
			OwnerID = ownerId;
			Position = position;
			NumberOfShips = numberOfShips;
		    GrowthRate = growthRate;
		}
	}
}