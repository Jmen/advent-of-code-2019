using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day01
{
    public class Tests
    {
        private readonly ITestOutputHelper _console;

        public Tests(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Part1()
        {
            var fuel = PuzzleInput.Modules.Sum(FuelRequired);
            
            //3393938
            _console.WriteLine(fuel.ToString());
        }
        
        [Fact]
        public void Part2()
        {
            var totalFuel = 0;
            
            foreach (var module in PuzzleInput.Modules)
            {
                var fuel = FuelRequired(module);
                
                while (fuel > 0)
                {
                    totalFuel += fuel;
                    
                    fuel = FuelRequired(fuel);
                } 
            }
            
            //5088037
            _console.WriteLine(totalFuel.ToString());
        }

        private int FuelRequired(int moduleMass)
        {
            return moduleMass / 3 - 2;
        }
    }
}