﻿//
//  WindowDecoder.cs
//
//  Author:
//       Benito Palacios Sánchez <benito356@gmail.com>
//
//  Copyright (c) 2015 Benito Palacios Sánchez
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using Xdelta.Instructions;

namespace Xdelta
{
    public class WindowDecoder
    {
        private Stream input;
        private Stream output;
        private CodeTable codeTable;

        public WindowDecoder(Stream input, Stream output)
        {
            this.input  = input;
            this.output = output;
            this.codeTable = CodeTable.Default;
        }

        public void Decode(Window window)
        {
            while (!window.Instructions.Eof) {
                byte codeIndex = window.Instructions.ReadByte();
                Instruction[] instructions = codeTable.GetInstructions(codeIndex);

                instructions[0].Read(window);
                instructions[0].Decode(input, output);

                instructions[1].Read(window);
                instructions[1].Decode(input, output);
            }

            // TODO: Perfom checksum
        }
    }
}

