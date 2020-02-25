namespace SpaceBattlez.Dto
{
	public class RatingDto
	{
		public int BotId { get; set; }
		public int Rating { get; set; }

		public RatingDto(int botId, int rating)
		{
			BotId = botId;
			Rating = rating;
		}
	}
}