using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot.Classes
{
    [Serializable]
    public class MandelbrotCoordinates
    {
        public double XStart { get; set; } = 0.0;
        public double XEnd { get; set; } = 0.0;
        public double YStart { get; set; } = 0.0;
        public double YEnd { get; set; } = 0.0;

        public MandelbrotCoordinates() 
        {
            XStart = -2.0;
            XEnd = 1.0;
            YStart = -1.24;
            YEnd = 1.24;
        }

        public MandelbrotCoordinates(double xStart, double xEnd, double yStart, double yEnd)
        {
            XStart = xStart;
            XEnd = xEnd;
            YStart = yStart;
            YEnd = yEnd;
        }

        public double Width => Math.Sqrt(Math.Pow(Math.Abs(XEnd - XStart), 2.0));

        public double Height => Math.Sqrt(Math.Pow(Math.Abs(YEnd - YStart), 2.0));

        public override string ToString()
        {
            return string.Format("X start:{0} end:{1} Y start:{2} end:{3} Width:{4} Height:{5}",
                XStart, XEnd, YStart, YEnd, Width, Height);
        }
    }
}
