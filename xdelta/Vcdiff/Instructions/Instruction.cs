﻿//
//  Instruction.cs
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
using Xdelta;

namespace Xdelta.Instructions
{
    public abstract class Instruction
    {
        public uint Size {
            get;
            private set;
        }

        public uint Mode {
            get;
            private set;
        }

        protected abstract void ReadDataAndAddress(Window window);
        public abstract void Decode(Stream input, Stream output);

        public void Read(Window window)
        {
            // TODO: Depending on the entry, read size and mode
            ReadDataAndAddress(window);
        }
    }
}
