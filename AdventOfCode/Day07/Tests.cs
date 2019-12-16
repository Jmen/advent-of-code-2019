using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Day07
{
    public class Tests
    {
        // (x) 2 input values at start of program
        // (x) 2 input values anywhere in the program
        // ( ) pass output from one program to input of another

        private readonly ITestOutputHelper _console;

        public Tests(ITestOutputHelper console)
        {
            _console = console;
        }
        
        [Fact]
        public void TwoInputsAtTheStart()
        {
            var memory = new List<int>
            {
                3, 11,          // input
                3, 12,          // phase 1
                1, 11, 12, 13,  // add
                4, 13,          // output
                99, 0, 0, 0     // exit
            };
            
            var phases = new List<int>{ 1 };

            var firstInput = 1;
            
            var amplificationCircuit = new AmplificationCircuit(_console);
            
            var result = amplificationCircuit.Run(memory, firstInput, phases);
            
            result.ShouldBe(2);
        }    
        
        [Fact]
        public void TwoInputsAnyWhere()
        {
            var memory = new List<int>
            {
                3, 15,          // input
                999, 0, 0, 0,   // junk
                3, 16,          // phase 1
                1, 15, 16, 17,  // add
                4, 17,          // output
                99, 0, 0, 0     // exit
            };
            
            var phases = new List<int>{ 1, 0, 0, 0, 0 };

            var firstInput = 1;
            
            var amplificationCircuit = new AmplificationCircuit(_console);
            
            var result = amplificationCircuit.Run(memory, firstInput, phases);
            
            result.ShouldBe(2);
        }
        
        [Fact]
        public void PassOutputToInputOfSecondAmplifier()
        {
            var memory = new List<int>
            {
                3, 11,          // input
                3, 12,          // phase 1 or 2
                1, 11, 12, 13,  // add
                4, 13,          // output
                99, 0, 0, 0     // exit
            };
            
            var phases = new List<int>{ 1, 2, 0, 0, 0 };

            var firstInput = 1;
            
            var amplificationCircuit = new AmplificationCircuit(_console);
            
            var result = amplificationCircuit.Run(memory, firstInput, phases);
            
            // firstInput + phase1 + phase 2
            result.ShouldBe(4);
        }
        
        [Fact]
        public void FivePhases()
        {
            var memory = new List<int>
            {
                3, 11,          // input
                3, 12,          // phase 1 or 2
                1, 11, 12, 13,  // add
                4, 13,          // output
                99, 0, 0, 0     // exit
            };
            
            var phases = new List<int>{ 1, 1, 1, 1, 1 };

            var firstInput = 1;
            
            var amplificationCircuit = new AmplificationCircuit(_console);
            
            var result = amplificationCircuit.Run(memory, firstInput, phases);
            
            result.ShouldBe(6);
        }
        
        [Fact]
        public void ExampleOne()
        {
            var memory = new List<int>
            {
                /* 0  */ 3,15,
                /* 2  */ 3,16,
                /* 4  */ 1002,16,10,16,
                /* 8  */ 1,16,15,15,
                /* 12 */ 4,15,
                /* 14 */ 99,
                /* 15 */ 0,
                /* 16 */ 0,
            };
            var phases = new List<int>{ 4,3,2,1,0 };

            var firstInput = 0;

            var amplificationCircuit = new AmplificationCircuit(_console);

            var result = amplificationCircuit.Run(memory, firstInput, phases);
            
            result.ShouldBe(43210);
        }        
        
        [Fact]
        public void ExampleTwo()
        {
            var memory = new List<int>
            {
                3,23,3,24,1002,24,10,24,1002,23,-1,23,
                101,5,23,23,1,24,23,23,4,23,99,0,0
            };
            var phases = new List<int>{ 0,1,2,3,4 };

            var firstInput = 0;

            var amplificationCircuit = new AmplificationCircuit(_console);

            var result = amplificationCircuit.Run(memory, firstInput, phases);
            
            result.ShouldBe(54321);
        }        
        
        [Fact]
        public void ExampleThree()
        {
            var memory = new List<int>
            {
                3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,
                1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0
            };
            var phases = new List<int>{ 1,0,4,3,2 };

            var firstInput = 0;

            var amplificationCircuit = new AmplificationCircuit(_console);

            var result = amplificationCircuit.Run(memory, firstInput, phases);
            
            result.ShouldBe(65210);
        }
        
        [Fact]
        public void Part1()
        {
            var memory = PuzzleInput.Program;

            var maxResult = 0;
            
            foreach (var phase1 in new []{ 0, 1, 2, 3, 4 })
            {
                foreach (var phase2 in new []{ 0, 1, 2, 3, 4 })
                {
                    foreach (var phase3 in new []{ 0, 1, 2, 3, 4 })
                    {
                        foreach (var phase4 in new []{ 0, 1, 2, 3, 4 })
                        {
                            foreach (var phase5 in new []{ 0, 1, 2, 3, 4 })
                            {
                                var phases = new List<int> { phase1, phase2, phase3, phase4, phase5 };
                                
                                if (phases.Distinct().Count() == 5)
                                {   
                                    var firstInput = 0;
            
                                    var amplificationCircuit = new AmplificationCircuit(_console);
            
                                    var result = amplificationCircuit.Run(memory, firstInput, phases);

                                    maxResult = result > maxResult ? result : maxResult;
                                }
                            }
                        }
                    }
                }
            }
            
            _console.WriteLine(maxResult.ToString());
        }
    }
}