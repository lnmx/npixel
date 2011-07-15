using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        ColorMode mColorMode;

        NpDriver mDriver;

        Vector mSize;

        public NpGraphics( NpDriver driver )
        {
            mDriver = driver;
        }

        public double Height { get { return mSize.Y; } }
        public double Width { get { return mSize.X; } }
    }
}
