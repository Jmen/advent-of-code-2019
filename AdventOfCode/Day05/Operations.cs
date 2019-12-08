using System;
using System.Collections.Generic;

namespace AdventOfCode.Day05
{
    public class Operations
    {
        private readonly Dictionary<int, Func<List<int>, List<int>, int, int>> _operations = new Dictionary<int, Func<List<int>, List<int>, int, int>>();

        private readonly List<string> _debug;

        public Operations(List<string> debug)
        {
            _debug = debug;
            
            _operations.Add(1, Add);
            _operations.Add(2, Multiply);
            _operations.Add(5, JumpIfNotZero);
            _operations.Add(6, JumpIfEqualZero);
            _operations.Add(7, LessThan);
            _operations.Add(8, EqualTo);
        }

        public bool IsValid(in int opCode)
        {
            return _operations.ContainsKey(opCode);
        }

        public int Run(int opsCode, List<int> memory, List<int> parameters, int currentAddress)
        {
            return _operations[opsCode](memory, parameters, currentAddress);
        }

        private int Add(List<int> memory, List<int> parameters, int currentAddress)
        {
            memory[parameters[2]] = parameters[0] + parameters[1];

            _debug.Add($"Set {parameters[2]} to {parameters[0] + parameters[1]} ( {parameters[0]} + {parameters[1]} )");

            return currentAddress + 4;
        }

        private int Multiply(List<int> memory, List<int> parameters, int currentAddress)
        {
            memory[parameters[2]] = parameters[0] * parameters[1];

            _debug.Add($"Set {parameters[2]} to {parameters[0] * parameters[1]} ( {parameters[0]} * {parameters[1]} )");

            return currentAddress + 4;
        }

        private int JumpIfNotZero(List<int> memory, List<int> parameters, int currentAddress)
        {
            if (parameters[0] != 0)
            {
                _debug.Add($"Jump to {parameters[1]} ( {parameters[0]} != 0 ) if (non-zero)");
                return parameters[1];
            }

            _debug.Add($"Ignore Jump ( {parameters[0]} == 0 ) if (non-zero)");

            return currentAddress + 3;
        }

        private int JumpIfEqualZero(List<int> memory, List<int> parameters, int currentAddress)
        {
            if (parameters[0] == 0)
            {
                _debug.Add($"Jump to {parameters[1]} ( {parameters[0]} == 0 ) if (equal zero)");
                return parameters[1];
            }

            _debug.Add($"Ignore Jump ( {parameters[0]} != 0 ) if (equal zero)");

            return currentAddress + 3;
        }

        private int LessThan(List<int> memory, List<int> parameters, int currentAddress)
        {
            if (parameters[0] < parameters[1])
            {
                memory[parameters[2]] = 1;

                _debug.Add($"Set {parameters[2]} to 1 ( {parameters[0]} < {parameters[1]} )");
            }
            else
            {
                memory[parameters[2]] = 0;

                _debug.Add($"Set {parameters[2]} to 0 ( {parameters[0]} NOT < {parameters[1]} )");
            }

            return currentAddress + 4;
        }

        private int EqualTo(List<int> memory, List<int> parameters, int currentAddress)
        {
            if (parameters[0] == parameters[1])
            {
                memory[parameters[2]] = 1;

                _debug.Add($"Set {parameters[2]} to 1 ( {parameters[0]} == {parameters[1]} )");
            }
            else
            {
                memory[parameters[2]] = 0;

                _debug.Add($"Set {parameters[2]} to ) ( {parameters[0]} != {parameters[1]} )");
            }

            return currentAddress + 4;
        }
    }
}