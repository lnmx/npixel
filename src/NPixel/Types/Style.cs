using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public class Style
    {
        public Style()
        {
            Fill = new Color( 255, 255, 255, 255 );

            Stroke = new Color( 0, 0, 0, 255 );
            StrokeWeight = 1;
            LineCap      = LineCap.Flat;
            LineJoin     = LineJoin.Miter;

            RectMode     = RectangleMode.Corners;
            EllipseMode  = RectangleMode.Corners;
            ArcMode      = RectangleMode.Corners;

            TextFont     = new Font( "Arial", 10 );
            TextXAlign   = TextXAlign.Left;
            TextYAlign   = TextYAlign.Baseline;
        }

        public Color Fill { get; set; }

        public Color Stroke { get; set; }
        public double StrokeWeight { get; set; }
        public LineCap LineCap { get; set; }
        public LineJoin LineJoin { get; set; }

        public RectangleMode RectMode { get; set; }
        public RectangleMode EllipseMode { get; set; }
        public RectangleMode ArcMode { get; set; }

        public Font TextFont { get; set; }
        public TextXAlign TextXAlign { get; set; }
        public TextYAlign TextYAlign { get; set; }
    }
}
