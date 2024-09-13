using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot.Classes
{
    internal class ColorUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paletteSize"></param>
        /// <returns></returns>
        public static Color[] BuildHSVColorPalette(int paletteSize, float paletteMultiplier)
        {
            Color[] palette = new Color[paletteSize + 1];
            for (int i = 0; i < paletteSize; i++)
            {
                //palette[i] = ColorUtility.ColorFromHSV(i * (360.0 / paletteSize), 1.0, 1.0);
                palette[i] = ColorFromHSV(Math.Pow(i * (360.0 / paletteSize), paletteMultiplier) % 360.0, 1.0, 1.0);
            }
            palette[paletteSize] = Color.Black;
            //DisplayColorPalette(palette);
            return palette;
        }

        /// <summary>
        /// Method used for debugging color palette functions
        /// </summary>
        /// <param name="palette">An array of Color objects to display</param>
        public static void DisplayColorPalette(Color[] palette)
        {
            int idx = 0;
            foreach (Color color in palette)
            {
                Debug.WriteLine(string.Format("Index:{0} R:{1} G:{2} B:{3}", idx++, color.R, color.G, color.B));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="value"></param>
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = max == 0 ? 0 : 1d - 1d * min / max;
            value = max / 255d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hue">0.0 - 360.0</param>
        /// <param name="saturation">0.0 - 1.0</param>
        /// <param name="value">0.0 - 1.0</param>
        /// <returns>The generated color</returns>
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }
}
