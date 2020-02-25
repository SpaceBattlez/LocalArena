using SpaceBattlez.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBattlez.Maps
{
    public class Random : Map
    {
        private Map map;
        public Random() : base("Random")
        {
            var maps = typeof(Map).Assembly.GetTypes()
                .Where(x => (x.GetInterfaces().Contains(typeof(Map)) || typeof(Map).IsAssignableFrom(x)) && 
                x.GetConstructor(Type.EmptyTypes) != null && 
                x.Name.Equals(nameof(Random)) == false).ToArray();

            var index = Math.Abs(Guid.NewGuid().GetHashCode() % maps.Count());
            map = (Map)Activator.CreateInstance(maps[index]);
        }

        public override Planet[] GetPlanets()
        {
            return map.GetPlanets();
        }
    }
}
