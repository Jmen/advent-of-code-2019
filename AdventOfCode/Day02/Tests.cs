using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day02
{
    public class Tests
    {
        // op code operation - add
        // op code operation - multiply
        // position of inputs
        // position of output
        // multiple op codes 
        // ending on 99
        
        private readonly ITestOutputHelper _console;

        public Tests(ITestOutputHelper console)
        {
            _console = console;
        }


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
        
        [Fact]
        public void FullPuzzle()
        {
            var input = PuzzleInput.Program;

            var result = RunProgram(input);

            //3850704
            _console.WriteLine(result[0].ToString());
        }
        
        [Fact]
        public void Part2()
        {
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    var input = PuzzleInput.Program;

                    input[1] = noun;
                    input[2] = verb;
                    
                    var result = RunProgram(input);

                    if (result[0] == 19690720)
                    {
                        _console.WriteLine($"noun = {noun}, verb = {verb}");
                    }
                }
            }
            
            //100 * 67 + 18 = 6718
        }

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