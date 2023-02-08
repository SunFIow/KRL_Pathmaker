namespace Pathmaker
{
    partial class Pathmaker_Form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pathmaker_Form));
            this.labelPenWeight = new System.Windows.Forms.Label();
            this.penWeightNum = new System.Windows.Forms.NumericUpDown();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelYOffset = new System.Windows.Forms.Label();
            this.labelXOffset = new System.Windows.Forms.Label();
            this.labelZoom = new System.Windows.Forms.Label();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kRLProgrammSpeichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.buttonResetPath = new System.Windows.Forms.Button();
            this.labelZoomValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.penWeightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPenWeight
            // 
            this.labelPenWeight.AutoSize = true;
            this.labelPenWeight.Location = new System.Drawing.Point(622, 85);
            this.labelPenWeight.Name = "labelPenWeight";
            this.labelPenWeight.Size = new System.Drawing.Size(66, 13);
            this.labelPenWeight.TabIndex = 21;
            this.labelPenWeight.Text = "Strichstärke:";
            // 
            // penWeightNum
            // 
            this.penWeightNum.Location = new System.Drawing.Point(693, 83);
            this.penWeightNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.penWeightNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penWeightNum.Name = "penWeightNum";
            this.penWeightNum.Size = new System.Drawing.Size(100, 20);
            this.penWeightNum.TabIndex = 20;
            this.penWeightNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.penWeightNum.ValueChanged += new System.EventHandler(this.penWeightNum_ValueChanged);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(643, 109);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(150, 24);
            this.buttonDraw.TabIndex = 19;
            this.buttonDraw.Text = "Zeichnen";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(693, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(693, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "0";
            // 
            // labelYOffset
            // 
            this.labelYOffset.AutoSize = true;
            this.labelYOffset.Location = new System.Drawing.Point(642, 60);
            this.labelYOffset.Name = "labelYOffset";
            this.labelYOffset.Size = new System.Drawing.Size(46, 13);
            this.labelYOffset.TabIndex = 16;
            this.labelYOffset.Text = "y - Start:";
            // 
            // labelXOffset
            // 
            this.labelXOffset.AutoSize = true;
            this.labelXOffset.Location = new System.Drawing.Point(643, 34);
            this.labelXOffset.Name = "labelXOffset";
            this.labelXOffset.Size = new System.Drawing.Size(46, 13);
            this.labelXOffset.TabIndex = 15;
            this.labelXOffset.Text = "x - Start:";
            // 
            // labelZoom
            // 
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(653, 158);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(34, 13);
            this.labelZoom.TabIndex = 14;
            this.labelZoom.Text = "Zoom";
            // 
            // zoomBar
            // 
            this.zoomBar.Location = new System.Drawing.Point(693, 149);
            this.zoomBar.Maximum = 100;
            this.zoomBar.Minimum = 1;
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(100, 45);
            this.zoomBar.TabIndex = 13;
            this.zoomBar.Value = 10;
            this.zoomBar.ValueChanged += new System.EventHandler(this.zoomBar_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.ansichtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kRLProgrammSpeichernToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.openPathToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // kRLProgrammSpeichernToolStripMenuItem
            // 
            this.kRLProgrammSpeichernToolStripMenuItem.Name = "kRLProgrammSpeichernToolStripMenuItem";
            this.kRLProgrammSpeichernToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.kRLProgrammSpeichernToolStripMenuItem.Text = "KRL Programm speichern";
            this.kRLProgrammSpeichernToolStripMenuItem.Click += new System.EventHandler(this.kRLProgrammSpeichernToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveFileToolStripMenuItem.Text = "Pfad speichern";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // openPathToolStripMenuItem
            // 
            this.openPathToolStripMenuItem.Name = "openPathToolStripMenuItem";
            this.openPathToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openPathToolStripMenuItem.Text = "Pfad öffnen";
            this.openPathToolStripMenuItem.Click += new System.EventHandler(this.openPathToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Location = new System.Drawing.Point(12, 24);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 600);
            this.pictureBox.TabIndex = 22;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Enabled = false;
            this.infoTextBox.Location = new System.Drawing.Point(618, 331);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(184, 294);
            this.infoTextBox.TabIndex = 25;
            this.infoTextBox.Text = resources.GetString("infoTextBox.Text");
            // 
            // buttonResetPath
            // 
            this.buttonResetPath.Location = new System.Drawing.Point(646, 200);
            this.buttonResetPath.Name = "buttonResetPath";
            this.buttonResetPath.Size = new System.Drawing.Size(147, 23);
            this.buttonResetPath.TabIndex = 26;
            this.buttonResetPath.Text = "Pfad löschen";
            this.buttonResetPath.UseVisualStyleBackColor = true;
            this.buttonResetPath.Click += new System.EventHandler(this.buttonResetPath_Click);
            // 
            // labelZoomValue
            // 
            this.labelZoomValue.AutoSize = true;
            this.labelZoomValue.Location = new System.Drawing.Point(622, 158);
            this.labelZoomValue.Name = "labelZoomValue";
            this.labelZoomValue.Size = new System.Drawing.Size(13, 13);
            this.labelZoomValue.TabIndex = 27;
            this.labelZoomValue.Text = "1";
            // 
            // ErweiterungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 637);
            this.Controls.Add(this.labelZoomValue);
            this.Controls.Add(this.buttonResetPath);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelPenWeight);
            this.Controls.Add(this.penWeightNum);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelYOffset);
            this.Controls.Add(this.labelXOffset);
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ErweiterungForm";
            this.Text = "Erweiterung";
            ((System.ComponentModel.ISupportInitialize)(this.penWeightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelPenWeight;
        private System.Windows.Forms.NumericUpDown penWeightNum;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelYOffset;
        private System.Windows.Forms.Label labelXOffset;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kRLProgrammSpeichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPathToolStripMenuItem;
        private System.Windows.Forms.Button buttonResetPath;
        private System.Windows.Forms.Label labelZoomValue;
    }
}

