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
        // (x) single chain on object
        // ( ) tree of objects
        // ( ) object not specified in order
        
        [Fact]
        public void OneDirectOrbit()
        {
            var map = new List<string> {"COM)A"};
            
            //
            // COM - A
            //
            
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


        
//        [Fact]
//        public void DirectAndIndirectOrbits()
//        {
//            var map = new List<string>
//            {
//                "COM)A", 
//                "A)B",
//                "COM)C"
//            };
//            
//            //     A - B
//            //    /
//            // COM
//            //    \
//            //     C
//            
//            var result = Count(map);
//            
//            result.ShouldBe(4);
//        }
        
        [Fact]
        public void ChainOfThreeObjects()
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

        private int Count(List<string> map)
        {
            var links = new List<(string Orbitie, string Orbiter)>();
            
            foreach (var entry in map)
            {
                var parts = entry.Split(')');
                links.Add((parts[0], parts[1]));
            }
            
            // 1
            // 1 + 2
            // 1 + 2 + 3
            // 1 + 2 + 3 + 4

            return Enumerable.Range(1, links.Count).Sum();
        }
    }
}