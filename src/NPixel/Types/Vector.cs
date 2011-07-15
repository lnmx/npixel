using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public struct Vector
    {
        public double X;
        public double Y;

        public Vector( double x, double y )
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format( "( {0:0.000}, {1:0.000} ) mag={2:0.000}", X, Y, Mag );
        }

        public void Set( double x, double y )
        {
            this.X = x;
            this.Y = y;
        }

        public void Set( Vector v )
        {
            X = v.X;
            Y = v.Y;
        }

        public void Set( double[] data )
        {
            X = data[ 0 ];
            Y = data[ 1 ];
        }

        public Vector Get()
        {
            return this;
        }

        public static Vector Add( Vector a, Vector b )
        {
            var c = a;

            c.Add( b );

            return c;
        }

        public static Vector operator +( Vector a, Vector b )
        {
            return Add( a, b );
        }

        public void Add( Vector v )
        {
            X += v.X;
            Y += v.Y;
        }

        public static Vector Sub( Vector a, Vector b )
        {
            var c = a;

            c.Sub( b );

            return c;
        }

        public static Vector operator -( Vector a, Vector b )
        {
            return Sub( a, b );
        }

        public void Sub( Vector v )
        {
            X -= v.X;
            Y -= v.Y;
        }

        public static Vector Mult( Vector a, Vector b )
        {
            Vector c = a;

            a.Mult( b );

            return c;
        }

        public static Vector operator *( Vector a, Vector b )
        {
            return Mult( a, b );
        }

        public void Mult( Vector v )
        {
            X *= v.X;
            Y *= v.Y;
        }

        public void Mult( double m )
        {
            X *= m;
            Y *= m;
        }

        public static Vector Div( Vector a, Vector b )
        {
            Vector c = a;

            a.Div( b );

            return c;
        }

        public static Vector operator /( Vector a, Vector b )
        {
            return Div( a, b );
        }

        public void Div( Vector v )
        {
            X /= v.X;
            Y /= v.Y;
        }

        public void Div( double m )
        {
            X /= m;
            Y /= m;
        }

        public double Mag
        {
            get
            {
                return (double)Math.Sqrt( X * X + Y * Y );
            }
        }

        public void Normalize()
        {
            var m = Mag;

            if ( m == 0 )
            {
                return;
            }

            Div( m );
        }

        public double Dist( Vector v )
        {
            return Dist( this, v );
        }

        public static double Dist( Vector a, Vector b )
        {
            var dx = a.X - b.X;
            var dy = a.Y - b.Y;

            return (double)Math.Sqrt( dx * dx + dy * dy );
        }

        public double Dot( Vector v )
        {
            return Dot( this, v );
        }

        public static double Dot( Vector a, Vector b )
        {
            return ( a.X * b.X ) + ( a.Y * b.Y );
        }

        public void Limit( double limit )
        {
            var m = Mag;

            if ( m > limit )
            {
                Normalize();

                Mult( new Vector { X = limit, Y = limit } );
            }
        }

        public static Vector Limit( Vector v, double limit )
        {
            var c = v;

            c.Limit( limit );

            return c;
        }

        public static double AngleBetween( Vector v1, Vector v2 )
        {
            return (double)Math.Acos( Dot( v1, v2 ) / ( v1.Mag * v2.Mag ) );
        }

        public double Heading2D()
        {
            return (double)( -Math.Atan2( -Y, X ) );
        }
    }
}
