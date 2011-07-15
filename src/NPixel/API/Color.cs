using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void ColorMode( ColorSpace space )
        {
            mColorMode = new ColorMode( space );
        }

        public void ColorMode( ColorSpace space, double range )
        {
            mColorMode = new ColorMode( space, range );
        }

        public void ColorMode( ColorSpace space, double range1, double range2, double range3 )
        {
            mColorMode = new ColorMode( space, range1, range2, range3 );
        }

        public void ColorMode( ColorSpace space, double range1, double range2, double range3, double range_a )
        {
            mColorMode = new ColorMode( space, range1, range2, range3, range_a );
        }

        public Color MakeColor( Color color, double alpha )
        {
            return mColorMode.MakeColor( color, alpha );
        }

        public Color MakeColor( string color )
        {
            return mColorMode.MakeColor( color );
        }

        public Color MakeColor( string color, double alpha )
        {
            return mColorMode.MakeColor( color, alpha );
        }

        public Color MakeColor( double gray )
        {
            return mColorMode.MakeColor( gray );
        }

        public Color MakeColor( double gray, double alpha )
        {
            return mColorMode.MakeColor( gray, alpha );
        }

        public Color MakeColor( double value1, double value2, double value3 )
        {
            return mColorMode.MakeColor( value1, value2, value3 );
        }

        public Color MakeColor( double value1, double value2, double value3, double value_a )
        {
            return mColorMode.MakeColor( value1, value2, value3, value_a );
        }
    }
}
