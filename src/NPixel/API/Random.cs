using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPixel
{
    public partial class NpGraphics
    {
        Random mRandom = new Random();

        public double Random( double high )
        {
            return mRandom.NextDouble() * high;
        }

        public double Random( double low, double high )
        {
            return low + mRandom.NextDouble() * ( high - low );
        }

        public void RandomSeed( int seed )
        {
            mRandom = new Random( seed );
        }
    }
}
