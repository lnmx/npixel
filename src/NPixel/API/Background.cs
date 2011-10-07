using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void Background( string color )
        {
            Background( MakeColor( color ) );
        }

        public void Background( string color, double alpha )
        {
            Background( MakeColor( color, alpha ) );
        }

        public void Background( double gray )
        {
            Background( MakeColor( gray ) );
        }

        public void Background( double gray, double alpha )
        {
            Background( MakeColor( gray, alpha ) );
        }

        public void Background( double value1, double value2, double value3 )
        {
            Background( MakeColor( value1, value2, value3 ) );
        }

        public void Background( double value1, double value2, double value3, double alpha )
        {
            Background( MakeColor( value1, value2, value3, alpha ) );
        }

        public void Background( Color color )
        {
            mDriver.Background( color );
        }
    }
}
