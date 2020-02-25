using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpaceBattlez;
using SpaceBattlez.Dto;
using SpaceBattlez.GameElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LocalArena
{
    public class Program
    {
        public static string LocalBattleToDisplay { get; set; }

        static void Main(string[] args)
        {            
            Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
                if (o.ListBots)
                {
                    var bots = GetInstances<IBot>();
                    foreach (var bot in bots)
                    {
                        Console.WriteLine(bot.ToString().Split('.').Last());
                    }
                    return;
                }                

                if (o.ListMaps)
                {
                    var maps = GetInstances<Map>();                    
                    foreach (var map in maps)
                    {
                        Console.WriteLine(map.Name);
                    }
                    return;
                }

                var startProcess = new FileInfo(o.StartProcess);
                if (startProcess.Exists)
                {
                    var botProcess = new BotProcess(startProcess, o.Arguments) 
                    { 
                        Name = "UserBot" 
                    };
                    var enemyBot = GetEnemy(o.EnemyBot);
                    var map = GetMap(o.MapName);

                    var arenaMaster = new ArenaMaster(botProcess, enemyBot, map);
                    Console.WriteLine("Starting Battle");
                    try
                    {
                        var battleResult = arenaMaster.GetBattleResults();
                        var file = SaveBattleToDisk(battleResult, o.OutputFolder, o.EnemyBot);

                        if (o.showresults)
                        {
                            DisplayBattle(new string[] { file });
                        }
                    }
                    catch(Exception err)
                    {
                        Console.WriteLine(err);
                    }
                }
                else
                {
                    throw new ArgumentException($"Not possible to locate file: {startProcess.FullName}");
                }                
            });
        }

        private static EnemyBot GetEnemy(string enemyBot)
        {
            var bot = GetInstances<IBot>(enemyBot);

            return new EnemyBot()
            {
                Bot = bot.FirstOrDefault(),
                Name = enemyBot
            };
        }
        
        private static List<T> GetInstances<T>(string name = null)
        {
            return (from t in typeof(T).Assembly.GetTypes()
                    where (t.GetInterfaces().Contains(typeof(T)) || typeof(T).IsAssignableFrom(t)) && t.GetConstructor(Type.EmptyTypes) != null && (name == null ||  t.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    select (T)Activator.CreateInstance(t)).ToList();
        }

        private static Map GetMap(string mapName)
        {
            var map = GetInstances<Map>(mapName);
            return map.FirstOrDefault();
        }

        private static string SaveBattleToDisk(List<GameStateDto> battleResult, string outputFolder, string enemyName)
        {
            var filename = $"{DateTime.Now:dd-MM-yyyy HH.mm.ss} User vs {enemyName} Rounds {battleResult.Count}.json";
            string folder = Path.GetTempPath();

            if (string.IsNullOrEmpty(outputFolder) == false)
            {
                folder = outputFolder;
            }

            Directory.CreateDirectory(folder);
            var file = Path.Combine(folder, filename);
            File.WriteAllText(file, JsonConvert.SerializeObject(battleResult, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
            return file;
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
