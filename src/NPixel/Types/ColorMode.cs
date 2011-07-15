using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace NPixel
{
    public class ColorMode
    {
        static Regex mRxHex = new Regex( "^#([0-9a-f]){3,4}$", RegexOptions.IgnoreCase | RegexOptions.Compiled );

        ColorSpace mSpace;

        double mRange1;
        double mRange2;
        double mRange3;
        double mRangeA;

        const double DEFAULT_RANGE = 256;

        public ColorMode()
            : this( ColorSpace.RGB, DEFAULT_RANGE )
        {
        }

        public ColorMode( ColorSpace space )
            : this( space, DEFAULT_RANGE )
        {
        }

        public ColorMode( ColorSpace space, double range )
            : this( space, range, range, range, range )
        {
        }

        public ColorMode( ColorSpace space, double range_1, double range_2, double range_3 )
            : this( space, range_1, range_2, range_3, DEFAULT_RANGE )
        {
        }

        public ColorMode( ColorSpace space, double range_1, double range_2, double range_3, double range_a )
        {
            mSpace  = space;
            mRange1 = range_1;
            mRange2 = range_2;
            mRange3 = range_3;
            mRangeA = range_a;
        }

        public Color MakeColor( string color )
        {
            // #F03
            // #FF0033
            // rgb( 255, 0, 51 )
            // rgb( 100%, 0%, 20% )
            // hsl( 0, 100%, 50% )
            // rgba( 255, 0, 51, 0.5 )
            // hsla( 255, 0, 51, 0.5 )
            // color names


            var hex_match = mRxHex.Match( color );

            if ( hex_match.Success )
            {
                if ( hex_match.Groups[ 1 ].Captures.Count == 3 )
                {
                    return new Color( ParseByte( hex_match.Groups[ 1 ].Captures[ 0 ].Value ), ParseByte( hex_match.Groups[ 1 ].Captures[ 1 ].Value ), ParseByte( hex_match.Groups[ 1 ].Captures[ 2 ].Value ), 255 );
                }
                else
                {
                    return new Color( ParseByte( hex_match.Groups[ 1 ].Captures[ 1 ].Value ), ParseByte( hex_match.Groups[ 1 ].Captures[ 2 ].Value ), ParseByte( hex_match.Groups[ 1 ].Captures[ 3 ].Value ), ParseByte( hex_match.Groups[ 1 ].Captures[ 0 ].Value ) );
                }
            }

            return new Color();
        }

        public Color MakeColor( string color, double alpha )
        {
            var base_color = MakeColor( color );

            base_color.A = Byte( mRangeA, alpha );

            return base_color;
        }

        public Color MakeColor( Color color, double alpha )
        {
            var base_color = color;

            base_color.A = Byte( mRangeA, alpha );

            return base_color;
        }

        public Color MakeColor( double gray )
        {
            var b = Byte( mRange3, gray );

            return NewColor( 255, b, b, b );
        }

        public Color MakeColor( double gray, double alpha )
        {
            var b = Byte( mRange3, gray );

            return NewColor( Byte( mRangeA, alpha ), b, b, b );
        }

        public Color MakeColor( double c1, double c2, double c3 )
        {
            return NewColor( 255, Byte( mRange1, c1 ), Byte( mRange2, c2 ), Byte( mRange3, c3 ) );
        }

        public Color MakeColor( double c1, double c2, double c3, double a )
        {
            return NewColor( Byte( mRangeA, a ), Byte( mRange1, c1 ), Byte( mRange2, c2 ), Byte( mRange3, c3 ) );
        }

        Color NewColor( byte a, byte r, byte g, byte b )
        {
            return new Color( r, g, b, a );
        }

        byte Byte( double range, double value )
        {
            return (byte)( (byte)( ( value / range ) * 255.0 ) & 0xFF );
        }

        byte ParseByte( string b )
        {
            return byte.Parse( b, NumberStyles.HexNumber );
        }
    }
}
