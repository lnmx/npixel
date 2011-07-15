using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void TextFont( Font font )
        {
            mStyle.TextFont = font;
        }

        public void TextFont( Font font, double size )
        {
            mStyle.TextFont = CreateFont( font, size );
        }

        public void TextSize( double size )
        {
            mStyle.TextFont = CreateFont( mStyle.TextFont, size );
        }

        public void TextAlign( TextXAlign align )
        {
            mStyle.TextXAlign = align;
            mStyle.TextYAlign = TextYAlign.Baseline;
        }

        public void TextAlign( TextXAlign x_align, TextYAlign y_align )
        {
            mStyle.TextXAlign = x_align;
            mStyle.TextYAlign = y_align;
        }

        public double TextWidth( char data )
        {
            return TextWidth( data.ToString() );
        }

        public double TextWidth( string data )
        {
            return mDriver.TextWidth( data );
        }

        public double TextAscent()
        {
            return mDriver.TextAscent();
        }

        public double TextDescent()
        {
            return mDriver.TextDescent();
        }

        public void Text( object data, double x, double y )
        {
            mDriver.Text( data.ToString(), x, y );
        }

        public void Text( object data, Vector point )
        {
            Text( data, point.X, point.Y );
        }

        public void Text( object data, Rectangle box )
        {
            Text( data, box.X, box.Y, box.Width, box.Height );
        }

        public void Text( object data, double x, double y, double width, double height )
        {
            mDriver.Text( data.ToString(), x, y, width, height );
        }
    }
}
