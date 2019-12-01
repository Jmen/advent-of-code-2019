using System;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode.Day01
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Part1()
        {
            var fuel = PuzzleInput.Modules.Sum(FuelRequired);
            
            //3393938
            Console.WriteLine(fuel);
        }
        
        [Test]
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
            Console.WriteLine(totalFuel);
        }

        private int FuelRequired(int moduleMass)
        {
            return moduleMass / 3 - 2;
        }
    }
}