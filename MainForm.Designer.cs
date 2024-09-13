namespace Mandelbrot
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            displayPictureBox = new PictureBox();
            mandelbrotBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            propertiesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            copyToClipboardToolStripMenuItem = new ToolStripMenuItem();
            saveToFileToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            abToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            CoordinatesStatusLabel = new ToolStripStatusLabel();
            ProgressStatusLabel = new ToolStripStatusLabel();
            toolStrip = new ToolStrip();
            UndoButton = new ToolStripButton();
            RedoButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            ResetButton = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)displayPictureBox).BeginInit();
            mainMenuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // displayPictureBox
            // 
            displayPictureBox.Dock = DockStyle.Fill;
            displayPictureBox.Location = new Point(0, 24);
            displayPictureBox.Name = "displayPictureBox";
            displayPictureBox.Size = new Size(1062, 562);
            displayPictureBox.TabIndex = 0;
            displayPictureBox.TabStop = false;
            displayPictureBox.Paint += PicDisplay_Paint;
            displayPictureBox.MouseDown += PicDisplay_MouseDown;
            displayPictureBox.MouseMove += PicDisplay_MouseMove;
            displayPictureBox.MouseUp += PicDisplay_MouseUp;
            // 
            // mandelbrotBackgroundWorker
            // 
            mandelbrotBackgroundWorker.WorkerReportsProgress = true;
            mandelbrotBackgroundWorker.WorkerSupportsCancellation = true;
            mandelbrotBackgroundWorker.DoWork += BackgroundWorker1_DoWork;
            mandelbrotBackgroundWorker.ProgressChanged += BackgroundWorker1_ProgressChanged;
            mandelbrotBackgroundWorker.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, imageToolStripMenuItem, helpToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1062, 24);
            mainMenuStrip.TabIndex = 1;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem, toolStripSeparator3, propertiesToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(127, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(127, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(124, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new Size(127, 22);
            propertiesToolStripMenuItem.Text = "Properties";
            propertiesToolStripMenuItem.Click += PropertiesToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(124, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(127, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToClipboardToolStripMenuItem, saveToFileToolStripMenuItem });
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(52, 20);
            imageToolStripMenuItem.Text = "Image";
            // 
            // copyToClipboardToolStripMenuItem
            // 
            copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            copyToClipboardToolStripMenuItem.Size = new Size(171, 22);
            copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            copyToClipboardToolStripMenuItem.Click += CopyToClipboardToolStripMenuItem_Click;
            // 
            // saveToFileToolStripMenuItem
            // 
            saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            saveToFileToolStripMenuItem.Size = new Size(171, 22);
            saveToFileToolStripMenuItem.Text = "Save to File";
            saveToFileToolStripMenuItem.Click += SaveToFileToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // abToolStripMenuItem
            // 
            abToolStripMenuItem.Name = "abToolStripMenuItem";
            abToolStripMenuItem.Size = new Size(107, 22);
            abToolStripMenuItem.Text = "About";
            abToolStripMenuItem.Click += AbToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { CoordinatesStatusLabel, ProgressStatusLabel });
            statusStrip.Location = new Point(0, 564);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1062, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip";
            // 
            // CoordinatesStatusLabel
            // 
            CoordinatesStatusLabel.Name = "CoordinatesStatusLabel";
            CoordinatesStatusLabel.Size = new Size(935, 17);
            CoordinatesStatusLabel.Spring = true;
            CoordinatesStatusLabel.Text = "X:0.0 Y:0.0";
            CoordinatesStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ProgressStatusLabel
            // 
            ProgressStatusLabel.Name = "ProgressStatusLabel";
            ProgressStatusLabel.Size = new Size(112, 17);
            ProgressStatusLabel.Text = "ProgressStatusLabel";
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { UndoButton, RedoButton, toolStripSeparator1, ResetButton });
            toolStrip.Location = new Point(0, 24);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(1062, 25);
            toolStrip.TabIndex = 3;
            toolStrip.Text = "toolStrip1";
            // 
            // UndoButton
            // 
            UndoButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            UndoButton.Enabled = false;
            UndoButton.Image = (Image)resources.GetObject("UndoButton.Image");
            UndoButton.ImageTransparentColor = Color.Magenta;
            UndoButton.Name = "UndoButton";
            UndoButton.Size = new Size(40, 22);
            UndoButton.Text = "Undo";
            UndoButton.Click += UndoButton_Click;
            // 
            // RedoButton
            // 
            RedoButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            RedoButton.Enabled = false;
            RedoButton.Image = (Image)resources.GetObject("RedoButton.Image");
            RedoButton.ImageTransparentColor = Color.Magenta;
            RedoButton.Name = "RedoButton";
            RedoButton.Size = new Size(38, 22);
            RedoButton.Text = "Redo";
            RedoButton.Click += RedoButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // ResetButton
            // 
            ResetButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ResetButton.Image = (Image)resources.GetObject("ResetButton.Image");
            ResetButton.ImageTransparentColor = Color.Magenta;
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(39, 22);
            ResetButton.Text = "Reset";
            ResetButton.Click += ResetButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 586);
            Controls.Add(toolStrip);
            Controls.Add(statusStrip);
            Controls.Add(displayPictureBox);
            Controls.Add(mainMenuStrip);
            MainMenuStrip = mainMenuStrip;
            Name = "MainForm";
            Text = "Mandelbrot Calculator - KB3HHA Seth Cohen";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)displayPictureBox).EndInit();
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox displayPictureBox;
        private System.ComponentModel.BackgroundWorker mandelbrotBackgroundWorker;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel ProgressStatusLabel;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private ToolStripMenuItem saveToFileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem abToolStripMenuItem;
        private ToolStrip toolStrip;
        private ToolStripButton UndoButton;
        private ToolStripButton RedoButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton ResetButton;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripStatusLabel CoordinatesStatusLabel;
    }
}
