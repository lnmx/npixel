using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public class Font
    {
        public Font( string name, double size )
        {
            Name = name;
            Size = size;
        }

        public string Name { get; private set; }
        public double Size { get; private set; }
    }
}
