using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace AdventOfCode.Day05
{
    public class Tests
    {
        [Fact]
        public void OpCodeOne()
        {
            var input = new List<int> { 1, 0, 0, 0, 99 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 2, 0, 0, 0, 99 });
        }
        
        [Fact]
        public void DifferentInputPositions()
        {
            var input = new List<int> { 1, 2, 2, 0, 99 };
            
            var result = RunProgram(input);
            
            result.ShouldBe(new List<int> { 4, 2, 2, 0, 99 });
        }
        
        [Fact]
        public void DifferentOutputPosition()
        {
            var input = new List<int> { 1, 0, 0, 5, 99, 0 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 1, 0, 0, 5, 99, 2 });
        }
        
        [Fact]
        public void MultipleOperations()
        {
            var input = new List<int> { 1, 0, 0, 0, 1, 0, 0, 4, 99 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 2, 0, 0, 0, 4, 0, 0, 4, 99 });
        }  
        
        [Fact]
        public void OpCodeTwo()
        {
            var input = new List<int> { 2, 5, 6, 7, 99, 1, 3, 0 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 2, 5, 6, 7, 99, 1, 3, 3 });
        }
        
        [Fact]
        public void GivenExample()
        {
            var input = new List<int> { 1,1,1,4,99,5,6,0,99 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 30,1,1,4,2,5,6,0,99 });
        }
        
        // ( ) OpCode 4
        // ( ) OpCode 3
        // ( ) Immediate Mode
        // ( ) Explicit Position Mode
        
        private List<int> RunProgram(List<int> memory)
        {
            int instructionPointer = 0;
            
            while ((instructionPointer + 4) < memory.Count)
            {
                ProcessInstruction(instructionPointer, memory);
                instructionPointer += 4;
            }

            return memory;
        }

        private static void ProcessInstruction(int instructionAddress, List<int> memory)
        {
            var address1 = memory[instructionAddress + 1];
            var address2 = memory[instructionAddress + 2];
            
            var outputAddress = memory[instructionAddress + 3];
            
            var functions = new List<Func<int, int, int>>
            {
                (x, y) => 0,
                (x, y) => x + y,
                (x, y) => x * y
            };

            var opCode = memory[instructionAddress];
            var value1 = memory[address1];
            var value2 = memory[address2];

            if (opCode < functions.Count)
            {
                memory[outputAddress] = functions[opCode](value1, value2);
            }
        }
    }
}