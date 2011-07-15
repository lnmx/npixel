using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        public void Save( string path )
        {
            mDriver.Save( path );
        }

        public void View()
        {
            mDriver.View();
        }
    }
}
