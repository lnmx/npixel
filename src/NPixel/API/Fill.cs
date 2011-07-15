using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void NoFill()
        {
            Fill( new Color() );
        }

        public void Fill( string color )
        {
            Fill( MakeColor( color ) );
        }

        public void Fill( string color, double alpha )
        {
            Fill( MakeColor( color, alpha ) );
        }

        public void Fill( double gray )
        {
            Fill( MakeColor( gray ) );
        }

        public void Fill( double gray, double alpha )
        {
            Fill( MakeColor( gray, alpha ) );
        }

        public void Fill( double value1, double value2, double value3 )
        {
            Fill( MakeColor( value1, value2, value3 ) );
        }

        public void Fill( double value1, double value2, double value3, double alpha )
        {
            Fill( MakeColor( value1, value2, value3, alpha ) );
        }

        public void Fill( Color c, double alpha )
        {
            Fill( MakeColor( c, alpha ) );
        }

        public void Fill( Color c )
        {
            mStyle.Fill = c;

            mDriver.Fill( c );
        }
    }
}
