using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPixel.Driver;

namespace NPixel
{
    public class Drawing
        : NpGraphics
    {
        public Drawing()
            : base( new GdiDriver() )
        {
        }

        public void Run()
        {
            Setup();

            BeginDraw();

            Draw();

            EndDraw();
        }

        protected virtual void Setup()
        {
        }

        protected virtual void Draw()
        {
        }
    }
}
