using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public struct Color
    {
        public byte A;
        public byte R;
        public byte G;
        public byte B;

        public Color( byte r, byte g, byte b )
            : this( r, g, b, 255 )
        {
        }

        public Color( byte r, byte g, byte b, byte a )
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
    }
}
