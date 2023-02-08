using KRL_Pathmaker.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/* NOTES
 * Option to load Image
 * Add Circle Method
 * Init dx/dy/shouldDraw array at declaration
 */

namespace Pathmaker
{
    public partial class Pathmaker_Form : Form
    {
        private readonly bool RIGHT_TO_LEFT = true;
        private readonly bool BOTTOM_TO_TOP = true;

        private readonly float MOVING_Z = 10;

        private readonly float pictureBoxCenterX;
        private readonly float pictureBoxCenterY;

        private System.Drawing.Image background_image;
        private float background_image_offset_x;
        private float background_image_offset_y;
        private float background_width;
        private float background_height;

        private float xOffset;
        private float yOffset;
        private float zoom;

        private bool customPoints;
        private List<ControlPoint> points;
        private ControlPoint selected;

        private string Filename;

        private float mx;
        private float my;

        public class ControlPoint
        {
            public float x;
            public float y;
            public bool draw;

            public ControlPoint(float x, float y, bool draw)
            {
                this.x = x;
                this.y = y;
                this.draw = draw;
            }

        }

        public Pathmaker_Form()
        {
            InitializeComponent();
            InitializeBackgroundImage();

            this.pictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseWheel);

            pictureBoxCenterX = this.pictureBox.Width / 2f;
            pictureBoxCenterY = this.pictureBox.Height / 2f;

            zoom = zoomBar.Value * 0.1f;

            InitializeSantaHouse();
        }
        private void InitializeSantaHouse()
        {
            int[] dx = { 0, 100, -50, -50, 100, -100, 100, 0 };
            int[] dy = { -100, 0, -50, 50, 100, 0, -100, 100 };

            this.points = new List<ControlPoint>();
            this.customPoints = false;

            float x = pictureBoxCenterX - 50;
            float y = pictureBoxCenterY + 50;
            points.Add(new ControlPoint(x, y, true));
            for (int i = 0; i < dx.Length; i++)
            {
                x += dx[i];
                y += dy[i];
                points.Add(new ControlPoint(x, y, true));
            }
        }

        private void InitializeBackgroundImage()
        {
            background_image = KRL_Pathmaker.Properties.Resources.background_img;

            float background_scale;
            if (background_image.Width > background_image.Height)
            {
                background_scale = background_image.Width / this.pictureBox.Width;
            }
            else
            {
                background_scale = background_image.Height / this.pictureBox.Height;
            }

            background_width = (int)(background_image.Width / background_scale);
            background_height = (int)(background_image.Height / background_scale);

            if (background_image.Width > background_image.Height)
            {
                background_image_offset_y = (this.pictureBox.Height - background_height) / 2;
            }
            else
            {
                background_image_offset_x = (this.pictureBox.Width - background_width) / 2;
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            int Strichstärke = Convert.ToInt32(penWeightNum.Value);
            Pen myPenW = new Pen(Color.White, Strichstärke);
            Pen myPenY = new Pen(Color.Yellow, Strichstärke);
            Pen myPenG = new Pen(Color.Green, Strichstärke);
            Pen myPenR = new Pen(Color.Red, Strichstärke);

            Brush myBrushB = new SolidBrush(Color.Blue);

            e.Graphics.TranslateTransform(xOffset + tempOffsetX + pictureBoxCenterX, yOffset + tempOffsetY + pictureBoxCenterY);

            e.Graphics.DrawImage(background_image, (background_image_offset_x - pictureBoxCenterX) * zoom, (background_image_offset_y - pictureBoxCenterY) * zoom, background_width * zoom, background_height * zoom);

            e.Graphics.DrawLine(myPenY, -5, 0, 5, 0);
            e.Graphics.DrawLine(myPenY, 0, -5, 0, 5);

            //Algorithmus
            for (int i = 0; i < points.Count(); i++)
            {
                float x0 = zoom * (points[i].x - pictureBoxCenterX);
                float y0 = zoom * (points[i].y - pictureBoxCenterY);

                e.Graphics.FillEllipse(myBrushB, x0 - 3, y0 - 3, 6, 6);
                Pen haloColor = (points[i] == selected) ? myPenY : myPenW;
                float radius = (points[i] == selected) ? 8 : 6;
                e.Graphics.DrawEllipse(haloColor, x0 - radius, y0 - radius, radius * 2, radius * 2);

                if (i < 1) continue;
                //Zeichen
                float x1 = zoom * (points[i - 1].x - pictureBoxCenterX);
                float y1 = zoom * (points[i - 1].y - pictureBoxCenterY);
                Pen lineColor = points[i].draw ? myPenG : myPenR;
                e.Graphics.DrawLine(lineColor, x1, y1, x0, y0);
            }
        }

        private void buttonResetPath_Click(object sender, EventArgs e)
        {
            points.Clear();
            pictureBox.Refresh();
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            int newZoomBar = zoomBar.Value + (e.Delta > 0 ? 1 : -1);

            zoomBar.Value = Math.Max(Math.Min(newZoomBar, zoomBar.Maximum), zoomBar.Minimum);
        }
        private void zoomBar_ValueChanged(object sender, EventArgs e)
        {
            zoom = zoomBar.Value * 0.1f;
            string sZoom = zoom.ToString();
            labelZoomValue.Text = sZoom.Substring(0, Math.Min(sZoom.Length, 5));
            pictureBox.Refresh();
        }


        private void buttonDraw_Click(object sender, EventArgs e)
        {
            setOffset(Convert.ToSingle(textBox1.Text), Convert.ToSingle(textBox2.Text));
            pictureBox.Refresh();
        }

        private void penWeightNum_ValueChanged(object sender, EventArgs e)
        {
            pictureBox.Refresh();
        }

        private bool mouseDown = false;
        private bool moveOffset = false;
        private int tempMouseX;
        private int tempMouseY;
        private int tempOffsetX;
        private int tempOffsetY;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            float mouseX = convertX(e.X);
            float mouseY = convertY(e.Y);

            Console.WriteLine(mouseX + " " + mouseY);
            tempMouseX = e.X;
            tempMouseY = e.Y;

            MouseButtons button = e.Button;
            if (button == MouseButtons.Left || button == MouseButtons.Right)
            {
                bool pDraw = button == MouseButtons.Left;
                if (!customPoints)
                {
                    points.Clear();
                    customPoints = true;
                }
                points.Add(new ControlPoint(mouseX, mouseY, pDraw));
                pictureBox.Refresh();
            }
            else if (button == MouseButtons.Middle)
            {
                float closest_dist = float.MaxValue;
                ControlPoint closest_point = null;
                foreach (ControlPoint p in points)
                {
                    float d = (p.x - mouseX) * (p.x - mouseX) + (p.y - mouseY) * (p.y - mouseY);
                    if (d < closest_dist)
                    {
                        closest_dist = d;
                        closest_point = p;
                    }
                }
                if (closest_dist < (36 / (zoom * zoom)))
                {
                    selected = closest_point;
                    pictureBox.Refresh();
                }
                else
                {
                    moveOffset = true;
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mx = convertX(e.X);
            my = convertY(e.Y);

            if (mouseDown && selected != null)
            {
                float mouseX = convertX(e.X);
                float mouseY = convertY(e.Y);
                selected.x = mouseX;
                selected.y = mouseY;
                pictureBox.Refresh();
            }
            if (moveOffset)
            {
                tempOffsetX = e.X - tempMouseX;
                tempOffsetY = e.Y - tempMouseY;
                pictureBox.Refresh();
            }

            pictureBox.Refresh();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            moveOffset = false;
            selected = null;
            setOffset(xOffset + tempOffsetX, yOffset + tempOffsetY);
            tempOffsetX = 0;
            tempOffsetY = 0;
            pictureBox.Refresh();
        }

        private void setOffset(float dx, float dy)
        {
            xOffset = dx;
            yOffset = dy;
            textBox1.Text = xOffset.ToString();
            textBox2.Text = yOffset.ToString();
        }

        private float convertX(int x)
        {
            //return (x - xOffset) / zoom
            return (x - xOffset - pictureBoxCenterX) / zoom + pictureBoxCenterX;
        }
        private float convertY(int y)
        {
            //return (y - yOffset) / zoom;
            return (y - yOffset - pictureBoxCenterY) / zoom + pictureBoxCenterY;
        }

        private void kRLProgrammSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "All types (*.*)|*.*|Normal text file (*.txt)|*.txt|Kuka roboter language (*.krl)|*.krl|Source file (*.src)|*.src";
            saveFileDialog.FilterIndex = 4;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = Filename ?? "Roboter_Path";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string FileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);

            myStream = saveFileDialog.OpenFile();
            if (myStream == null) return;

            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(myStream);

            int start = 0;
            int count = points.Count() - 1;
            if (count > 1000)
            {
                count = 1000;
                start = points.Count() - 1001;
            }


            myWriter.WriteLine("DEF  " + FileName + " (startPos: IN)");
            myWriter.WriteLine("");
            myWriter.WriteLine(";Definition");
            myWriter.WriteLine("E6POS startPos");
            myWriter.WriteLine("E6POS roboPos ");
            myWriter.WriteLine("DECL bool isDrawing");
            myWriter.WriteLine("DECL int dx [" + count + "]");
            myWriter.WriteLine("DECL int dy [" + count + "]");
            myWriter.WriteLine("DECL bool shouldDraw [" + count + "]");
            myWriter.WriteLine("DECL int iCount");
            myWriter.WriteLine("");
            myWriter.WriteLine(";Initialisierung");
            myWriter.WriteLine("roboPos = startPos");
            myWriter.WriteLine("isDrawing = true");

            float startX = points[0].x * zoom;
            float startY = points[0].y * zoom;
            for (int i = start + 1; i < points.Count(); i++)
            {
                int pX = (int)Math.Round(points[i].x * zoom - startX);
                if (RIGHT_TO_LEFT) pX = -pX;
                int pY = (int)Math.Round(points[i].y * zoom - startY);
                if (BOTTOM_TO_TOP) pY = -pY;

                myWriter.WriteLine("dx [" + i + "] = " + pX);
                myWriter.WriteLine("dy [" + i + "] = " + pY);
                myWriter.WriteLine("shouldDraw [" + i + "] = " + Convert.ToString(points[i].draw).ToUpper());
            }

            myWriter.WriteLine("");
            myWriter.WriteLine(";Schleife");
            myWriter.WriteLine("FOR iCount = 1 TO " + count + " STEP 1");
            myWriter.WriteLine("   IF shouldDraw[iCount] <> isDrawing THEN");
            myWriter.WriteLine("      isDrawing = shouldDraw[iCount]");
            myWriter.WriteLine("      IF isDrawing == TRUE THEN");
            myWriter.WriteLine("         roboPos.Z = startPos.Z");
            myWriter.WriteLine("      ELSE");
            myWriter.WriteLine("         roboPos.Z = startPos.Z + " + MOVING_Z);
            myWriter.WriteLine("      ENDIF");
            myWriter.WriteLine("      sLin roboPos");
            myWriter.WriteLine("   ENDIF");
            myWriter.WriteLine("   roboPos.X = startPos.X + dx[iCount]");
            myWriter.WriteLine("   roboPos.Y = startPos.Y + dy[iCount]");
            myWriter.WriteLine("   sLin roboPos");
            myWriter.WriteLine("");
            myWriter.WriteLine("ENDFOR");
            myWriter.WriteLine("");
            myWriter.WriteLine("END");


            myWriter.Close();

            MessageBox.Show("Wurde gespeichert", "KRL Programm speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "All types (*.*)|*.*|Normal text file (*.txt)|*.txt|Path file (*.pth)|*.pth";
            saveFileDialog.FilterIndex = 3;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = Filename ?? "Roboter_Path";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            string FileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);

            fileStream = saveFileDialog.OpenFile();
            if (fileStream == null) return;

            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(fileStream);

            myWriter.WriteLine("Name;" + FileName);
            myWriter.WriteLine("xOffset;" + xOffset);
            myWriter.WriteLine("yOffset;" + yOffset);
            myWriter.WriteLine("zoom;" + zoom);
            myWriter.WriteLine("points.Count;" + points.Count);
            for (int i = 0; i < points.Count; i++)
            {
                myWriter.WriteLine("points[" + i + "];" + points[i].x + ";" + points[i].y + ";" + points[i].draw);
            }

            myWriter.Close();
        }

        private void openPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All types (*.*)|*.*|Normal text file (*.txt)|*.txt|Path file (*.pth)|*.pth";
            openFileDialog.FilterIndex = 3;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            string FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

            fileStream = openFileDialog.OpenFile();
            if (fileStream == null) return;

            System.IO.StreamReader myReader = new System.IO.StreamReader(fileStream);

            this.Filename = myReader.ReadLine().Substring("Name;".Length);
            this.xOffset = Convert.ToSingle(myReader.ReadLine().Substring("xOffset;".Length));
            this.yOffset = Convert.ToSingle(myReader.ReadLine().Substring("yOffset;".Length));
            this.zoom = Convert.ToSingle(myReader.ReadLine().Substring("zoom;".Length));
            zoomBar.Value = (int)(zoom * 10);

            points.Clear();
            if (!customPoints) customPoints = true;

            int Count = Convert.ToInt32(myReader.ReadLine().Substring("points.Count=".Length));
            for (int i = 0; i < Count; i++)
            {
                string cp = myReader.ReadLine();
                string[] values = cp.Split(';');
                points.Add(new ControlPoint(Convert.ToSingle(values[1]), Convert.ToSingle(values[2]), Convert.ToBoolean(values[3])));
            }

            myReader.Close();

            pictureBox.Refresh();
        }
    }
}
