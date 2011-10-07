using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public struct Rectangle
    {
        public double X;
        public double Y;
        public double Width;
        public double Height;

        public double Top { get { return Y; } }
        public double Bottom { get { return Y + Height; } }
        public double Left { get { return X; } }
        public double Right { get { return X + Width; } }

        public Vector Size { get { return new Vector( Width, Height ); } }
        public Vector Position { get { return new Vector( X, Y ); } }

        public Rectangle( double x, double y, double width, double height )
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle( Vector offset, Vector size )
        {
            X = offset.X;
            Y = offset.Y;
            Width = size.X;
            Height = size.Y;
        }
    }
}
