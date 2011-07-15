using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        Style mStyle = new Style();

        public void ResetStyle()
        {
            mStyle = new Style();
        }

        public void PushStyle()
        {
        }

        public void PopStyle()
        {
        }
    }
}
