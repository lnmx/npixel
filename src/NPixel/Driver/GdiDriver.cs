﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NPixel.Driver
{
    public class GdiDriver : NpDriver
    {
        bool mIsDrawing;
        Bitmap mBuffer;
        Graphics mGraphics;
        Size mSize;

        System.Drawing.Color mStroke;
        System.Drawing.Drawing2D.LineCap mStrokeCap;
        System.Drawing.Drawing2D.LineJoin mStrokeJoin;
        double mStrokeWeight;

        System.Drawing.Color mFill;
        System.Drawing.Brush mFillBrush;

        System.Drawing.Pen mStrokePen;

        public GdiDriver()
        {
            mSize = new Size( 100, 100 );
        }

        public void Background( Color color )
        {
            mGraphics.Clear( ConvertColor( color ) );
        }

        public void Line( double x1, double y1, double x2, double y2 )
        {
            mGraphics.DrawLine( mStrokePen, (float)x1, (float)y1, (float)x2, (float)y2 );
        }

        public void Point( double x1, double y1 )
        {
            if ( HasFill )
            {
                mGraphics.FillRectangle( mFillBrush, (float)x1, (float)y1, 1f, 1f );
            }
        }

        public void Triangle( double x1, double y1, double x2, double y2, double x3, double y3 )
        {
            var points = new[]
                {
                    MakePoint( x1, y1 ), MakePoint( x2, y2 ), 
                    MakePoint( x2, y2 ), MakePoint( x3, y3 ), 
                };

            if ( HasFill )
            {
                mGraphics.FillPolygon( mFillBrush, points );
            }

            if ( HasStroke )
            {
                mGraphics.DrawPolygon( mStrokePen, points );
            }
        }

        public void Rect( double x1, double y1, double x2, double y2 )
        {
            if ( HasFill )
            {
                mGraphics.FillRectangle( mFillBrush, (float)x1, (float)y1, (float)( x2 - x1 ), (float)( y2 - y1 ) );
            }

            if ( HasStroke )
            {
                mGraphics.DrawRectangle( mStrokePen, (float)x1, (float)y1, (float)( x2 - x1 ), (float)( y2 - y1 ) );
            }
        }

        public void Ellipse( double x1, double y1, double x2, double y2 )
        {
            if ( HasFill )
            {
                mGraphics.FillEllipse( mFillBrush, (float)x1, (float)y1, (float)( x2 - x1 ), (float)( y2 - y1 ) );
            }

            if ( HasStroke )
            {
                mGraphics.DrawEllipse( mStrokePen, (float)x1, (float)y1, (float)( x2 - x1 ), (float)( y2 - y1 ) );
            }
        }

        public void Quad( double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4 )
        {
            var points = new[] { 
                MakePoint( x1, y1 ), MakePoint( x2, y2 ), 
                MakePoint( x2, y2 ), MakePoint( x3, y3 ), 
                MakePoint( x3, y3 ), MakePoint( x4, y4 ),
            };

            if ( HasFill )
            {
                mGraphics.FillPolygon( mFillBrush, points );
            }

            if ( HasStroke )
            {
                mGraphics.DrawPolygon( mStrokePen, points );
            }
        }

        public void Arc( double x1, double y1, double x2, double y2, double start_radians, double stop_radians )
        {
            throw new NotImplementedException();
        }

        public void Bezier( float x1, float y1, float cpx1, float cpy1, float cpx2, float cpy2, float x2, float y2 )
        {
            throw new NotImplementedException();
        }

        public void Text( string text, double x, double y )
        {
            throw new NotImplementedException();
        }

        public void Text( string text, double x, double y, double width, double height )
        {
            throw new NotImplementedException();
        }

        public Font CreateFont( string name, double size )
        {
            throw new NotImplementedException();
        }

        public double TextWidth( string data )
        {
            throw new NotImplementedException();
        }

        public float TextAscent()
        {
            throw new NotImplementedException();
        }

        public float TextDescent()
        {
            throw new NotImplementedException();
        }

        public void Save( string path )
        {
            mBuffer.Save( path );
        }

        public void View()
        {
            throw new NotImplementedException();
        }

        public void Clip( double x, double y, double width, double height )
        {
            mGraphics.Clip = new Region( new System.Drawing.Rectangle( (int)x, (int)y, (int)width, (int)height ) );
        }

        public void NoClip()
        {
            mGraphics.ResetClip();
        }

        public void Size( double x, double y )
        {
            mSize = new Size( (int)x, (int)y );

            if ( mIsDrawing )
            {
                EndDraw();
                BeginDraw();
            }
        }

        public void BeginDraw()
        {
            if ( mIsDrawing )
            {
                return;
            }

            mBuffer = new Bitmap( mSize.Width, mSize.Height );

            mGraphics = Graphics.FromImage( mBuffer );

            mIsDrawing = true;
        }

        public void EndDraw()
        {
            if ( !mIsDrawing )
            {
                return;
            }

            mGraphics.Dispose();

            mIsDrawing = false;
        }


        public void Stroke( Color c )
        {
            mStroke = ConvertColor( c );

            UpdateStroke();
        }

        public void StrokeWeight( double w )
        {
            mStrokeWeight = w;

            UpdateStroke();
        }

        public void StrokeCap( LineCap cap )
        {
            mStrokeCap = (System.Drawing.Drawing2D.LineCap)cap;

            UpdateStroke();
        }

        public void StrokeJoin( LineJoin join )
        {
            mStrokeJoin = (System.Drawing.Drawing2D.LineJoin)join;

            UpdateStroke();
        }


        void UpdateStroke()
        {
            mStrokePen = new Pen( mStroke, (float)mStrokeWeight )
            {
                StartCap = mStrokeCap,
                EndCap   = mStrokeCap,
                LineJoin = mStrokeJoin,
            };
        }

        public void Fill( Color c )
        {
            mFill = ConvertColor( c );

            UpdateFill();
        }

        void UpdateFill()
        {
            mFillBrush = new SolidBrush( mFill );
        }

        bool HasStroke
        {
            get { return mStroke.A > 0; }
        }

        bool HasFill
        {
            get { return mFill.A > 0; }
        }

        PointF MakePoint( double x, double y )
        {
            return new PointF( (float)x, (float)y );
        }

        System.Drawing.Color ConvertColor( Color color )
        {
            return System.Drawing.Color.FromArgb( color.A, color.R, color.G, color.B );
        }
    }
}
