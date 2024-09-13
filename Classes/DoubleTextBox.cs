using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot.Classes
{
    public class DoubleTextBox : ValidatingTextBox
    {
        public double Value
        { 
            get => double.Parse(Text);
            set => Text = value.ToString();
        }

        protected override void OnTextValidating(object sender, TextValidatingEventArgs e)
        {
            if (e.NewText == "") return;
            e.Cancel = !double.TryParse(e.NewText, out double i);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (string.IsNullOrEmpty(Text)) Value = 0.0;

            base.OnLeave(e);
        }
    }
}
