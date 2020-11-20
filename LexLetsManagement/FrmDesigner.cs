using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LexLetsManagement
{
    public partial class FrmDesigner : Form
    {
        public FrmDesigner()
        {
            InitializeComponent();
        }
        /*
            omnicalculator.com
            
            1pixel is 0.26458333 mm.

            1cm = 37.7952755906 pixels
            1mm = 3.77 pixels
            18cm circumference = 5.72958cm diameter which is 216.55 pixels
            2.87mm diameter = 10.84 pixels  (3mm)
            5.76mm diamete = 21.77007874 pixels (6mm)

            Angle is 0.5304 per pixel

            set up class to store all beads with sizes. work angle out after button is pressed and use.
            angle should be just +radius of both beads of new bead.
            
        */

        Thread th;
        Graphics g;
        Graphics fG;
        Bitmap btm;
        List<Designer> history = new List<Designer>();

        float braceletSizeLeft = 180.00f;
        float braceletTotalSize = 180.00f;
        float braceletSizeCount = 0.00f;

        Designer threemm = new Designer(2.87f, "3mm");
        Designer fourmm = new Designer(3.88f, "4mm");
        Designer fivemm = new Designer(4.83f, "5mm");
        Designer sixmm = new Designer(5.76f, "6mm");
        Designer eightmm = new Designer(7.88f, "8mm");
        Designer currentBead = new Designer(0.00f, "Current");
        Designer previousBead = new Designer(0.00f, "Previous");

        int counter = 0;


        float angle = 105.0f; // Starting Posistion of Beads
        PointF org = new PointF(200, 200); //starting point of big circle that the bead follows 250 250
        float rad = 108.275f;
        Pen pen = new Pen(Brushes.LightGray, 0.5f);
        SolidBrush brush = new SolidBrush(Color.Gray);
        RectangleF area = new RectangleF(90, 90, 216.55f, 216.55f); // Big Circle Size 216.55 pixels = 5.72958cm (diameter of 18cm)


        PointF loc = PointF.Empty;
        PointF img = new PointF(200, 200); //20 20 // moves black circle around

        private void FrmDesigner_Load(object sender, EventArgs e)
        {
            btm = new Bitmap(500, 500);
            g = Graphics.FromImage(btm);
            fG = CreateGraphics();
            th = new Thread(Draw)
            {
                IsBackground = true
            };
            th.Start();
            lblSpaceLeft.Text = braceletSizeLeft.ToString() + "mm";
            lblStartSize.Text = braceletTotalSize.ToString() + "mm";
        }
        private void Draw()
        {
            g.DrawEllipse(pen, area);
            float diam = ConvertMmToPixels(currentBead.Size);
            RectangleF circle = new RectangleF(0, 0, diam, diam); // Draws Bead


            angle -= (currentBead.Radius + previousBead.Radius) * 0.5304f;  //radius 1 + radius 2 * pixels
            braceletSizeLeft -= currentBead.Size;
            braceletSizeCount += currentBead.Size;

            if (braceletSizeCount > braceletTotalSize)
            {
                RedrawBracelet(braceletSizeCount);
                return;
            }


            lblSpaceLeft.Invoke((MethodInvoker)delegate ()
            {
                lblSpaceLeft.Text = braceletSizeLeft.ToString() + "mm";

            });


            lblTotalSize.Invoke((MethodInvoker)delegate ()
            {
                lblTotalSize.Text = braceletSizeCount.ToString() + "mm";
            });

            loc = CirclePoint(rad, angle, org, braceletTotalSize);
            history.Add(currentBead);
            //circle.X = loc.X - (circle.Width / 2) + area.X;
            //circle.Y = loc.Y - (circle.Height / 2) + area.Y;

            circle.X = loc.X - (circle.Width / 2);
            circle.Y = loc.Y - (circle.Height / 2);

            g.FillEllipse(brush, circle);
            fG.DrawImage(btm, img);

        }

        private void DrawNew(float size, float prevRadius, float currRadius, string currName)
        {
            int historyLength = history.Count;

            float diam = ConvertMmToPixels(size);
            RectangleF circle = new RectangleF(0, 0, diam, diam); // bead size // 10.84 pixels = 2.87mm


            angle -= (currRadius + prevRadius) * 0.5304f;  //radius 1 + radius 2 * pixels
            braceletSizeLeft -= size;
            braceletSizeCount += size;
            lblSpaceLeft.Text = braceletSizeLeft.ToString() + "mm";
            lblTotalSize.Text = braceletSizeCount.ToString() + "mm";
            loc = CirclePoint(rad, angle, org, braceletTotalSize);

            //circle.X = loc.X - (circle.Width / 2) + area.X;
            //circle.Y = loc.Y - (circle.Height / 2) + area.Y;

            circle.X = loc.X - (circle.Width / 2);
            circle.Y = loc.Y - (circle.Height / 2);

            g.FillEllipse(brush, circle);
            fG.DrawImage(btm, img);

        }

        public PointF CirclePoint(float radius, float angleInDegrees, PointF Origin, float size)
        {
            float x = (float)(radius * Math.Cos(angleInDegrees * Math.PI / size)) + Origin.X;
            float y = (float)(radius * Math.Sin(angleInDegrees * Math.PI / size)) + Origin.Y;
            return new PointF(x, y);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            previousBead = currentBead;
            currentBead = threemm;
            //currentBead.Size = 2.87f;
            //currentBead.Angle = 5.75f;
            Draw();
            counter++;
            lblBeadCounter.Text = counter.ToString();
        }



        private float ConvertMmToPixels(float diameter)
        {
            return diameter * 3.7795275591f;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            previousBead = currentBead;
            currentBead = sixmm;
            //currentBead.Size = 5.76f;
            //currentBead.Angle = 11.546f;
            Draw();
            counter++;
            lblBeadCounter.Text = counter.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            previousBead = currentBead;
            currentBead = fourmm;
            //currentBead.Size = 2.87f;
            //currentBead.Angle = 5.75f;
            Draw();
            counter++;
            lblBeadCounter.Text = counter.ToString();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            previousBead = currentBead;
            currentBead = fivemm;
            //currentBead.Size = 2.87f;
            //currentBead.Angle = 5.75f;
            Draw();
            counter++;
            lblBeadCounter.Text = counter.ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            previousBead = currentBead;
            currentBead = eightmm;
            //currentBead.Size = 2.87f;
            //currentBead.Angle = 5.75f;
            Draw();
            counter++;
            lblBeadCounter.Text = counter.ToString();
        }

        private void RedrawBracelet(float newbraceletSizeLeft)
        {
            angle = 105f;

            g.Clear(Color.White);
            braceletSizeLeft = newbraceletSizeLeft;
            braceletTotalSize = newbraceletSizeLeft;
            braceletSizeCount = 0;

            lblStartSize.Text = braceletSizeLeft.ToString() + "mm";
            lblTotalSize.Text = braceletSizeCount.ToString() + "mm";
            lblSpaceLeft.Text = braceletSizeLeft.ToString() + "mm";

            float newSize = (((newbraceletSizeLeft / 10) / 3.14159265359f) / 0.26458333f) * 10f; //converts to pixels
            rad = newSize / 2;

            RectangleF area2 = new RectangleF(90, 90, newSize, newSize); // Big Circle Size 216.55 pixels = 5.72958cm (diameter of 18cm)

            g.DrawEllipse(pen, area2);

            for (int i = 0; i < history.Count; i++)
            {
                if (i == 0)
                {
                    DrawNew(history[i].Size, history[i].Radius, history[i].Radius, history[i].Name);
                }
                else
                {
                    DrawNew(history[i].Size, history[i - 1].Radius, history[i].Radius, history[i].Name);
                }
            }

            DrawNew(currentBead.Size, previousBead.Radius, currentBead.Radius, currentBead.Name);
        }
    }
}
