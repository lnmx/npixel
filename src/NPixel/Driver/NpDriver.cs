using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public interface NpDriver
    {
        void Background( Color color );

        void Line( double x1, double y1, double x2, double y2 );

        void Point( double x1, double y1 );

        void Triangle( double x1, double y1, double x2, double y2, double x3, double y3 );

        void Rect( double x1, double y1, double x2, double y2 );

        void Ellipse( double x1, double y1, double x2, double y2 );

        void Quad( double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4 );

        void Arc( double x1, double y1, double x2, double y2, double start_radians, double stop_radians );

        void Bezier( float x1, float y1, float cpx1, float cpy1, float cpx2, float cpy2, float x2, float y2 );

        void Text( string text, double x, double y );

        void Text( string text, double x, double y, double width, double height );

        Font CreateFont( string name, double size );

        double TextWidth( string data );

        float TextAscent();

        float TextDescent();

        void Save( string path );

        void View();

        void Clip( double x, double y, double width, double height );

        void NoClip();

        void Size( double x, double y );

        void BeginDraw();

        void EndDraw();

        void Stroke( Color c );

        void StrokeWeight( double w );

        void StrokeCap( LineCap cap );

        void StrokeJoin( LineJoin join );

        void Fill( Color c );

        void TextFont( Font font );
    }
}
