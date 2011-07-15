using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        Font CreateFont( string name, double size )
        {
            return mDriver.CreateFont( name, size );
        }

        Font CreateFont( Font font, double size )
        {
            return mDriver.CreateFont( font.Name, size );
        }
    }
}
