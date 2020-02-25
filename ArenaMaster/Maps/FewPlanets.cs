using SpaceBattlez.GameElements;

namespace SpaceBattlez.Maps
{
	public class FewPlanets : Map
    {
		public FewPlanets() : base("Map5",
		@"[
			{
				'id': 0,
				'ownerID': 2,
				'position': {
					'x': 375,
					'y': 198
				},
				'numberOfShips': 98,
				'growthRate': 2
			},
			{
				'id': 1,
				'ownerID': 1,
				'position': {
					'x': 125,
					'y': 302
				},
				'numberOfShips': 98,
				'growthRate': 2
			},
			{
				'id': 2,
				'ownerID': 0,
				'position': {
					'x': 326,
					'y': 165
				},
				'numberOfShips': 6,
				'growthRate': 4
			},
			{
				'id': 3,
				'ownerID': 0,
				'position': {
					'x': 174,
					'y': 335
				},
				'numberOfShips': 6,
				'growthRate': 4
			},
			{
				'id': 4,
				'ownerID': 0,
				'position': {
					'x': 473,
					'y': 158
				},
				'numberOfShips': 45,
				'growthRate': 4
			},
			{
				'id': 5,
				'ownerID': 0,
				'position': {
					'x': 27,
					'y': 342
				},
				'numberOfShips': 45,
				'growthRate': 4
			}
		]".Replace('\'', '"'))
		{
        }
    }
}
