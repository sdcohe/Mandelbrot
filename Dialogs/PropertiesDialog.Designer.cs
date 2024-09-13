using Mandelbrot.Classes;

namespace Mandelbrot.Dialogs
{
    partial class PropertiesDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OKButton = new Button();
            CancelPropertiesButton = new Button();
            IterationsLabel = new Label();
            IterationsTextBox = new NumericUpDown();
            PaletteMiltiplierLabel = new Label();
            PaletteMultiplierTextBox = new NumericUpDown();
            StartingCoordinatesGroupBox = new GroupBox();
            YEndTextBox = new DoubleTextBox();
            YEndLabel = new Label();
            YStartTextBox = new DoubleTextBox();
            YStartLabel = new Label();
            XEndTextBox = new DoubleTextBox();
            XEndLabel = new Label();
            XStartTextBox = new DoubleTextBox();
            XStartLabel = new Label();
            DefaultButton = new Button();
            ((System.ComponentModel.ISupportInitialize)IterationsTextBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PaletteMultiplierTextBox).BeginInit();
            StartingCoordinatesGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // OKButton
            // 
            OKButton.Location = new Point(24, 192);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 0;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelPropertiesButton
            // 
            CancelPropertiesButton.Location = new Point(300, 192);
            CancelPropertiesButton.Name = "CancelPropertiesButton";
            CancelPropertiesButton.Size = new Size(75, 23);
            CancelPropertiesButton.TabIndex = 1;
            CancelPropertiesButton.Text = "Cancel";
            CancelPropertiesButton.UseVisualStyleBackColor = true;
            CancelPropertiesButton.Click += CancelButton_Click;
            // 
            // IterationsLabel
            // 
            IterationsLabel.AutoSize = true;
            IterationsLabel.Location = new Point(24, 30);
            IterationsLabel.Name = "IterationsLabel";
            IterationsLabel.Size = new Size(56, 15);
            IterationsLabel.TabIndex = 2;
            IterationsLabel.Text = "Iterations";
            // 
            // IterationsTextBox
            // 
            IterationsTextBox.Location = new Point(146, 28);
            IterationsTextBox.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            IterationsTextBox.Name = "IterationsTextBox";
            IterationsTextBox.Size = new Size(77, 23);
            IterationsTextBox.TabIndex = 4;
            IterationsTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // PaletteMiltiplierLabel
            // 
            PaletteMiltiplierLabel.AutoSize = true;
            PaletteMiltiplierLabel.Location = new Point(24, 57);
            PaletteMiltiplierLabel.Name = "PaletteMiltiplierLabel";
            PaletteMiltiplierLabel.Size = new Size(97, 15);
            PaletteMiltiplierLabel.TabIndex = 5;
            PaletteMiltiplierLabel.Text = "Palette Multiplier";
            // 
            // PaletteMultiplierTextBox
            // 
            PaletteMultiplierTextBox.DecimalPlaces = 2;
            PaletteMultiplierTextBox.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            PaletteMultiplierTextBox.Location = new Point(146, 57);
            PaletteMultiplierTextBox.Maximum = new decimal(new int[] { 100, 0, 0, 65536 });
            PaletteMultiplierTextBox.Minimum = new decimal(new int[] { 10, 0, 0, 65536 });
            PaletteMultiplierTextBox.Name = "PaletteMultiplierTextBox";
            PaletteMultiplierTextBox.Size = new Size(77, 23);
            PaletteMultiplierTextBox.TabIndex = 6;
            PaletteMultiplierTextBox.TextAlign = HorizontalAlignment.Right;
            PaletteMultiplierTextBox.Value = new decimal(new int[] { 10, 0, 0, 65536 });
            // 
            // StartingCoordinatesGroupBox
            // 
            StartingCoordinatesGroupBox.Controls.Add(YEndTextBox);
            StartingCoordinatesGroupBox.Controls.Add(YEndLabel);
            StartingCoordinatesGroupBox.Controls.Add(YStartTextBox);
            StartingCoordinatesGroupBox.Controls.Add(YStartLabel);
            StartingCoordinatesGroupBox.Controls.Add(XEndTextBox);
            StartingCoordinatesGroupBox.Controls.Add(XEndLabel);
            StartingCoordinatesGroupBox.Controls.Add(XStartTextBox);
            StartingCoordinatesGroupBox.Controls.Add(XStartLabel);
            StartingCoordinatesGroupBox.Location = new Point(24, 86);
            StartingCoordinatesGroupBox.Name = "StartingCoordinatesGroupBox";
            StartingCoordinatesGroupBox.Size = new Size(351, 88);
            StartingCoordinatesGroupBox.TabIndex = 7;
            StartingCoordinatesGroupBox.TabStop = false;
            StartingCoordinatesGroupBox.Text = "Starting Coordinates";
            // 
            // YEndTextBox
            // 
            YEndTextBox.Location = new Point(217, 52);
            YEndTextBox.Name = "YEndTextBox";
            YEndTextBox.Size = new Size(120, 23);
            YEndTextBox.TabIndex = 7;
            // 
            // YEndLabel
            // 
            YEndLabel.AutoSize = true;
            YEndLabel.Location = new Point(174, 54);
            YEndLabel.Name = "YEndLabel";
            YEndLabel.Size = new Size(37, 15);
            YEndLabel.TabIndex = 6;
            YEndLabel.Text = "Y End";
            // 
            // YStartTextBox
            // 
            YStartTextBox.Location = new Point(57, 52);
            YStartTextBox.Name = "YStartTextBox";
            YStartTextBox.Size = new Size(104, 23);
            YStartTextBox.TabIndex = 5;
            // 
            // YStartLabel
            // 
            YStartLabel.AutoSize = true;
            YStartLabel.Location = new Point(6, 54);
            YStartLabel.Name = "YStartLabel";
            YStartLabel.Size = new Size(41, 15);
            YStartLabel.TabIndex = 4;
            YStartLabel.Text = "Y Start";
            // 
            // XEndTextBox
            // 
            XEndTextBox.Location = new Point(217, 23);
            XEndTextBox.Name = "XEndTextBox";
            XEndTextBox.Size = new Size(120, 23);
            XEndTextBox.TabIndex = 3;
            // 
            // XEndLabel
            // 
            XEndLabel.AutoSize = true;
            XEndLabel.Location = new Point(174, 25);
            XEndLabel.Name = "XEndLabel";
            XEndLabel.Size = new Size(37, 15);
            XEndLabel.TabIndex = 2;
            XEndLabel.Text = "X End";
            // 
            // XStartTextBox
            // 
            XStartTextBox.Location = new Point(57, 23);
            XStartTextBox.Name = "XStartTextBox";
            XStartTextBox.Size = new Size(104, 23);
            XStartTextBox.TabIndex = 1;
            // 
            // XStartLabel
            // 
            XStartLabel.AutoSize = true;
            XStartLabel.Location = new Point(6, 25);
            XStartLabel.Name = "XStartLabel";
            XStartLabel.Size = new Size(41, 15);
            XStartLabel.TabIndex = 0;
            XStartLabel.Text = "X Start";
            // 
            // DefaultButton
            // 
            DefaultButton.Location = new Point(160, 192);
            DefaultButton.Name = "DefaultButton";
            DefaultButton.Size = new Size(75, 23);
            DefaultButton.TabIndex = 8;
            DefaultButton.Text = "Defaults";
            DefaultButton.UseVisualStyleBackColor = true;
            DefaultButton.Click += DefaultButton_Click;
            // 
            // PropertiesDialog
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 227);
            ControlBox = false;
            Controls.Add(DefaultButton);
            Controls.Add(StartingCoordinatesGroupBox);
            Controls.Add(PaletteMultiplierTextBox);
            Controls.Add(PaletteMiltiplierLabel);
            Controls.Add(IterationsTextBox);
            Controls.Add(IterationsLabel);
            Controls.Add(CancelPropertiesButton);
            Controls.Add(OKButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "PropertiesDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mandelbrot Properties";
            Load += PropertiesDialog_Load;
            ((System.ComponentModel.ISupportInitialize)IterationsTextBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)PaletteMultiplierTextBox).EndInit();
            StartingCoordinatesGroupBox.ResumeLayout(false);
            StartingCoordinatesGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OKButton;
        private Button CancelPropertiesButton;
        private Label IterationsLabel;
        private NumericUpDown IterationsTextBox;
        private Label PaletteMiltiplierLabel;
        private NumericUpDown PaletteMultiplierTextBox;
        private GroupBox StartingCoordinatesGroupBox;
        private DoubleTextBox YEndTextBox;
        private Label YEndLabel;
        private DoubleTextBox YStartTextBox;
        private Label YStartLabel;
        private DoubleTextBox XEndTextBox;
        private Label XEndLabel;
        private DoubleTextBox XStartTextBox;
        private Label XStartLabel;
        private Button DefaultButton;
    }
}