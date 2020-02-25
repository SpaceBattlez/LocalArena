using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceBattlez.GameElements
{
    public class GameState
    {
        public const int PixelsPerTick = 20;
        
		public Disqualified Disqualified { get; set; }
		public List<IBotProcess> Bots = new List<IBotProcess>();
        public Planet[] Planets;
        public List<Fleet> Fleets = new List<Fleet>();
        private List<FleetCommand> FleetCommands = new List<FleetCommand>();
        private int _tickCount;
		private int _fleetId;

		public void SendFleet(int playerId, Planet from, Planet to, int numberOfFleet)
        {
            FleetCommands.Add(new FleetCommand { PlayerId = playerId, SourcePlanetID = from.ID, DestinationPlanetID = to.ID, NumberOfUnits = numberOfFleet });
        }

        public void SendFleet(int playerId, int SourcePlanetID, int DestinationPlanetID, int numberOfFleet)
        {
            FleetCommands.Add(new FleetCommand { PlayerId = playerId, SourcePlanetID = SourcePlanetID, DestinationPlanetID = DestinationPlanetID, NumberOfUnits = numberOfFleet });
        }

		public void Tick()
        {
	        _tickCount += 1;

            foreach (var planet in Planets)
            {
                if (planet.OwnerID != 0)
                {
                    planet.NumberOfShips += planet.GrowthRate;
                }
            }

            HandleOutgoingFleets();
	        HandleFlyingFleets();
	        HandleIncomingFleets();
            

	        FleetCommands.Clear();
		}

	    private void HandleOutgoingFleets()
	    {
	        foreach (var fleetCommand in FleetCommands)
	        {
			    var from = Planets.FirstOrDefault(p => p.ID == fleetCommand.SourcePlanetID);

	            if (from == null)
	            {
	                var bot = Bots.First(b => b.ID == fleetCommand.PlayerId);
					Disqualified = new Disqualified(bot, $"Tried to send units from a non-existent planet: {fleetCommand.SourcePlanetID}");
	                return;
	            }

	            if (from.OwnerID != fleetCommand.PlayerId)
	            {
	                var bot = Bots.First(b => b.ID == fleetCommand.PlayerId);
		            var owner = from.OwnerID == 0 ? "neutral" : "enemy";
					Disqualified = new Disqualified(bot, $"Tried to send units from a planet not owned: {fleetCommand.SourcePlanetID}, owner was {owner}");
	                return;
                }
            }

            var mergedFleetCommands = MergeFleetCommands(FleetCommands);

		    foreach (var fleetCommand in mergedFleetCommands)
		    {
		        if (fleetCommand.NumberOfUnits <= 0)
		        {
		            continue;
		        }

			    var from = Planets.First(p => p.ID == fleetCommand.SourcePlanetID);
			    var to = Planets.First(p => p.ID == fleetCommand.DestinationPlanetID);

				if (from.NumberOfShips > fleetCommand.NumberOfUnits)
			    {
				    Fleets.Add(new Fleet
				    {
					    DestinationPlanet = to,
					    ID = _fleetId++,
					    NumberOfShips = fleetCommand.NumberOfUnits,
					    OwnerID = from.OwnerID,
					    SourcePlanet = from,
					    Position = from.Position,
					    TicksToDestination = (int)Math.Ceiling(from.Position.Distance(to.Position) / (double)PixelsPerTick)
				    });

				    from.NumberOfShips -= fleetCommand.NumberOfUnits;
			    }
				else
				{
				    var bot = Bots.First(b => b.ID == fleetCommand.PlayerId);
					Disqualified = new Disqualified(bot, $"Tried to send too many units: {fleetCommand.NumberOfUnits} (had only {from.NumberOfShips}) from planet: {fleetCommand.SourcePlanetID}");
                }
			}
	    }

	    private List<FleetCommand> MergeFleetCommands(List<FleetCommand> fleetCommands)
	    {
			return (	
				from f in fleetCommands
				group f by new { f.SourcePlanetID, f.DestinationPlanetID, f.PlayerId }
				into grp
				select new FleetCommand
				{
					PlayerId = grp.Key.PlayerId, 
					DestinationPlanetID = grp.Key.DestinationPlanetID, 
					SourcePlanetID = grp.Key.SourcePlanetID, 
					NumberOfUnits = grp.Sum(t => t.NumberOfUnits)
				}).ToList();
		}


	    private void HandleFlyingFleets()
	    {
		    foreach (var fleet in Fleets)
		    {
			    fleet.TicksToDestination--;

			    if (fleet.TicksToDestination > 0)
			    {
				    fleet.Position = GetPosition(fleet);
			    }
		    }
	    }

		private void HandleIncomingFleets()
	    {
		    var incomingFleets = Fleets.Where(x => x.TicksToDestination <= 0).ToList();
		    var targetPlanets = incomingFleets.GroupBy(x => x.DestinationPlanet);

		    foreach (var target in targetPlanets)
		    {
			    var planet = target.Key;

			    var attacks = (	from bot in Bots
							    let units = target.Where(x => x.OwnerID == bot.ID).Sum(f => f.NumberOfShips)
							    orderby units descending
							    select (Bot: bot, NumberOfUnits: units)).ToList();

			    if (attacks.Count == 1)
			    {
				    AttackPlanet(planet, attacks.First());
			    }
			    else
			    {
				    var winner = attacks.First();
				    var second = attacks.Skip(1).First();

				    AttackPlanet(planet, (winner.Bot, winner.NumberOfUnits - second.NumberOfUnits));
			    }
		    }

		    Fleets.RemoveAll(x => x.TicksToDestination <= 0);
	    }

	    private void AttackPlanet(Planet planet, (IBotProcess Bot, int NumberOfUnits) attacker)
	    {
		    if (planet.OwnerID == attacker.Bot.ID)
		    {
			    planet.NumberOfShips += attacker.NumberOfUnits;
		    }
		    else
		    {
			    planet.NumberOfShips -= attacker.NumberOfUnits;
		    }

		    if (planet.NumberOfShips < 0)
		    {
			    planet.OwnerID = attacker.Bot.ID;
			    planet.NumberOfShips = Math.Abs(planet.NumberOfShips);
		    }
	    }

		private Vector GetPosition(Fleet fleet)
        {
            var fromPlanet = fleet.SourcePlanet;
            var toPlanet = fleet.DestinationPlanet;

            var totalTicks = (int)Math.Ceiling(fromPlanet.Position.Distance(toPlanet.Position) / (double)PixelsPerTick);

            var proc = 1 - (1.0 / totalTicks) * fleet.TicksToDestination;

            var vec = new Vector((int)(fromPlanet.Position.X + (toPlanet.Position.X - fromPlanet.Position.X) * proc),
                              (int)(fromPlanet.Position.Y + (toPlanet.Position.Y - fromPlanet.Position.Y) * proc));
            return vec;
        }

        public int? GetWinnerId(int gameLength)
        {
            if (_tickCount >= gameLength)
            {
                var botScores = (from bot in Bots
                    let units = Planets.Where(p => p.OwnerID == bot.ID).Sum(p => p.NumberOfShips) +
                                Fleets.Where(f => f.OwnerID == bot.ID).Sum(f => f.NumberOfShips)
                    orderby units descending
                    select new { bot.ID, units }).ToArray();

                if (botScores.All(b => b.units == botScores.First().units))
                {
                    return 0;
                }

                return botScores.First().ID;
            }

            var ids = new List<int>();
            ids.AddRange(Planets.Where(x => x.OwnerID != 0).Select(x => x.OwnerID));
            ids.AddRange(Fleets.Where(x => x.OwnerID != 0).Select(x => x.OwnerID));

			var bots = ids.Distinct().Where(x => (Disqualified != null && Disqualified.Bot.ID == x) == false).ToList();

            if (bots.Count == 1)
            {
                return bots.First();
            }

            return null;
        }
    }

    public class FleetCommand
    {
	    public int SourcePlanetID { get; set; }
        public int DestinationPlanetID { get; set; }
        public int NumberOfUnits { get; set; }
        public int PlayerId { get; set; }
    }

	public class Disqualified
	{
		public IBotProcess Bot { get; set; }
		public string Reason { get; set; }

		public Disqualified(IBotProcess bot, string reason)
		{
			Bot = bot;
			Reason = reason;
		}

		public override string ToString()
		{
			return $"{Bot.Name} Disqualified: {Reason}";
		}
	}
}