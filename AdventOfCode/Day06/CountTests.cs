using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day06
{
    public class CountTests
    {
        // (x) one direct orbit
        // (x) multiple direct orbits
        // (x) one indirect orbit
        // (x) single chain on object
        // (x) tree of objects
        
        private readonly ITestOutputHelper _console;

        public CountTests(ITestOutputHelper console)
        {
            _console = console;
        }
        
        [Fact]
        public void OneDirectOrbit()
        {
            var map = new List<string> {"COM)A"};
            
            //
            // COM - A
            //
            
            var result = new Count(_console).Run(map);
            
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
            
            var result = new Count(_console).Run(map);
            
            result.ShouldBe(3);
        }
        
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
            
            var result = new Count(_console).Run(map);
            
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
            
            var result = new Count(_console).Run(map);
            
            result.ShouldBe(2);
        }      
        
        [Fact]
        public void MultpleDirectAndIndirectOrbits()
        {
            var map = new List<string>
            {
                "COM)A", 
                "A)B", 
                "COM)C",
                "C)D",
                "D)E",
            };
            
            //     A - B
            //    /
            // COM
            //    \
            //     C - D - E
            
            var result = new Count(_console).Run(map);
            
            result.ShouldBe(9);
        }

        [Fact]
        public void Part1Example()
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
                "K)L"
            };
            
            //      G - H       J - K - L
            //     /           /
            // COM - B - C - D - E - F
            //     \
            //      I
            
            var result = new Count(_console).Run(map);
            
            result.ShouldBe(42);
        }
        
        [Fact]
        public void Part1()
        {
            var map = PuzzleInput.Map;

            var result = new Count(_console).Run(map);
            
            _console.WriteLine(result.ToString());
        }
    }
}