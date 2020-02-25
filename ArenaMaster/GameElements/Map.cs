using Newtonsoft.Json;
using System.Linq;

namespace SpaceBattlez.GameElements
{
	public class Map
	{
		private Planet[] planets;
		public string Name { get; }

		public Map(string name)
		{
			Name = name;
		}

		public Map(string name, string jsonPlanets)
		{	
			Name = name;
			planets = JsonConvert.DeserializeObject<Planet[]>(jsonPlanets);
		}

		public virtual Planet[] GetPlanets()
		{
			return planets.Select(p => new Planet(p) { OwnerID = p.OwnerID > 0 ? p.OwnerID + 1 : p.OwnerID }).ToArray();
		}
	}
}
