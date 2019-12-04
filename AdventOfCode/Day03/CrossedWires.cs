using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day03
{
    public static class CrossedWires 
    {
        private static readonly Dictionary<char, (int, int)> PositionModifiers = new Dictionary<char, (int, int)>
        {
            { 'U', ( 0,  1) },
            { 'D', ( 0, -1) },
            { 'R', ( 1,  0) },
            { 'L', (-1,  0) },
        };

        public static int Run(List<string> wireOne, List<string> wireTwo)
        {   
            var wireOnePositions = new List<(int, int)>();

            ForEachPositionOn(wireOne, (x, y, modifier) =>
            {
                wireOnePositions.Add((x, y));
            });

            var distance = 0;
            
            var crossingDistances = new List<int>();
            
            ForEachPositionOn(wireTwo, (x, y, modifier) =>
            {
                distance += (modifier.Item1 + modifier.Item2);
                        
                if (WiresAreCrossed(wireOnePositions, x, y))
                {
                    crossingDistances.Add(distance);
                }
            });
            
            return Closest(crossingDistances);
        }
        private static void ForEachPositionOn(List<string> wire, Action<int, int, (int, int)> action)
        {
            var x = 0;
            var y = 0;

            foreach (string path in wire)
            {
                for (var i = 0; i < path.Distance(); i++)
                {
                    var modifiers = PositionModifiers[path.Direction()];
                        
                    x += modifiers.Item1;
                    y += modifiers.Item2;

                    action(x, y, modifiers);
                }
            }
        }
        
        private static bool WiresAreCrossed(List<(int, int)> wireOnePositions, int x, int y)
        {
            return wireOnePositions.Contains((x, y));
        }
        
        private static int Closest(List<int> crossingDistances)
        {
            return Math.Abs(crossingDistances.Min());
        }
    }
    
    internal static class ExtensionMethods
    {
        public static int Distance(this string path)
        {
            return Convert.ToInt32(path.Remove(0, 1));
        }
        
        public static char Direction(this string path)
        {
            return path[0];
        }
    }
}