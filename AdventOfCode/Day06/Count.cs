using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode.Day06
{
    public class Count
    {
        private readonly List<(string Name, string Parent)> _spaceObjects = new List<(string Name, string Parent)>();

        private readonly ITestOutputHelper _console;

        public Count(ITestOutputHelper console)
        {
            _console = console;
        }
        
        public int Run(List<string> map)
        {
            ExtractSpaceObjectsFrom(map);

            return _spaceObjects.Sum(NumberOfParents);
        }

        private void ExtractSpaceObjectsFrom(List<string> map)
        {
            foreach (var pair in map)
            {
                var parts = pair.Split(')');
                _spaceObjects.Add((parts[1], parts[0]));
            }
        }

        private int NumberOfParents((string Name, string Parent) spaceObject)
        {
            _console.WriteLine($"Starting at {spaceObject.Name}");
            
            int count = 0;
            
            while (!spaceObject.Equals(default))
            {
                count++;
                spaceObject = LookUp(spaceObject.Parent);

                var parentName = (spaceObject.Equals(default)) ? "COM" : spaceObject.Name;
                _console.WriteLine($"adding one for {parentName}");
            }

            return count;
        }
        
        private (string Name, string Parent) LookUp(string name)
        {
            return _spaceObjects.FirstOrDefault(x => x.Name == name);
        }
    }
}