namespace SpaceBattlez.GameElements
{
	public class Planet
	{
		public int ID;
		public int OwnerID;
		public Vector Position;
		public int NumberOfShips;
	
	    public int GrowthRate;

		public Planet()
		{

		}

		public Planet(Planet planet)
		{
			ID = planet.ID;
			OwnerID = planet.OwnerID;
			Position = planet.Position;
			NumberOfShips = planet.NumberOfShips;
			GrowthRate = planet.GrowthRate;
		}
	}
}