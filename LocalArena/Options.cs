using CommandLine;
using System;
using System.IO;

namespace LocalArena
{   

    public class Options
    {
        [Option('b', "list bots", HelpText = "List all possible enemy bots to battle", SetName = "info")]
        public bool ListBots { get; set; }

        [Option('l', "list maps", HelpText = "List all possible maps to use", SetName = "info")]
        public bool ListMaps { get; set; }

        [Option('e', "enemy", HelpText = "Name of the enemy bot to battle\nUser -l to list all possible enemy bots", Default = "SimpleBot", SetName = "Launch")]
        public string EnemyBot { get; set; }

        [Option('m', "map", HelpText = "Name of map to use.\nExample:\nBattleBotTester.exe -m \"Random\"", Default = "Random", SetName = "Launch")]
        public string MapName { get; set; }

        [Option('p', "start process", Required = true, HelpText = "Start process to start the local bot\nExample:\nBattleBotTester.exe -p \"MyAwesomeBot.exe\"\nBattleBotTester.exe -p \"Node.js\" -a \"c:\\SpaceBattlez\\MyAwesomeBot.js\"", SetName = "Launch")  ]
        public string StartProcess { get; set; }

        [Option('a', "start arguments", HelpText = "Arguments needed for the start process to start the local bot\nExample:\nBattleBotTester.exe -p \"Node.js\" -a \"c:\\SpaceBattlez\\MyAwesomeBot.js\"", SetName = "Launch")]
        public string Arguments { get; set; }

        [Option('o', "output folder", HelpText = "Directory to save all gamestates\nExample:\nBattleBotTester.exe -p \"MyAwesomeBot.exe -o \"c:\\SpaceBattlez\\Battles\\\"", Default = null, SetName = "Launch")]
        public string OutputFolder { get; set; }

        [Option('d', "display battle", HelpText = "Start a viewer to show the battle\nBattleBotTester.exe -p \"MyAwesomeBot.exe -d", Default = true, SetName = "Launch")]
        public bool showresults { get; set; }

        public Options()
        {

        }
    }        
}
