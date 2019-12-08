using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day05
{
    public class Tests
    {
        private readonly ITestOutputHelper _console;

        public Tests(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public void OpCodeOne()
        {
            var memory = new List<int> {1, 0, 0, 0, 99};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {2, 0, 0, 0, 99});
        }

        [Fact]
        public void DifferentInputPositions()
        {
            var memory = new List<int> {1, 2, 2, 0, 99};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {4, 2, 2, 0, 99});
        }

        [Fact]
        public void DifferentOutputPosition()
        {
            var memory = new List<int> {1, 0, 0, 5, 99, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {1, 0, 0, 5, 99, 2});
        }

        [Fact]
        public void MultipleOperations()
        {
            var memory = new List<int> {1, 0, 0, 0, 1, 0, 0, 4, 99};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {2, 0, 0, 0, 4, 0, 0, 4, 99});
        }

        [Fact]
        public void OpCodeTwo()
        {
            var memory = new List<int> {2, 5, 6, 7, 99, 1, 3, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {2, 5, 6, 7, 99, 1, 3, 3});
        }

        [Fact]
        public void GivenExample()
        {
            var memory = new List<int> {1, 1, 1, 4, 99, 5, 6, 0, 99};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {30, 1, 1, 4, 2, 5, 6, 0, 99});
        }

        // (x) OpCode 3
        // (x) OpCode 4
        // (x) Immediate Mode
        // (x) Explicit Position Mode

        [Fact]
        public void OpCodeThree_PutIntoInFirstPosition()
        {
            var memory = new List<int> {3, 0, 99};
            var input = 1;

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory, input);

            result.memory.ShouldBe(new List<int> {1, 0, 99});
        }

        [Fact]
        public void OpCodeThree_PutIntoInAnotherPosition()
        {
            var memory = new List<int> {3, 3, 99, 0};
            var input = 1;

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory, input);

            result.memory.ShouldBe(new List<int> {3, 3, 99, 1});
        }

        [Fact]
        public void OpCodeThree_AndAnotherOpCode()
        {
            var memory = new List<int>
            {
                3, 7, 
                1, 0, 0, 8, 
                99, 0, 0
            };

            var input = 1;

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory, input);

            result.memory.ShouldBe(new List<int>
            {
                3, 7, 
                1, 0, 0, 8, 
                99, 1, 6
            });
        }

        [Fact]
        public void OpCodeFour()
        {
            var memory = new List<int> {4, 0, 99};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {4, 0, 99});

            result.outputs.ShouldBe(new List<int> {4});
        }

        [Fact]
        public void OpCodeFour_AfterAnotherOpCode()
        {
            var memory = new List<int> {1, 0, 0, 7, 4, 0, 99, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {1, 0, 0, 7, 4, 0, 99, 2});

            result.outputs.ShouldBe(new List<int> {1});
        }

        [Fact]
        public void OpCodeFour_InBetweenOtherOpCodes()
        {
            var memory = new List<int> {1, 0, 0, 11, 4, 0, 1, 0, 0, 12, 99, 0, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {1, 0, 0, 11, 4, 0, 1, 0, 0, 12, 99, 2, 2});

            result.outputs.ShouldBe(new List<int> {1});
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

            var input = 1;
            
            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory, input);

            result.memory.ShouldBe(new List<int>
            {
                3, 13,
                1, 0, 0, 14,
                4, 0,
                1, 0, 0, 15,
                99, 1, 6, 6
            });

            result.outputs.ShouldBe(new List<int> {3});
        }

        [Fact]
        public void OpCodeOne_ImmediateMode_FirstParameter()
        {
            var memory = new List<int> {101, 0, 0, 5, 99, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {101, 0, 0, 5, 99, 101});
        }

        [Fact]
        public void OpCodeOne_ImmediateMode_SecondParameter()
        {
            var memory = new List<int> {1001, 0, 0, 5, 99, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {1001, 0, 0, 5, 99, 1001});
        }

        [Fact]
        public void OpCodeOne_ImmediateMode_BothParameters()
        {
            var memory = new List<int> {1101, 3, 3, 5, 99, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {1101, 3, 3, 5, 99, 6});
        }

        [Fact]
        public void OpCodeTwo_ImmediateMode_BothParameters()
        {
            var memory = new List<int> {1102, 3, 3, 5, 99, 0};

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int> {1102, 3, 3, 5, 99, 9});
        }


//        [Fact] // Part 2 changes the behaviour for the same input
//        public void Part1()
//        {
//            var memory = PuzzleInput.Program;
//
//            var input = 1;
//
//            var sunny = new SunnyWithAChanceOfAsteroids();
//            
//            var result = sunny.RunProgram(memory, input);
//
//            result.Debug.ForEach(x => _console.WriteLine(x.ToString()));
//            result.outputs.ForEach(x => _console.WriteLine($"output = {x}"));
//            
//            result.outputs[7].ShouldBe(8332629);
//        }

        [Fact]
        public void OpCodeFive_Jump_True_ImmediateMode()
        {
            var memory = new List<int>
            {
                1105, 1, 7, 
                1, 0, 0, 8, 
                99, 0
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1105, 1, 7, 
                1, 0, 0, 8, 
                99, 0
            });
        }
        
        [Fact]
        public void OpCodeFive_Jump_False_ImmediateMode()
        {
            var memory = new List<int>
            {
                1105, 0, 7, 
                1, 0, 0, 8, 
                99, 0
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1105, 0, 7, 
                1, 0, 0, 8, 
                99, 2210
            });
        }
        
        [Fact]
        public void OpCodeSix_Jump_True_ImmediateMode()
        {
            var memory = new List<int>
            {
                1106, 0, 7, 
                1, 0, 0, 8, 
                99, 0
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1106, 0, 7, 
                1, 0, 0, 8, 
                99, 0
            });
        }
        
        [Fact]
        public void OpCodeSix_Jump_False_ImmediateMode()
        {
            var memory = new List<int>
            {
                1106, 1, 7, 
                1, 0, 0, 8, 
                99, 0
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1106, 1, 7, 
                1, 0, 0, 8, 
                99, 2212
            });
        }
        
                
        [Fact]
        public void OpCodeSeven_Outputs_One_ImmediateMode()
        {
            var memory = new List<int>
            {
                1107, 0, 1, 5, 
                99, 0
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1107, 0, 1, 5, 
                99, 1
            });
        }
        
        [Fact]
        public void OpCodeSeven_Outputs_Zero_ImmediateMode()
        {
            var memory = new List<int>
            {
                1107, 1, 0, 5, 
                99, 1
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1107, 1, 0, 5, 
                99, 0
            });
        }
        
        [Fact]
        public void OpCodeEight_Outputs_One_ImmediateMode()
        {
            var memory = new List<int>
            {
                1108, 1, 1, 5, 
                99, 0
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1108, 1, 1, 5, 
                99, 1
            });
        }
        
        [Fact]
        public void OpCodeEight_Outputs_Zero_ImmediateMode()
        {
            var memory = new List<int>
            {
                1108, 0, 1, 5, 
                99, 1
            };

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory);

            result.memory.ShouldBe(new List<int>
            {
                1108, 0, 1, 5, 
                99, 0
            });
        }
        
        [Fact]
        public void Part2()
        {
            var memory = PuzzleInput.Program;

            var input = 5;

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory, input);

            result.Debug.ForEach(x => _console.WriteLine(x.ToString()));
            result.outputs.ForEach(x => _console.WriteLine($"output = {x}"));
            
            //result.outputs[7].ShouldBe(8332629);
        }
        
        [Fact]
        public void Part2_Example_1_IsEqualToEight_True()
        {
            var memory = new List<int>
            {
                3, 9,
                8, 9, 10, 9,
                4, 9,
                99, -1, 8
            };

            var input = 8;

            var sunny = new SunnyWithAChanceOfAsteroids();
            
            var result = sunny.RunProgram(memory, input);

            result.Debug.ForEach(x => _console.WriteLine(x.ToString()));
            result.outputs.ForEach(x => _console.WriteLine($"output = {x}"));
            
            result.outputs[0].ShouldBe(1);
        }
        
    }
}