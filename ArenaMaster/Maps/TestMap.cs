using SpaceBattlez.GameElements;

namespace SpaceBattlez.Maps
{
	public class TestMap : Map
    {
        public TestMap() : base("TestMap",
		@"[
			{
				'id': 0,
				'ownerID': 1,
				'position': {
					'x': 229,
					'y': 43
				},
				'numberOfShips': 11,
				'growthRate': 3
			},
			{
				'id': 2,
				'ownerID': 0,
				'position': {
					'x': 404,
					'y': 408
				},
				'numberOfShips': 41,
				'growthRate': 3
			},
			{
				'id': 4,
				'ownerID': 0,
				'position': {
					'x': 83,
					'y': 281
				},
				'numberOfShips': 53,
				'growthRate': 1
			},
			{
				'id': 6,
				'ownerID': 0,
				'position': {
					'x': 186,
					'y': 270
				},
				'numberOfShips': 7,
				'growthRate': 4
			},
			{
				'id': 8,
				'ownerID': 0,
				'position': {
					'x': 245,
					'y': 216
				},
				'numberOfShips': 52,
				'growthRate': 1
			},
			{
				'id': 1,
				'ownerID': 2,
				'position': {
					'x': 271,
					'y': 457
				},
				'numberOfShips': 11,
				'growthRate': 3
			},
			{
				'id': 3,
				'ownerID': 0,
				'position': {
					'x': 96,
					'y': 92
				},
				'numberOfShips': 41,
				'growthRate': 3
			},
			{
				'id': 5,
				'ownerID': 0,
				'position': {
					'x': 417,
					'y': 219
				},
				'numberOfShips': 53,
				'growthRate': 1
			},
			{
				'id': 7,
				'ownerID': 0,
				'position': {
					'x': 314,
					'y': 230
				},
				'numberOfShips': 7,
				'growthRate': 4
			},
			{
				'id': 9,
				'ownerID': 0,
				'position': {
					'x': 255,
					'y': 284
				},
				'numberOfShips': 52,
				'growthRate': 1
			}
		]".Replace('\'','"'))
        {
        }
    }
}
