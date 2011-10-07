using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel.Driver
{
    public class GdiDriver : NpDriver
    {
        bool mIsDrawing;
        System.Drawing.Bitmap mBuffer;
        System.Drawing.Graphics mGraphics;
        System.Drawing.Size mSize;

        System.Drawing.Color mStroke;
        System.Drawing.Drawing2D.LineCap mStrokeCap;
        System.Drawing.Drawing2D.LineJoin mStrokeJoin;
        double mStrokeWeight;

        System.Drawing.Color mFill;
        System.Drawing.Brush mFillBrush;

        System.Drawing.Pen mStrokePen;

        System.Drawing.Font mTextFont;

        Stack<System.Drawing.Drawing2D.Matrix> mTransformStack = new Stack<System.Drawing.Drawing2D.Matrix>();

        public GdiDriver()
        {
            mSize = new System.Drawing.Size( 100, 100 );

            mTransformStack.Push( new System.Drawing.Drawing2D.Matrix() );
        }

        public GdiDriver( System.Drawing.Graphics g )
            : this()
        {
            mSize = new System.Drawing.Size( (int)g.VisibleClipBounds.Width, (int)g.VisibleClipBounds.Height );

            mGraphics = g;
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

        public void Text( string text, double x, double y, TextXAlign x_align, TextYAlign y_align )
        {
            var size = mGraphics.MeasureString( text, mTextFont );

            switch ( x_align )
            {
                case TextXAlign.Left:
                    x -= size.Width;
                    break;
                case TextXAlign.Center:
                    x -= size.Width / 2f;
                    break;
                case TextXAlign.Right:
                    break;
                default:
                    break;
            }

            switch ( y_align )
            {
                case TextYAlign.Top:
                    break;
                case TextYAlign.Center:
                    y -= size.Height / 2f;
                    break;
                case TextYAlign.Baseline:
                    y -= size.Height * 0.8f; // TODO baseline
                    break;
                case TextYAlign.Bottom:
                    y -= size.Height;
                    break;
                default:
                    break;
            }

            mGraphics.DrawString( text, mTextFont, mFillBrush, MakePoint( (float)x, (float)y ) );
        }

        public void Text( string text, double x, double y, double width, double height, TextXAlign x_align, TextYAlign y_align )
        {
            var size = mGraphics.MeasureString( text, mTextFont, MakeSize( (float)width, (float)height ) );

            switch ( x_align )
            {
                case TextXAlign.Left:
                    x -= size.Width;
                    break;
                case TextXAlign.Center:
                    x -= size.Width / 2f;
                    break;
                case TextXAlign.Right:
                    break;
                default:
                    break;
            }

            switch ( y_align )
            {
                case TextYAlign.Top:
                    break;
                case TextYAlign.Center:
                    y -= size.Height / 2f;
                    break;
                case TextYAlign.Baseline:
                    y -= size.Height * 0.8f; // TODO baseline
                    break;
                case TextYAlign.Bottom:
                    y -= size.Height;
                    break;
                default:
                    break;
            }

            // TODO align
            mGraphics.DrawString( text, mTextFont, mFillBrush, MakePoint( (float)x, (float)y ) );
        }

        public void TextFont( Font font )
        {
            mTextFont = new System.Drawing.Font( font.Name, (float)font.Size );
        }

        public Font CreateFont( string name, double size )
        {
            return new Font( name, size );
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
            mGraphics.Clip = new System.Drawing.Region( new System.Drawing.Rectangle( (int)x, (int)y, (int)width, (int)height ) );
        }

        public void NoClip()
        {
            mGraphics.ResetClip();
        }

        public void Size( double x, double y )
        {
            mSize = new System.Drawing.Size( (int)x, (int)y );

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

            if ( null == mGraphics )
            {
                mBuffer = new System.Drawing.Bitmap( mSize.Width, mSize.Height );

                mGraphics = System.Drawing.Graphics.FromImage( mBuffer );
            }

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
            mStrokePen = new System.Drawing.Pen( mStroke, (float)mStrokeWeight )
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
            mFillBrush = new System.Drawing.SolidBrush( mFill );
        }

        bool HasStroke
        {
            get { return mStroke.A > 0; }
        }

        bool HasFill
        {
            get { return mFill.A > 0; }
        }

        System.Drawing.PointF MakePoint( double x, double y )
        {
            return new System.Drawing.PointF( (float)x, (float)y );
        }

        System.Drawing.SizeF MakeSize( double x, double y )
        {
            return new System.Drawing.SizeF( (float)x, (float)y );
        }

        System.Drawing.Color ConvertColor( Color color )
        {
            return System.Drawing.Color.FromArgb( color.A, color.R, color.G, color.B );
        }


        const System.Drawing.Drawing2D.MatrixOrder TRANSFORM_ORDER = System.Drawing.Drawing2D.MatrixOrder.Prepend;

        public void Translate( double x, double y )
        {
            mGraphics.TranslateTransform( (float)x, (float)y, TRANSFORM_ORDER );
        }

        public void Rotate( double radians )
        {
            mGraphics.RotateTransform( (float)( radians * NpGraphics.RADIANS_TO_DEGREES ), TRANSFORM_ORDER );
        }

        public void Scale( double x_factor, double y_factor )
        {
            mGraphics.ScaleTransform( (float)x_factor, (float)y_factor, TRANSFORM_ORDER );
        }

        public void ResetTransform()
        {
            mGraphics.ResetTransform();
        }

        public void PushTransform()
        {
            mTransformStack.Push( mGraphics.Transform );
        }

        public void PopTransform()
        {
            mGraphics.Transform = mTransformStack.Pop();
        }

        public void Smooth()
        {
            mGraphics.SmoothingMode      = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            mGraphics.TextRenderingHint  = System.Drawing.Text.TextRenderingHint.AntiAlias;
            mGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            mGraphics.InterpolationMode  = System.Drawing.Drawing2D.InterpolationMode.High;
            mGraphics.PixelOffsetMode    = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        }
    }
}
