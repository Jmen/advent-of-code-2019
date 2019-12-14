using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day06
{
    public class DistanceTests
    {
        // (x) one direct orbit
        // (x) multiple direct orbits
        // (x) one indirect orbit
        // (x) single chain on object
        // (x) tree of objects
        
        private readonly ITestOutputHelper _console;

        public DistanceTests(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Distance_Two_Orbits_BothChildren()
        {
            var map = new List<string>()
            {
                "COM)YOU",
                "YOU)A",
                "A)B",
                "B)SAN",
            };
            
            //
            // COM - YOU - A - B - SAN
            //
            
            var result = new Distance(_console).Run(map);
            
            result.Found.ShouldBeTrue();
            result.Distance.ShouldBe(1);
        }
        
        [Fact]
        public void Distance_One_Orbit_SecondChild()
        {
            var map = new List<string>()
            {
                "COM)YOU",
                "YOU)A",
                "A)B",
                "A)C",
                "C)SAN",
            };
            
            //                B
            //              /
            // COM - YOU - A
            //              \
            //                C - SAN
            
            var result = new Distance(_console).Run(map);
            
            result.Found.ShouldBeTrue();
            result.Distance.ShouldBe(1);
        }

        [Fact]
        public void Distance_Two_Orbits_Both_Parents()
        {
            var map = new List<string>()
            {
                "COM)SAN",
                "SAN)A",
                "A)B",
                "B)YOU",
            };
            
            //
            // COM - SAN - A - B - YOU
            //
            
            var result = new Distance(_console).Run(map);
            
            result.Found.ShouldBeTrue();
            result.Distance.ShouldBe(1);
        }
        
        [Fact]
        public void Distance_Three_Orbits_Parent_Then_Child()
        {
            var map = new List<string>()
            {
                "COM)A",
                "A)B",
                "B)YOU",
                "A)C",
                "C)SAN",
            };
            
            //         B - YOU
            //        /
            // COM - A
            //        \
            //         C - SAN
            
            var result = new Distance(_console).Run(map);
            
            result.Found.ShouldBeTrue();
            result.Distance.ShouldBe(2);
        }        
        
        [Fact]
        public void Distance_Part2_Example()
        {
            var map = new List<string>()
            {
                "COM)B",
                "B)C",
                "C)D",
                "D)E",
                "E)F",
                "B)G",
                "G)H",
                "D)I",
                "E)J",
                "J)K",
                "K)L",
                "K)YOU",
                "I)SAN",
            };
            
            //                        YOU
            //                       /
            //      G - H       J - K - L
            //     /           /
            // COM - B - C - D - E - F
            //                \
            //                 I - SAN
            //
            
            var result = new Distance(_console).Run(map);
            
            result.Found.ShouldBeTrue();
            result.Distance.ShouldBe(4);
        }    
        
        [Fact]
        public void Distance_Part2()
        {
            var map = PuzzleInput.Map;
            
            var result = new Distance(_console).Run(map);
            
            result.Found.ShouldBeTrue();
            
            _console.WriteLine(result.ToString());
        }
    }
}