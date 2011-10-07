using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public const double PI         = Math.PI;
        public const double TWO_PI     = PI * 2.0;
        public const double HALF_PI    = PI / 2.0;
        public const double THIRD_PI   = PI / 3.0;
        public const double QUARTER_PI = PI / 4.0;

        public const double DEGREES_TO_RADIANS = ( PI / 180.0 );
        public const double RADIANS_TO_DEGREES = ( 180.0 / PI );

        public Vector Vector( double x, double y )
        {
            return new Vector( x, y );
        }

        public double Degrees( double radians )
        {
            return radians * RADIANS_TO_DEGREES;
        }

        public double Radians( double degrees )
        {
            return degrees * DEGREES_TO_RADIANS;
        }

        public double Abs( double n )
        {
            return Math.Abs( n );
        }

        public double Min( double a, double b )
        {
            return Math.Min( a, b );
        }

        public double Max( double a, double b )
        {
            return Math.Max( a, b );
        }

        public double Ceil( double n )
        {
            return Math.Ceiling( n );
        }

        public double Floor( double n )
        {
            return Math.Floor( n );
        }

        public double Round( double n )
        {
            return Math.Round( n, 0 );
        }

        public double Dist( double x1, double y1, double x2, double y2 )
        {
            return Vector( x1, y1 ).Dist( Vector( x2, y2 ) );
        }

        public double Lerp( double value1, double value2, double amt )
        {
            return value1 + amt * ( value2 - value1 );
        }

        public double Log( double n )
        {
            return Math.Log( n );
        }

        public double Mag( double x, double y )
        {
            return Vector( x, y ).Mag;
        }

        public double Map( double value, double low1, double high1, double low2, double high2 )
        {
            return low2 + ( value - low1 ) * ( high2 - low2 );
        }

        public double Norm( double value, double low, double high )
        {
            return Map( value, low, high, 0, 1 );
        }

        public double Pow( double value, double exp )
        {
            return Math.Pow( value, exp );
        }

        public double Square( double n )
        {
            return n * n;
        }

        public double Sqrt( double n )
        {
            return Math.Sqrt( n );
        }

        public double Exp( double value )
        {
            return Math.Exp( value );
        }

        public double Atan2( double y, double x )
        {
            return Math.Atan2( y, x );
        }

        public double Sin( double n )
        {
            return Math.Sin( n );
        }

        public double Cos( double n )
        {
            return Math.Cos( n );
        }

        public double Constrain( double value, double min, double max )
        {
            if ( value < min ) return min;
            if ( value > max ) return max;
            return value;
        }
    }
}
