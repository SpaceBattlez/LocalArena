using SpaceBattlez.Dto;
using SpaceBattlez.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceBattlez
{
    public class ArenaMaster
    {
        private GameState gameState;
        private BotProcess player;
        public ArenaMaster(BotProcess player, EnemyBot enemy, Map map)
        {
            this.player = player;
            player.ID = 2;
            enemy.ID = 3;

            gameState = new GameState()
            {
                Bots = new List<IBotProcess> 
                { 
                    player, 
                    enemy
                },
                Planets = map.GetPlanets()
            };
        }

        public List<GameStateDto> GetBattleResults()
        {
            var output = new List<GameStateDto>();

            Task.WaitAll(player.Start());

            var waitForPlayer = Task.Run(async () =>
            {
                while (true)
                {
                    if (player.Ready)
                        break;
                    await Task.Delay(100);
                }
            });

            if(waitForPlayer.Wait(TimeSpan.FromSeconds(10)) == false)
            {
                throw new Exception("Player bot not ready within 10 seconds");
            }

            for (int rounds = 0; rounds < 300; rounds++)
            {
                output.Add(new GameStateDto(gameState));

                foreach (var bot in gameState.Bots)
                {
                    var state = new GameStateDto(gameState, bot.ID);
                    var fleets = bot.GetFleetResponse(state);

                    foreach (var fleet in fleets)
                    {
                        gameState.SendFleet(bot.ID, fleet.SourcePlanetID, fleet.DestinationPlanetID, fleet.NumberOfUnits);
                    }                    
                }                

                var winner = gameState.GetWinnerId(300);

                if (winner.HasValue)
                {
                    Console.WriteLine($"Winner: {gameState.Bots.First(x => x.ID == winner).Name}");
                    break;
                }
                gameState.Tick();
            }

            if(gameState.Disqualified != null)
            {
                Console.WriteLine(gameState.Disqualified);
            }

            player.Kill();
            return output;
        }
    }
}
