using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void Translate( Vector offset )
        {
            Translate( offset.X, offset.Y );
        }

        public void Translate( double x, double y )
        {
            mDriver.Translate( x, y );
        }

        public void Rotate( double radians )
        {
            mDriver.Rotate( radians );
        }

        public void Scale( Vector factor )
        {
            Scale( factor.X, factor.Y );
        }

        public void Scale( double factor )
        {
            Scale( factor, factor );
        }

        public void Scale( double x_factor, double y_factor )
        {
            mDriver.Scale( x_factor, y_factor );
        }

        public void PushTransform()
        {
            mDriver.PushTransform();
        }

        public void PopTransform()
        {
            mDriver.PopTransform();
        }

        public void ResetTransform()
        {
            mDriver.ResetTransform();
        }
    }
}
