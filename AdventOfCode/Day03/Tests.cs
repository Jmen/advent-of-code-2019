using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day03
{
    public class Tests
    {
        // (x) cross at the end of the paths
        // (x) two paths for each wire (rectangle)
        // (x)   extend rectangle left
        // (x)    extend rectangle up
        // (x) multiple paths
        // (x)     up and left - 4 paths (even)
        // (x)     down 3 paths (odd)
        // (x)     right 
        // (x) cross before end of the paths
        // (x)    at an edge
        // (x)    in between edges
        // (x) multiple crossing points
        // (x)     closest is not first crossing
        
        private readonly ITestOutputHelper _console;

        public Tests(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void Square_OneByOne()
        {
            // +x
            // o+
            
            // 0,1
            // 1,1

            var wire1 = new List<string> {"U1", "R1"};
            var wire2 = new List<string> {"R1", "U1"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Rectangle_LeftTwoUpOne()
        {
            // x-+
            // +-o

            var wire1 = new List<string> {"U1", "R2"};
            var wire2 = new List<string> {"R2", "U1"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void Rectangle_LeftOneUpTwo()
        {
            // +x
            // ||
            // o+

            var wire1 = new List<string> {"U2", "R1"};
            var wire2 = new List<string> {"R1", "U2"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void MultiplePaths_OnlyUpAndLeft()
        {
            // +-x
            // | |
            // o-+

            var wire1 = new List<string> {"U1", "U1", "R1", "R1",};
            var wire2 = new List<string> {"R1", "R1", "U1", "U1"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(4, result);
        }

        [Fact]
        public void MultiplePaths_IncludingDown()
        {
            // +-+
            // x o
            // +-+

            var wire1 = new List<string> {"D1", "L2", "U1"};
            var wire2 = new List<string> {"U1", "L2", "D1"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(2, result);
        }

        [Fact]
        public void MultiplePaths_IncludingRight()
        {
            // +x+
            // | |
            // +o+

            var wire1 = new List<string> {"R1", "U2", "L1"};
            var wire2 = new List<string> {"L1", "U2", "R1"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(2, result);
        }

        [Fact]
        public void CrossBeforeEndOfPath_AtAnEdge()
        {
            // +x-
            // o+

            var wire1 = new List<string> {"U1", "R1", "R1"};
            var wire2 = new List<string> {"R1", "U1"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(2, result);
        }
        
        [Fact]
        public void CrossBeforeEndOfPath_InBetweenEdges()
        {
            //   |
            // +-x-
            // | |
            // o-+
            
            // 0,1
            // 0,2
            // 1,2
            // 2,2
            // 3,2

            var wire1 = new List<string> {"U2", "R3"};
            var wire2 = new List<string> {"R2", "U3"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(4, result);
        }
        
        [Fact]
        public void WorkedExample()
        {
            var wire1 = new List<string>{"R8","U5","L5","D3"};
            var wire2 = new List<string>{"U7","R6","D4","L4"};

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(6, result);
        }
        
        [Fact]
        public void ExampleOne()
        {
            var wire1 = ExampleOneInput.FirstWire;
            var wire2 = ExampleOneInput.SecondWire;

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(159, result);
        }
        
        [Fact]
        public void ExampleTwo()
        {
            var wire1 = ExampleTwoInput.FirstWire;
            var wire2 = ExampleTwoInput.SecondWire;

            var result = CrossedWires.Run(wire1, wire2);

            Assert.Equal(135, result);
        }
        
        //[Fact]
        public void Part1()
        {
            var wire1 = PuzzleInput.FirstWire;
            var wire2 = PuzzleInput.SecondWire;

            var result = CrossedWires.Run(wire1, wire2);

            _console.WriteLine(result.ToString());
        }
    }

    
}