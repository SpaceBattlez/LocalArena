using System;
using System.Collections.Generic;

namespace SpaceBattlez.Dto
{
	public class BattleResultDto
	{
		public int? Winner { get; }
		public List<GameStateDto> Rounds { get; }
		public string Message { get; }
		public string MapName { get; }
	    public DateTime Date { get; }

	    public BattleResultDto(List<GameStateDto> rounds, string message, int? winner, string mapName)
		{
			Winner = winner;
			Rounds = rounds;
			Message = message;
			MapName = mapName;
		    Date = DateTime.UtcNow;
		}
	}
}