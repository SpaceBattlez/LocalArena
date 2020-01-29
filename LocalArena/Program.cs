using CommandLine;
using LocalArena;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;

namespace LocalArena
{
    public class Program
    {
        public static string LocalBattleToDisplay { get; set; }


        static async System.Threading.Tasks.Task Main(string[] args)
        {
            BattleMaster battleMaster = null;
            IGuiDisplay gui = new MinimalGuiDisplay();
            BattleData bData = null;
            Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
                var com = new ServerCommunication();
                if (o.ListBots)
                {
                    var enemies = com.GetEnemiesFromServer().Result;
                    gui.ListEnemyBots(enemies);
                    return;
                }

                var startProcess = new FileInfo(o.StartProcess);
                if (startProcess.Exists)
                {
                    gui.Initialize(o.EnemyBot, o.MapName);
                    var botProcess = new BotProcess(startProcess, o.Arguments);
                    gui.GetTokenFromServer();
                    var gameToken = com.StartBattleOnServer(o.EnemyBot, o.MapName).Result;
                    gui.GotToken(gameToken);
                    battleMaster = new BattleMaster(botProcess, com, gameToken, gui);
                }
                else
                {
                    throw new ArgumentException($"Not possible to locate file: {startProcess.FullName}");
                }

                bData = new BattleData(o.showresults, o.OutputFolder, o.EnemyBot, o.MapName);
            });

            if (battleMaster != null)
            {
                await battleMaster.Start();
                if (string.IsNullOrEmpty(bData.OutputFolder) == false)
                {
                    var filename = $"{DateTime.Now:dd-MM-yyyy HH.mm.ss} User vs {bData.EnemyBot} Rounds {battleMaster.GetHistory().Count}.json";
                    bData.OutputFile = filename;
                    Directory.CreateDirectory(bData.OutputFolder);
                    File.WriteAllText(Path.Combine(bData.OutputFolder, filename), GetJsonBattle(battleMaster));
                    gui.SaveBattle(bData.OutputFolder);
                }
                gui.BattleDone();

                if (bData != null && bData.DisplayBattle)
                {
                    var file = Path.Combine(bData.OutputFolder, bData.OutputFile);
                    if (string.IsNullOrEmpty(file))
                    {
                        file = Path.GetTempFileName();
                        File.WriteAllText(file, GetJsonBattle(battleMaster));
                    }
                    DisplayBattle(new string[] { file });
                }
            }
        }

        private static string GetJsonBattle(BattleMaster battleMaster)
        {
            return $"[{string.Join(",", battleMaster.GetHistory())}]";
        }


        public static void DisplayBattle(string[] args)
        {
            var fileToDisplay = args.FirstOrDefault();
            if (string.IsNullOrEmpty(fileToDisplay) == false && File.Exists(fileToDisplay))
            {
                LocalBattleToDisplay = fileToDisplay;
                CreateHostBuilder(args).Build().Run();
            }
            else
            {
                Console.WriteLine("Error showing local battle");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
