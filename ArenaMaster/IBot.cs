using SpaceBattlez.Dto;
using System.Collections.Generic;

namespace SpaceBattlez
{
	public interface IBot
	{
		List<FleetCommandDto> GameUpdate(GameStateDto state);
	}
}