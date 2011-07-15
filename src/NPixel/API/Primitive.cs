using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void Point( double x1, double y1 )
        {
            mDriver.Point( x1, y1 );
        }

        public void Line( double x1, double y1, double x2, double y2 )
        {
            mDriver.Line( x1, y1, x2, y2 );
        }

        public void Triangle( double x1, double y1, double x2, double y2, double x3, double y3 )
        {
            mDriver.Triangle( x1, y1, x2, y2, x3, y3 );
        }

        public void RectMode( RectangleMode mode )
        {
            mStyle.RectMode = mode;
        }

        public void Rect( Rectangle rect )
        {
            mDriver.Rect( rect.X, rect.Y, rect.Right, rect.Bottom );
        }

        public void Rect( double x1, double y1, double x2, double y2 )
        {
            Rect( MakeRect( mStyle.RectMode, x1, y1, x2, y2 ) );
        }

        public void EllipseMode( RectangleMode mode )
        {
            mStyle.EllipseMode = mode;
        }

        public void Ellipse( Rectangle rect )
        {
            mDriver.Ellipse( rect.X, rect.Y, rect.Right, rect.Bottom );
        }

        public void Ellipse( double x1, double y1, double x2, double y2 )
        {
            Ellipse( MakeRect( mStyle.EllipseMode, x1, y1, x2, y2 ) );
        }

        public void Quad( Vector p1, Vector p2, Vector p3, Vector p4 )
        {
            Quad( p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, p4.X, p4.Y );
        }

        public void Quad( double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4 )
        {
            mDriver.Quad( x1, y1, x2, y2, x3, y3, x4, y4 );
        }

        public void ArcMode( RectangleMode mode )
        {
            mStyle.ArcMode = mode;
        }

        public void Arc( Rectangle rect, double start_radians, double stop_radians )
        {
            mDriver.Arc( rect.X, rect.Y, rect.Right, rect.Bottom, start_radians, stop_radians );
        }

        public void Arc( double x1, double y1, double x2, double y2, double start_radians, double stop_radians )
        {
            Arc( MakeRect( mStyle.ArcMode, x1, y1, x2, y2 ), start_radians, stop_radians );
        }

        public void Bezier( float x1, float y1, float cpx1, float cpy1, float cpx2, float cpy2, float x2, float y2 )
        {
            mDriver.Bezier( x1, y1, cpx1, cpy1, cpx2, cpy2, x2, y2 );
        }

    }
}
