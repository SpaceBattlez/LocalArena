using LocalArena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalArena
{
    public class MinimalGuiDisplay : IGuiDisplay
    {
        public void BattleDone()
        {            
        }

        public void GetTokenFromServer()
        {
        }

        public void GotMessageFromUserBot(string message)
        {
        }

        public void GotNewGameState(string gameState)
        {   
        }

        public void GotToken(TokenDto gameToken)
        {
        }

        public void Initialize(string enemyBot, string mapName)
        {   
            Console.WriteLine($"Starting battle, map: {mapName}");
            Console.WriteLine($"UserBot vs {enemyBot}");
            Console.Write("Round: ");
        }

        public void ListEnemyBots(List<string> enemies)
        {
            throw new NotImplementedException();
        }

        public void NewRound(int round)
        {
            Console.Write($"{round++}, ");
        }

        public void SaveBattle(string outputFile)
        {
        }

        public void SendFleet(string message)
        {
        }

        public void SendGameStateToUserBot()
        {
        }

        public void UserBotReady()
        {
        }

        public void WaitingForUserBot()
        {
        }

        public void WinnerFound(string winner)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine($"Winner: {winner}");
        }
    }
}
