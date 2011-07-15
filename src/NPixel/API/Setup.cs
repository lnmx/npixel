using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void Size( Vector size )
        {
            Size( size.X, size.Y );
        }

        public void Size( double x, double y )
        {
            mSize = Vector( x, y );

            mDriver.Size( x, y );
        }

        public void BeginDraw()
        {
            mDriver.BeginDraw();
        }

        public void EndDraw()
        {
            mDriver.EndDraw();
        }
    }
}
