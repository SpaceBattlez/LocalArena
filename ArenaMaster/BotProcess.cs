using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpaceBattlez.Dto;
using SpaceBattlez.GameElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SpaceBattlez
{
	public class BotProcess : IBotProcess
	{
		public bool Ready;
		public string Name { get; set; }
		public int ID { get; set; }
		public Process Application { get; }
		public StreamWriter StandardInput => Application.StandardInput;
		public StreamReader StandardOutput => Application.StandardOutput;

		public BotProcess(FileInfo application, string arguments)
		{
			Application = new Process
			{
				StartInfo =
				{
					FileName = application.FullName,
					UseShellExecute = false,
					Arguments = arguments,
					WorkingDirectory = application.DirectoryName ?? throw new InvalidOperationException("Not possible to set Working Directory"),                    
                    RedirectStandardOutput = true,
					RedirectStandardInput = true,
					RedirectStandardError = true,
				},
				EnableRaisingEvents = true
			};			

			Application.ErrorDataReceived += (sender, args) =>
			{
				Console.WriteLine($"ERROR: {args.Data}");
			};
		}		

		public List<FleetCommandDto> GetFleetResponse(GameStateDto state)
		{
			var output = new List<FleetCommandDto>();

			var str = JsonConvert.SerializeObject(state, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});

			StandardInput.WriteLineAsync(str).Wait();
			var responseTask = StandardOutput.ReadLineAsync();

			if (responseTask.Wait(TimeSpan.FromSeconds(2)))
			{
				var playerFleetString = responseTask.Result;
				output.AddRange(JsonConvert.DeserializeObject<List<FleetCommandDto>>(playerFleetString));
			}
			
			return output;
		}

		public async Task Start()
		{			
			Application.Start();

			var responseTask = await StandardOutput.ReadLineAsync();
			Ready = responseTask.ToLower().Contains("ready");
		}

		public void Kill()
		{
			try
			{
				if (Application.HasExited == false)
				{
					Application.CancelErrorRead();
					Application.EnableRaisingEvents = false;

					//Send close signal to process
					Application.StandardInput.WriteLineAsync("terminate");
					Application.StandardInput.Flush();

					//Kill process
					Application.Kill();
				}
			}
			catch (Exception)
			{

			}
		}
	}
}
