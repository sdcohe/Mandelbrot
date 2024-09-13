using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Numerics;
using System.Xml.Serialization;
using Mandelbrot.Classes;
using Mandelbrot.Dialogs;

namespace Mandelbrot
{
    public partial class MainForm : Form
    {
        // for drawing zoom box
        private Point selPoint;
        private Rectangle mRect;
        private bool drawRectangle = false;
        private bool redrawRequested = false;

        // for calculations
        private int width;
        private int height;
        private MandelbrotCoordinates mCoordinates = new MandelbrotCoordinates(-2.0, 1.0, -1.24, 1.24);
        private Color[] colorPalette;
        private Bitmap? mandelImage;
        int currentRow = 0;
        private readonly UndoRedoList<MandelbrotCoordinates> undoList = new UndoRedoList<MandelbrotCoordinates>();

        private readonly Stopwatch stopwatch;
        private readonly MandelbrotSettings settings = new MandelbrotSettings();

        public MainForm()
        {
            InitializeComponent();

            //MAX_ITERATIONS = settings.NumberOfIterations;
            colorPalette = ColorUtility.BuildHSVColorPalette(settings.NumberOfIterations, settings.PaletteMultiplier);
            stopwatch = new Stopwatch();
            Debug.WriteLine("Coords:{0}", mCoordinates);
            Debug.WriteLine("Start coordinates {0}", settings.StartCoordinates);
            mCoordinates = settings.StartCoordinates;

            //Debug.WriteLine("Max iterations:{0}", MAX_ITERATIONS);
            //PicDisplay.Resize += PicDisplay_Resize;
        }

        private void PicDisplay_Resize(object? sender, EventArgs e)
        {
            if (displayPictureBox.Width != width || displayPictureBox.Height != height)
            {
                RedrawDisplay();
            }
        }

        private void CalculateMandelbrotSet(int maxIterations)
        {
            //Debug.WriteLine("Max iterations in calc:{0}", MAX_ITERATIONS);
            double xStep = Math.Abs((mCoordinates.XEnd - mCoordinates.XStart) / width);
            double yStep = Math.Abs((mCoordinates.YEnd - mCoordinates.YStart) / height);
            double currentY = mCoordinates.YStart;

            //Debug.WriteLine("xStep: {0}, yStep: {1}", xStep, yStep);
            for (int y = 0; y < height && !mandelbrotBackgroundWorker.CancellationPending; y++)
            {
                double currentX = mCoordinates.XStart;
                Color[] colors = new Color[width];
                for (int x = 0; x < width && !mandelbrotBackgroundWorker.CancellationPending; x++)
                {
                    int color = CalculatePixelColor(currentX, currentY, maxIterations);
                    //Debug.WriteLine("Color is {0}", color);
                    colors[x] = colorPalette[color];
                    currentX += xStep;
                }
                currentY += yStep;
                mandelbrotBackgroundWorker.ReportProgress(y / height, colors);
                //Debug.WriteLine("Current Y: {0}", currentY);
            }

            if (mandelbrotBackgroundWorker.CancellationPending)
            {
                Debug.WriteLine("Background process cancelled");
            }
        }

        private static int CalculatePixelColor(double currentX, double currentY, int maxIterations)
        {
            //Debug.WriteLine("Max iterations in pixel colors:{0}", MAX_ITERATIONS);
            Complex c = new Complex(currentX, currentY);
            Complex z = Complex.Zero;
            //Debug.WriteLine("C is {0}", c.ToString());
            int iterationCount = 0;
            do
            {
                z = Complex.Add(Complex.Pow(z, 2.0), c);
                iterationCount++;
                //Debug.WriteLine("Z is {0}  z-sqr is {1}", z.ToString(), Complex.Pow(z,2.0).ToString());
            }
            while (Complex.Abs(Complex.Pow(z, 2.0)) <= 4.0 && iterationCount < maxIterations);

            return iterationCount;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            undoList.Add(mCoordinates);
            EnableDisableControls();
            RedrawDisplay();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Calculating Mandelbrot set in the background");
            Debug.WriteLine(string.Format("Settings are {0}", mCoordinates));

            currentRow = 0;
            width = displayPictureBox.Width;
            height = displayPictureBox.Height;
            mandelImage = new Bitmap(width, height);
            Debug.WriteLine("Bitmap format {0}", mandelImage.PixelFormat);
            displayPictureBox.Image = mandelImage;
            CalculateMandelbrotSet(settings.NumberOfIterations);
            if (mandelbrotBackgroundWorker.CancellationPending) e.Cancel = true;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Debug.WriteLine(string.Format("RunTime: {0}", elapsedTime));

            Debug.WriteLine("Background worker completed");
            ProgressStatusLabel.Text = "Completed in " + elapsedTime;
            if (redrawRequested)
            {
                Debug.WriteLine("Restarting background worker with new parameters");
                redrawRequested = false;
                stopwatch.Restart();
                mandelbrotBackgroundWorker.RunWorkerAsync();
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.UserState != null && mandelImage != null)
            {
                Color[] colors = (Color[])e.UserState;

                // version using LockBits
                Rectangle rect = new Rectangle(0, currentRow, width, 1);
                BitmapData bmpData = mandelImage.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                IntPtr ptr = bmpData.Scan0;
                int bytes = Math.Abs(bmpData.Stride);
                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                for (int counter = 0; counter < width; counter++)
                {
                    int idx = counter * 4;
                    Color color = colors[counter];
                    rgbValues[idx] = color.B;
                    rgbValues[idx + 1] = color.G;
                    rgbValues[idx + 2] = color.R;
                }
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
                mandelImage.UnlockBits(bmpData);

                // version using SetPixel()
                //for (int i = 0; i < width; i++)
                //{
                //    mandelImage.SetPixel(i, currentRow, colors[i]);
                //}

                currentRow++;
                ProgressStatusLabel.Text = string.Format("Processing row {0}", currentRow);

                Refresh();
            }
        }

        private void PicDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            selPoint = e.Location;
            drawRectangle = true;
            //Debug.WriteLine("Mouse down");
        }

        private void PicDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            double xStep = Math.Abs((mCoordinates.XEnd - mCoordinates.XStart) / width);
            double yStep = Math.Abs((mCoordinates.YEnd - mCoordinates.YStart) / height);
            double XPosition = mCoordinates.XStart + e.X * xStep;
            double YPosition = mCoordinates.YStart + e.Y * yStep;

            CoordinatesStatusLabel.Text = string.Format("X:{0} Y:{1}", XPosition, YPosition);

            if (e.Button == MouseButtons.Left)
            {
                // get current location of mouse pointer
                Point p = e.Location;

                // update the rectangle and handle the situation where the user may have inverted it
                int x = Math.Min(selPoint.X, p.X);
                int y = Math.Min(selPoint.Y, p.Y);
                int w = Math.Abs(p.X - selPoint.X);
                int h = Math.Abs(p.Y - selPoint.Y);

                // draw rectangle
                mRect = new Rectangle(x, y, w, h);
                ((PictureBox)sender).Invalidate();
            }
        }

        private void PicDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (drawRectangle) e.Graphics.DrawRectangle(Pens.Blue, mRect);
        }

        private void PicDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (!drawRectangle) return;

            Debug.WriteLine("MouseUp(): Zooming to rectangle {0}", mRect.ToString());

            double xStep = Math.Abs((mCoordinates.XEnd - mCoordinates.XStart) / width);
            double yStep = Math.Abs((mCoordinates.YEnd - mCoordinates.YStart) / height);

            double newXStart = mCoordinates.XStart + mRect.X * xStep;
            double newXEnd = newXStart + (mRect.Width * xStep);
            double newYStart = mCoordinates.YStart + mRect.Y * yStep;
            double newYEnd = newYStart + (mRect.Height * yStep);

            MandelbrotCoordinates newCoordinates = new MandelbrotCoordinates(newXStart, newXEnd, newYStart, newYEnd);
            mCoordinates = newCoordinates;
            undoList.Add(newCoordinates);
            EnableDisableControls();

            //mCoordinates.XStart += mRect.X * xStep;
            //mCoordinates.XEnd = mCoordinates.XStart + (mRect.Width * xStep);
            //mCoordinates.YStart += mRect.Y * yStep;
            //mCoordinates.YEnd = mCoordinates.YStart + (mRect.Height * yStep);

            Debug.WriteLine("New X - start:{0} end:{1}", mCoordinates.XStart, mCoordinates.XEnd);
            Debug.WriteLine("New Y - start:{0} end:{1}", mCoordinates.YStart, mCoordinates.YEnd);

            // redraw without rectangle
            drawRectangle = false;

            RedrawDisplay();
        }

        private void RedrawDisplay()
        {
            Debug.WriteLine("In RedrawDisplay()");

            if (mandelbrotBackgroundWorker.IsBusy)
            {
                mandelbrotBackgroundWorker.CancelAsync();
                redrawRequested = true;
            }
            else
            {
                stopwatch.Restart();
                mandelbrotBackgroundWorker.RunWorkerAsync();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mandelbrotBackgroundWorker.IsBusy)
            {
                mandelbrotBackgroundWorker.CancelAsync();
                while (mandelbrotBackgroundWorker.IsBusy)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            }

            Application.Exit();
        }

        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mandelImage != null)
            {
                Clipboard.SetImage(mandelImage);
            }
        }

        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mandelImage != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                ImageFormat format = ImageFormat.Bmp;
                saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
                saveFileDialog.Title = "Save an Image File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    Debug.WriteLine(filePath);
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1: // jpeg
                            format = ImageFormat.Jpeg;
                            break;
                        case 2: // bmp
                            format = ImageFormat.Bmp;
                            break;
                        case 3: // gif
                            format = ImageFormat.Gif;
                            break;
                        case 4: // png
                            format = ImageFormat.Png;
                            break;
                    }
                    mandelImage.Save(filePath, format);
                }
            }
        }

        private void AbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutDialog = new AboutBox();
            aboutDialog.ShowDialog();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            mCoordinates = settings.StartCoordinates;
            undoList.Reset();
            undoList.Add(mCoordinates);
            EnableDisableControls();
            RedrawDisplay();
        }

        private void EnableDisableControls()
        {
            UndoButton.Enabled = undoList.UndoPossible();
            RedoButton.Enabled = undoList.RedoPossible();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            mCoordinates = undoList.Undo();
            EnableDisableControls();
            RedrawDisplay();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            mCoordinates = undoList.Redo();
            EnableDisableControls();
            RedrawDisplay();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Mandelbrot settings|*.mnd",
                Title = "Save Mandelbrot settings"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        XmlSerializer xSer = new XmlSerializer(typeof(MandelbrotCoordinates));
                        xSer.Serialize(fs, mCoordinates);
                        fs.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Mandelbrot settings|*.mnd",
                Title = "Open Mandelbrot settings"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (FileStream fs = new FileStream(filePath, FileMode.Open)) //double check that...
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MandelbrotCoordinates));
                    MandelbrotCoordinates? newCoordinates = (MandelbrotCoordinates?)serializer.Deserialize(fs);
                    if (newCoordinates != null)
                    {
                        Debug.WriteLine(string.Format("New settings are {0}", newCoordinates));
                        mCoordinates = newCoordinates;
                        Debug.WriteLine(string.Format("New settings are {0}", mCoordinates));
                        undoList.Add(newCoordinates);
                        EnableDisableControls();
                        RedrawDisplay();
                    }

                    fs.Close();
                }
            }
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesDialog dlg = new PropertiesDialog();
            if (dlg.ShowDialog() == DialogResult.OK )
            {
                // number of iterations changed
                settings.Reload();
                //MAX_ITERATIONS = settings.NumberOfIterations;
                colorPalette = ColorUtility.BuildHSVColorPalette(settings.NumberOfIterations, settings.PaletteMultiplier);
                Debug.WriteLine("Number of iterations " + settings.NumberOfIterations);
                RedrawDisplay();
            }
        }
    }
}
