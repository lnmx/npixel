using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void NoClip()
        {
            mDriver.NoClip();
        }

        public void Clip( Rectangle rect )
        {
            Clip( rect.X, rect.Y, rect.Width, rect.Height );
        }

        public void Clip( double x, double y, double width, double height )
        {
            mDriver.Clip( x, y, width, height );
        }
    }
}
