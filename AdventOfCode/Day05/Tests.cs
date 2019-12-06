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
        
        // (x) OpCode 3
        // (x) OpCode 4
        // ( ) Immediate Mode
        // ( ) Explicit Position Mode
        
        [Fact]
        public void OpCodeThree_PutIntoInFirstPosition()
        {
            var memory = new List<int> { 3, 0, 99 };
            var input = 1;

            var result = RunProgram(memory, input);

            result.ShouldBe(new List<int> { 1, 0, 99 });
        }
        
        [Fact]
        public void OpCodeThree_PutIntoInAnotherPosition()
        {
            var memory = new List<int> { 3, 1, 99 };
            var input = 1;

            var result = RunProgram(memory, input);

            result.ShouldBe(new List<int> { 3, 1, 99 });
        }
        
        [Fact]
        public void OpCodeThree_AndAnotherOpCode()
        {
            var memory = new List<int> { 3, 1, 1, 0, 0, 7, 99, 0 };
            var input = 1;

            var result = RunProgram(memory, input);

            result.ShouldBe(new List<int> { 3, 1, 1, 0, 0, 7, 99, 6 });
        }
        
        [Fact]
        public void OpCodeFour()
        {
            var memory = new List<int> { 4, 0, 99 };

            var result = RunProgram(memory);

            result.ShouldBe(new List<int> { 4, 0, 99 });
            
            _outputs.ShouldBe(new List<int>{ 4 });
        }

        [Fact]
        public void OpCodeFour_AfterAnotherOpCode()
        {
            var memory = new List<int> { 1, 0, 0, 7, 4, 0, 99, 0 };

            var result = RunProgram(memory);

            result.ShouldBe(new List<int> { 1, 0, 0, 7, 4, 0, 99, 2 });
            
            _outputs.ShouldBe(new List<int>{ 1 });
        }
        
        [Fact]
        public void OpCodeFour_InBetweenOtherOpCodes()
        {
            var memory = new List<int> { 1, 0, 0, 11, 4, 0, 1, 0, 0, 12, 99, 0, 0 };

            var result = RunProgram(memory);

            result.ShouldBe(new List<int> { 1, 0, 0, 11, 4, 0, 1, 0, 0, 12, 99, 2, 2 });
            
            _outputs.ShouldBe(new List<int>{ 1 });
        }
        
        [Fact]
        public void AllFourOpCodes()
        {
            var memory = new List<int>
            {
                3, 13, 
                1, 0, 0, 14, 
                4, 0, 
                1, 0, 0, 15, 
                99, 0, 0, 0
            };

            var result = RunProgram(memory, 1);

            result.ShouldBe(new List<int>
            {
                3, 13, 
                1, 0, 0, 14, 
                4, 0, 
                1, 0, 0, 15, 
                99, 1, 6, 6
            });
            
            _outputs.ShouldBe(new List<int>{ 3 });
        }
        
        [Fact]
        public void OpCodeOne_ImmediateMode_FirstParameter()
        {
            var input = new List<int> { 101, 0, 0, 5, 99, 0 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 101, 0, 0, 5, 99, 101 });
        }
        
        [Fact]
        public void OpCodeOne_ImmediateMode_SecondParameter()
        {
            var input = new List<int> { 1001, 0, 0, 5, 99, 0 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 1001, 0, 0, 5, 99, 1001 });
        }
        
        [Fact]
        public void OpCodeOne_ImmediateMode_BothParameters()
        {
            var input = new List<int> { 1101, 3, 3, 5, 99, 0 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 1101, 3, 3, 5, 99, 6 });
        }
        
        [Fact]
        public void OpCodeTwo_ImmediateMode_BothParameters()
        {
            var input = new List<int> { 1102, 3, 3, 5, 99, 0 };

            var result = RunProgram(input);

            result.ShouldBe(new List<int> { 1102, 3, 3, 5, 99, 9 });
        }
        
        readonly List<int> _outputs = new List<int>();
        
        private List<int> RunProgram(List<int> memory, int? input = null)
        {
            int instructionPointer = ProcessInput(memory, input);
            
            while ((instructionPointer) < memory.Count)
            {
                // potential bug - what if there are two output in a row ?
                instructionPointer = ProcessOutput(memory, instructionPointer);
                instructionPointer = ProcessInstruction(instructionPointer, memory);
            }

            return memory;
        }
        
        private static int ProcessInput(List<int> memory, int? input)
        {
            int instructionPointer = 0;
            
            if (memory[0] == 3 && input != null)
            {
                var position = memory[1];
                memory[position] = input.Value;
                instructionPointer = 2;
            }

            return instructionPointer;
        }

        private int ProcessOutput(List<int> memory, int instructionPointer)
        {
            if (memory[instructionPointer] == 4)
            {
                var outputPointer = memory[instructionPointer + 1];

                _outputs.Add(memory[outputPointer]);
                instructionPointer += 2;
            }

            return instructionPointer;
        }

        private static int ProcessInstruction(int instructionAddress, List<int> memory)
        {
            var opCode = ReadOpCode(memory[instructionAddress]);

            if (opCode != 1 && opCode != 2)
            {
                return instructionAddress += 4;
            }

            var parameterOnePositionMode = 0;
            var parameterTwoPositionMode = 0;

            if (memory[instructionAddress] > 100 && memory[instructionAddress] < 1000)
            {
                parameterOnePositionMode = Convert.ToInt32(Convert.ToString(memory[instructionAddress])[0].ToString());
            }

            if (memory[instructionAddress] >= 1000)
            {
                parameterTwoPositionMode = Convert.ToInt32(Convert.ToString(memory[instructionAddress])[0].ToString());
                parameterOnePositionMode = Convert.ToInt32(Convert.ToString(memory[instructionAddress])[1].ToString());
            }

            var address1 = memory[instructionAddress + 1];
            var address2 = memory[instructionAddress + 2];
            
            var outputAddress = memory[instructionAddress + 3];
            
            var functions = new List<Func<int, int, int>>
            {
                (x, y) => 0, //potential bug - if needed fix by changing collection to dictionary keyed by OpCode
                (x, y) => x + y,
                (x, y) => x * y
            };

            
            var value1 = ( parameterOnePositionMode == 0 ) ? memory[address1] : address1;
            var value2 = ( parameterTwoPositionMode == 0 ) ? memory[address2] : address2;

            if (opCode < functions.Count)
            {
                memory[outputAddress] = functions[opCode](value1, value2);
            }

            return instructionAddress += 4;
        }       
        
        private static int ReadOpCode(int opCodeAndParameters)
        {
            var opCode = opCodeAndParameters;

            if (opCodeAndParameters > 100)
            {
                var d = Convert.ToString(opCodeAndParameters)[1].ToString();
                var e = Convert.ToString(opCodeAndParameters)[2].ToString();

                opCode = Convert.ToInt32(d) + Convert.ToInt32(e);
            }

            if (opCodeAndParameters > 1000)
            {
                var d = Convert.ToString(opCodeAndParameters)[2].ToString();
                var e = Convert.ToString(opCodeAndParameters)[3].ToString();

                opCode = Convert.ToInt32(d) + Convert.ToInt32(e);
            }

            return opCode;
        }
    }
}