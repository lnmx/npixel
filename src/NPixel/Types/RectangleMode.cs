using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public enum RectangleMode
    {
        /// <summary>
        /// x1 and y1 are the top-left corner, x2 and y2 are width and height
        /// </summary>
        Corner,

        /// <summary>
        /// x1/y1 and x2/y2 are opposite corners
        /// </summary>
        Corners,

        /// <summary>
        /// x1/y1 is the center, x2/y2 are width and height
        /// </summary>
        /// 
        Center,

        /// <summary>
        /// x1/y1 is the center, x2/y2 are half width and half height
        /// </summary>
        /// 
        Radius
    }
}
