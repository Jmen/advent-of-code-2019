using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace AdventOfCode.Day07
{
    public class AmplificationCircuit
    {
        private readonly Operations _operations;
        
        private readonly ITestOutputHelper _console;

        public AmplificationCircuit(ITestOutputHelper console)
        {
            _console = console;
            _operations  = new Operations(_console);
        }
        
        public int Run(List<int> memory, int input, List<int> phases)
        {
            foreach (var phase in phases)
            {
                _console.WriteLine(Environment.NewLine);
                _console.WriteLine($"Amp with phase {phase} and input {input}");
                _console.WriteLine(Environment.NewLine);
                
                input = RunAmplifier(memory, input, phase);
            }

            return input;
        }

        private int RunAmplifier(List<int> memory, int input, int phase)
        {
            var outputs = new List<int>();

            int instructionPointer = 0;

            instructionPointer = ProcessInput(memory, instructionPointer, phase);

            while (instructionPointer < memory.Count)
            {
                instructionPointer = ProcessInput(memory, instructionPointer, input);
                instructionPointer = ProcessInstruction(instructionPointer, memory);
                instructionPointer = ProcessOutput(memory, instructionPointer, outputs);

                if (IsBreakInstruction(memory, instructionPointer))
                {
                    break;
                }
            }

            return outputs[0];
        }

        private static bool IsBreakInstruction(List<int> memory, int instructionPointer)
        {
            return memory[instructionPointer] == 99;
        }

        private int ProcessInput(List<int> memory, int instructionPointer, int? input)
        {
            if (memory[instructionPointer] == 3 && input != null)
            {
                var position = memory[instructionPointer + 1];
                memory[position] = input.Value;
                
                _console.WriteLine($"input {input} into position {position}");

                return instructionPointer + 2;
            }

            return instructionPointer;
        }

        private int ProcessOutput(List<int> memory, int instructionPointer, List<int> outputs)
        {
            if (memory[instructionPointer] == 4)
            {
                var outputPointer = memory[instructionPointer + 1];

                outputs.Add(memory[outputPointer]);
                instructionPointer += 2;
                
                _console.WriteLine($"output position = {outputPointer}");
                _console.WriteLine($"output value = {memory[outputPointer]}");
            }

            return instructionPointer;
        }
        
        private int ProcessInstruction(int instructionAddress, List<int> memory)
        {
            var opCode = ReadOpCode(memory[instructionAddress]);
            
            if (_operations.IsValid(opCode))
            {
                if (opCode == 5 || opCode == 6)
                {
                    _console.WriteLine($"[{instructionAddress}] {memory[instructionAddress]} {memory[instructionAddress + 1]} {memory[instructionAddress + 2]}");
                }
                else
                {
                    _console.WriteLine($"[{instructionAddress}] {memory[instructionAddress]} {memory[instructionAddress + 1]} {memory[instructionAddress + 2]} {memory[instructionAddress + 3]}");
                }
                
                var positionModes = GetPositionModes(memory[instructionAddress]);

                int value1 = ReadParameterValue(1, positionModes.One, memory, instructionAddress);
                int value2 = ReadParameterValue(2, positionModes.Two, memory, instructionAddress);
                
                var outputAddress = memory[instructionAddress + 3];
                
                var parameters = new List<int>{ value1, value2, outputAddress };

                var newAddress = _operations.Run(opCode, memory, parameters, instructionAddress);
                
                _console.WriteLine($"[{instructionAddress}] next instruction is position {newAddress}");
                
                return newAddress;
            }
            
            _console.WriteLine($"[{instructionAddress}] {memory[instructionAddress]} {memory[instructionAddress + 1]} {memory[instructionAddress + 2]} {memory[instructionAddress + 3]}");
            _console.WriteLine($"[{instructionAddress}] skipping ");
            
            return instructionAddress + 4;
        }

        private static int ReadParameterValue(int parameterNumber, int positionMode, List<int> memory, int instructionAddress)
        {
            return (positionMode == 0) ? memory[memory[instructionAddress + parameterNumber]] : memory[instructionAddress + parameterNumber];
        }

        private (int One, int Two) GetPositionModes(int opCodeAndPositionModes)
        {
            var one = 0;
            var two = 0;

            if (opCodeAndPositionModes > 100 && opCodeAndPositionModes < 1000)
            {
                one = Convert.ToInt32(Convert.ToString(opCodeAndPositionModes)[0].ToString());
            }

            if (opCodeAndPositionModes >= 1000)
            {
                two = Convert.ToInt32(Convert.ToString(opCodeAndPositionModes)[0].ToString());
                one = Convert.ToInt32(Convert.ToString(opCodeAndPositionModes)[1].ToString());
            }
            
            return (one, two);
        }

        private int ReadOpCode(int opCodeAndParameters)
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