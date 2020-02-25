using SpaceBattlez.GameElements;

namespace SpaceBattlez.Maps
{
	public class Map1 : Map
    {
		public Map1() : base("Map1",
		@"[
			{
				'id': 0,
				'ownerID': 2,
				'position': {
					'x': 390,
					'y': 437
				},
				'numberOfShips': 59,
				'growthRate': 2
			},
			{
				'id': 1,
				'ownerID': 1,
				'position': {
					'x': 110,
					'y': 63
				},
				'numberOfShips': 59,
				'growthRate': 2
			},
			{
				'id': 2,
				'ownerID': 0,
				'position': {
					'x': 466,
					'y': 71
				},
				'numberOfShips': 95,
				'growthRate': 2
			},
			{
				'id': 3,
				'ownerID': 0,
				'position': {
					'x': 34,
					'y': 429
				},
				'numberOfShips': 95,
				'growthRate': 2
			},
			{
				'id': 4,
				'ownerID': 0,
				'position': {
					'x': 411,
					'y': 82
				},
				'numberOfShips': 88,
				'growthRate': 4
			},
			{
				'id': 5,
				'ownerID': 0,
				'position': {
					'x': 89,
					'y': 418
				},
				'numberOfShips': 88,
				'growthRate': 4
			},
			{
				'id': 6,
				'ownerID': 0,
				'position': {
					'x': 121,
					'y': 285
				},
				'numberOfShips': 6,
				'growthRate': 3
			},
			{
				'id': 7,
				'ownerID': 0,
				'position': {
					'x': 379,
					'y': 215
				},
				'numberOfShips': 6,
				'growthRate': 3
			}
		]".Replace('\'', '"'))
		{
        }
    }
}
