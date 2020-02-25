using SpaceBattlez.Dto;
using System;
using System.Collections.Generic;

namespace SpaceBattlez.GameElements
{
	public interface IBotProcess
	{		
		public string Name { get; set; }
		public int ID { get; set; }

		public List<FleetCommandDto> GetFleetResponse(GameStateDto state);
	}
}