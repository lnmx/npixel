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
            mColorMode = new ColorMode( ColorSpace.RGB, 1, 1, 1 );
            Fill( Colors.Black );
            Stroke( Colors.Black );
            TextFont( CreateFont( "Arial", 12 ) );
        }

        public double Height { get { return mSize.Y; } }
        public double Width { get { return mSize.X; } }

        public Rectangle Bounds { get { return new Rectangle( 0, 0, mSize.X, mSize.Y ); } }
    }
}
