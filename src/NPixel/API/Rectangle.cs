using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public Rectangle MakeRect( double x1, double y1, double x2, double y2 )
        {
            return MakeRect( mStyle.RectMode, x1, y1, x2, y2 );
        }

        public Rectangle MakeRect( RectangleMode mode, double x1, double y1, double x2, double y2 )
        {
            switch ( mode )
            {
                default:
                case RectangleMode.Corner:
                    return new Rectangle( x1, y1, x2, y2 );

                case RectangleMode.Corners:
                    var min_x = Math.Min( x1, x2 );
                    var max_x = Math.Max( x1, x2 );
                    var min_y = Math.Min( y1, y2 );
                    var max_y = Math.Max( y1, y2 );
                    return new Rectangle( min_x, min_y, max_x - min_x, max_y - min_y );

                case RectangleMode.Center:
                    return new Rectangle( x1 - x2 / 2f, y1 - y2 / 2f, x2, y2 );

                case RectangleMode.Radius:
                    return new Rectangle( x1 - x2, y1 - y2, x2 * 2f, y2 * 2f );
            }

        }
    }
}
