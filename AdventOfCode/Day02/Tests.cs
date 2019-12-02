using System;
using System.Collections.Generic;
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
        public void OpCodeOne_DifferentInputPositions()
        {
            var input = new List<int> { 1, 2, 2, 0, 99 };
            
            var result = RunProgram(input);
            
            result.ShouldBe(new List<int> { 4, 2, 2, 0, 99 });
        }
        
        [Fact]
        public void OpCodeOne_DifferentOutputPosition()
        {
            var input = new List<int> { 1, 0, 0, 5, 99, 0 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 1, 0, 0, 5, 99, 2 });
        }

        private IEnumerable<int> RunProgram(List<int> input)
        {
            var additionPosition1 = input[1];
            var additionPosition2 = input[2];
            var outputPosition = input[3];
            
            input[outputPosition] = input[additionPosition1] + input[additionPosition2];

            return input;
        }
    }
}