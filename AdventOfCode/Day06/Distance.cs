using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode.Day06
{
    public class Distance
    {
        private readonly List<(string Name, string Parent)> _spaceObjects = new List<(string Name, string Parent)>();
        private readonly List<(string, string)> _visited = new List<(string, string)>();

        private readonly ITestOutputHelper _console;

        public Distance(ITestOutputHelper console)
        {
            _console = console;
        }
        
        public (int Distance, bool Found) Run(List<string> map)
        {
            ExtractSpaceObjectsFrom(map);

            return SearchForSantaFrom(LookUp("YOU"), -1);
        }
        
        private void ExtractSpaceObjectsFrom(List<string> map)
        {
            foreach (var pair in map)
            {
                var parts = pair.Split(')');
                _spaceObjects.Add((parts[1], parts[0]));
            }
        }
        
        private (string Name, string Parent) LookUp(string name)
        {
            return _spaceObjects.FirstOrDefault(x => x.Name == name);
        }

        private (int Distance, bool Found) SearchForSantaFrom((string Name, string Parent) searchPoint, int distance)
        {
            _console.WriteLine($"search point {searchPoint.Name} distance {distance}");
            
            // skip if already visited this object
            if (_visited.Contains(searchPoint))
            {
                return (--distance, Found: false);
            }

            // record visit in history
            _visited.Add(searchPoint);

            if (searchPoint.Name == "SAN")
            {
                return (--distance, Found: true);
            }

            // search down each child object
            foreach (var child in GetChildren(searchPoint))
            {
                var result = SearchForSantaFrom(child, distance + 1);

                if (result.Found)
                {
                    return result;
                }
            }

            // search from the parent object
            var parent = LookUp(searchPoint.Parent);
            
            return SearchForSantaFrom(parent, distance + 1);
        }

        private IEnumerable<(string Name, string Parent)> GetChildren((string Name, string Parent) spaceObject)
        {
            return _spaceObjects.Where(x => x.Parent == spaceObject.Name);
        }
    }
}