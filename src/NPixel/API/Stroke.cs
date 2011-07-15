using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void NoStroke()
        {
            Stroke( new Color() );
        }

        public void Stroke( string color )
        {
            Stroke( MakeColor( color ) );
        }

        public void Stroke( string color, double alpha )
        {
            Stroke( MakeColor( color, alpha ) );
        }

        public void Stroke( double gray )
        {
            Stroke( MakeColor( gray ) );
        }

        public void Stroke( double gray, double alpha )
        {
            Stroke( MakeColor( gray, alpha ) );
        }

        public void Stroke( double value1, double value2, double value3 )
        {
            Stroke( MakeColor( value1, value2, value3 ) );
        }

        public void Stroke( double value1, double value2, double value3, double alpha )
        {
            Stroke( MakeColor( value1, value2, value3, alpha ) );
        }

        public void Stroke( Color c, double alpha )
        {
            Stroke( MakeColor( c, alpha ) );
        }

        public void Stroke( Color c )
        {
            mStyle.Stroke = c;

            mDriver.Stroke( c );
        }

        public void StrokeWeight( double w )
        {
            mStyle.StrokeWeight = w;

            mDriver.StrokeWeight( w );
        }

        public void StrokeCap( LineCap cap )
        {
            mStyle.LineCap = cap;

            mDriver.StrokeCap( cap );
        }

        public void StrokeJoin( LineJoin join )
        {
            mStyle.LineJoin = join;

            mDriver.StrokeJoin( join );
        }
    }
}
