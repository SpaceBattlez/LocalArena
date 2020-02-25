using SpaceBattlez.GameElements;

namespace SpaceBattlez.Maps
{
	public class TwoFronts : Map
    {
		public TwoFronts() : base("TwoFronts",
		@"[
			{
				'id': 0,
				'ownerID': 2,
				'position': {
					'x': 82,
					'y': 298
				},
				'numberOfShips': 89,
				'growthRate': 4
			},
			{
				'id': 1,
				'ownerID': 1,
				'position': {
					'x': 418,
					'y': 202
				},
				'numberOfShips': 89,
				'growthRate': 4
			},
			{
				'id': 2,
				'ownerID': 2,
				'position': {
					'x': 62,
					'y': 227
				},
				'numberOfShips': 53,
				'growthRate': 1
			},
			{
				'id': 3,
				'ownerID': 1,
				'position': {
					'x': 438,
					'y': 273
				},
				'numberOfShips': 53,
				'growthRate': 1
			},
			{
				'id': 4,
				'ownerID': 2,
				'position': {
					'x': 78,
					'y': 189
				},
				'numberOfShips': 79,
				'growthRate': 1
			},
			{
				'id': 5,
				'ownerID': 1,
				'position': {
					'x': 422,
					'y': 311
				},
				'numberOfShips': 79,
				'growthRate': 1
			},
			{
				'id': 6,
				'ownerID': 0,
				'position': {
					'x': 379,
					'y': 353
				},
				'numberOfShips': 22,
				'growthRate': 1
			},
			{
				'id': 7,
				'ownerID': 0,
				'position': {
					'x': 121,
					'y': 147
				},
				'numberOfShips': 22,
				'growthRate': 1
			},
			{
				'id': 8,
				'ownerID': 0,
				'position': {
					'x': 340,
					'y': 163
				},
				'numberOfShips': 3,
				'growthRate': 2
			},
			{
				'id': 9,
				'ownerID': 0,
				'position': {
					'x': 160,
					'y': 337
				},
				'numberOfShips': 3,
				'growthRate': 2
			}
		]".Replace('\'', '"'))
		{
        }
    }
}
