using System;
using System.Collections.Generic;
using Xunit;

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
        // ( ) cross before end of the paths
        // ( ) multiple crossing points
        
        [Fact]
        public void Square_OneByOne()
        {
            // +x
            // o+
            
            var wire1 = new List<string> { "U1", "L1" };
            var wire2 = new List<string> { "L1", "U1" };
            
            var result = CrossedWires(wire1, wire2);
            
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void Rectangle_LeftTwoUpOne()
        {
            // x-+
            // +-o
            
            var wire1 = new List<string> { "U1", "L2" };
            var wire2 = new List<string> { "L2", "U1" };
            
            var result = CrossedWires(wire1, wire2);
            
            Assert.Equal(3, result);
        }
        
        [Fact]
        public void Rectangle_LeftOneUpTwo()
        {
            // +x
            // ||
            // o+
            
            var wire1 = new List<string> { "U2", "L1" };
            var wire2 = new List<string> { "L1", "U2" };
            
            var result = CrossedWires(wire1, wire2);
            
            Assert.Equal(3, result);
        }
        
        [Fact]
        public void MultiplePaths_OnlyUpAndLeft()
        {
            // +-x
            // | |
            // o-+
            
            var wire1 = new List<string> { "U1", "U1", "L1", "L1", };
            var wire2 = new List<string> { "L1", "L1", "U1", "U1" };
            
            var result = CrossedWires(wire1, wire2);
            
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void MultiplePaths_IncludingDown()
        {
            // +-+
            // x o
            // +-+
            
            var wire1 = new List<string> { "D1", "L2", "U1" };
            var wire2 = new List<string> { "U1", "L2", "D1" };
            
            var result = CrossedWires(wire1, wire2);
            
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void MultiplePaths_IncludingRight()
        {
            // +x+
            // | |
            // +o+
            
            var wire1 = new List<string> { "R1", "U2", "L1" };
            var wire2 = new List<string> { "L1", "U1", "R1" };
            
            var result = CrossedWires(wire1, wire2);
            
            Assert.Equal(2, result);
        }
        
        private int CrossedWires(List<string> wire1, List<string> wire2)
        {
            int distance = 0;
            
            foreach (string path in wire1)
            {
                if (path[0] == 'D' || path[0] == 'R')
                {
                    distance -= Convert.ToInt32(path.Remove(0, 1));
                }
                else
                {
                    distance += Convert.ToInt32(path.Remove(0, 1));
                }
            }

            return distance;
        }
    }
}