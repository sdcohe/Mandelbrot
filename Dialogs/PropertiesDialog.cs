using Mandelbrot.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot.Dialogs
{
    public partial class PropertiesDialog : Form
    {
        private MandelbrotSettings settings = new MandelbrotSettings();

        public PropertiesDialog()
        {
            InitializeComponent();
        }

        private void PropertiesDialog_Load(object sender, EventArgs e)
        {
            IterationsTextBox.Value = settings.NumberOfIterations;
            PaletteMultiplierTextBox.Value = (Decimal)settings.PaletteMultiplier;
            XStartTextBox.Text = settings.StartCoordinates.XStart.ToString();
            XEndTextBox.Text = settings.StartCoordinates.XEnd.ToString();
            YStartTextBox.Text = settings.StartCoordinates.YStart.ToString();
            YEndTextBox.Text = settings.StartCoordinates.YEnd.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            settings.NumberOfIterations = (int)IterationsTextBox.Value;
            settings.PaletteMultiplier = (float)PaletteMultiplierTextBox.Value;
            settings.StartCoordinates =
                new MandelbrotCoordinates(XStartTextBox.Value, XEndTextBox.Value, YStartTextBox.Value, YEndTextBox.Value);
            settings.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            IterationsTextBox.Value = 128;
            PaletteMultiplierTextBox.Value = 1.5M;
            XStartTextBox.Value = -2.0;
            XEndTextBox.Value = 1.0;
            YStartTextBox.Value = -1.24;
            YEndTextBox.Value = 1.24;
        }
    }
}
