using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace AdventOfCode.Day06
{
    public class Tests
    {
        // (x) one direct orbit
        // (x) multiple direct orbits
        // (x) one indirect orbit
        // ( ) direct and indirect orbits
        
        [Fact]
        public void OneDirectOrbit()
        {
            var map = new List<string> {"COM)A"};
            
            var result = Count(map);
            
            result.ShouldBe(1);
        }

        [Fact]
        public void OneIndirectOrbits()
        {
            var map = new List<string>
            {
                "COM)A", 
                "A)B"
            };
            
            //    
            // COM - A - B
            //
            
            var result = Count(map);
            
            result.ShouldBe(3);
        }

        [Fact]
        public void MultipleDirectOrbits()
        {
            var map = new List<string>
            {
                "COM)A", 
                "COM)B"
            };
            
            //     A
            //    /
            // COM
            //    \
            //     B
            
            var result = Count(map);
            
            result.ShouldBe(2);
        }
        
        [Fact]
        public void DirectAndIndirectOrbits()
        {
            var map = new List<string>
            {
                "COM)A", 
                "A)B",
                "COM)C"
            };
            
            //     A - B
            //    /
            // COM
            //    \
            //     C
            
            var result = Count(map);
            
            result.ShouldBe(4);
        }
        
        [Fact]
        public void LongerIndirectOrbits()
        {
            var map = new List<string>
            {
                "COM)A", 
                "A)B",
                "B)C"
            };
            

            //    
            // COM - A - B - C
            //    
            
            var result = Count(map);
            
            result.ShouldBe(6);
        }

        private int Count(List<string> map)
        {
            var objects = new List<string>();
            
            foreach (var entry in map)
            {
                var parts = entry.Split(')');
                objects.Add(parts[0]);
                objects.Add(parts[1]);
            }

            objects.RemoveAll(x => x == "COM");
            
            return objects.Count();
        }
    }
}