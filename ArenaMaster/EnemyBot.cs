﻿using SpaceBattlez.Dto;
using SpaceBattlez.GameElements;
using System.Collections.Generic;

namespace SpaceBattlez
{
    public class EnemyBot : IBotProcess
    {
        public string Name { get; set; }
        public IBot Bot { get; set; }
        public int ID { get; set; }
        public bool IsDisqualified { get ; set; }
        public bool Ready => true;
        
        public List<FleetCommandDto> GetFleetResponse(GameStateDto state)
        {
            return Bot.GameUpdate(state);
        }
        
        public void Kill()
        {            
        }

        public Task Start()
        {
            return Task.CompletedTask;
        }
    }
}
