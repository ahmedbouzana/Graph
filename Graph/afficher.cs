using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Graph
{
    class afficher
    {
        PaintEventArgs pea, pea1;
        Panel panel_gros;
        Pen myPen;
        Point[] pnt = new Point[3], pnt1 = new Point[3], pnt2 = new Point[3];
        public Brush brush { get; set; }
        Panel p, p1, p2, p3;
        public string t_s { get; set; }
        public int x1 { get; set; }
        public int y1 { get; set; }
        int panel_w = 22;

        public int xpl { get; set; }
        public int ypl { get; set; }
        public int xps { get; set; }
        public int yps { get; set; }

        public List<int> dimention { get; set; }
        public List<string> dimentiona1 { get; set; }
        public List<string> string_nom_ocr { get; set; }
        public List<string> string_troncon { get; set; }

        public int cm { get; set; }
        public int cmp { get; set; }
        public int cmpt { get; set; }
        public int cmpte { get; set; }
        Brush brush1 = default(Brush), brush2 = default(Brush);
        Form1 original;

        public afficher(Form1 ff,Panel pp)
        {
            original = ff;
            panel_gros = pp; 
            brush1 = new SolidBrush(Color.DarkSeaGreen);
            brush2 = new SolidBrush(Color.LightGreen);
        }

        public void ligne(string nom_t)
        {
            p1 = new Panel();
            p1.BackColor = Color.Aqua;
            p1.Location = new Point(xpl, ypl);

            p1.Size = new Size(xps, yps);
            p1.Name = nom_t;
            panel_gros.Controls.Add(p1);
            p1.Paint += new PaintEventHandler(panel1_paint);
            p1.Click += new System.EventHandler(panel1_click);

            p3 = new Panel();
            if (xps > yps)
                p3.Location = new Point(xpl + xps/2 - 7, ypl + 8);
            else
                p3.Location = new Point(xpl + 8, ypl + yps/2 - 7);

            p3.Size = new Size(40, 12);
            panel_gros.Controls.Add(p3);
            p3.Paint += new PaintEventHandler(string_troncon_paint);
        }

        public void panel1_paint(object sender, PaintEventArgs e)
        {
            pea1 = e;

            if (cm >= dimention.Count)
            {
                cm = 0;
            }

            float xx1 = dimention[cm + 1], yy1 = dimention[cm + 2], xx2 = dimention[cm + 3], yy2 = dimention[cm + 4];
            switch (dimention[cm])
            {
                case 1:
                    myPen = new Pen(Color.Blue, 5);
                    pea1.Graphics.DrawLine(myPen, xx1, yy1, xx2, yy2);
                    break;
                case 6:
                    myPen = new Pen(Color.Blue, 5);
                    myPen.DashStyle = DashStyle.Dash;
                    pea1.Graphics.DrawLine(myPen, xx1, yy1, xx2, yy2);
                    break;
                case 16:
                    if (xx2 > yy2)
                    {
                        myPen = new Pen(Color.Blue, 5);
                        pea1.Graphics.DrawLine(myPen, xx1, yy1, xx2 - 2 - (xx2 - xx1) / 2, yy2);

                        myPen = new Pen(Color.Blue, 5);
                        myPen.DashStyle = DashStyle.Dash;
                        pea1.Graphics.DrawLine(myPen, xx2 - (xx2 - xx1) / 2, yy1, xx2, yy2);
                    }
                    else
                    {
                        myPen = new Pen(Color.Blue, 5);
                        pea1.Graphics.DrawLine(myPen, xx1, yy1, xx2, yy2 - 2 - (yy2 - yy1) / 2);

                        myPen = new Pen(Color.Blue, 5);
                        myPen.DashStyle = DashStyle.Dash;
                        pea1.Graphics.DrawLine(myPen, xx1, yy2 - (yy2 - yy1) / 2, xx2, yy2);
                    }
                    break;
                case 61:
                    if (xx2 > yy2)
                    {
                        myPen = new Pen(Color.Blue, 5);
                        myPen.DashStyle = DashStyle.Dash;
                        pea1.Graphics.DrawLine(myPen, xx1, yy1, xx2 - 2 - (xx2 - xx1) / 2, yy2);

                        myPen = new Pen(Color.Blue, 5);
                        pea1.Graphics.DrawLine(myPen, xx2 - (xx2 - xx1) / 2, yy1, xx2, yy2);
                    }
                    else
                    {
                        myPen = new Pen(Color.Blue, 5);
                        myPen.DashStyle = DashStyle.Dash;
                        pea1.Graphics.DrawLine(myPen, xx1, yy1, xx2, yy2 - 2 - (yy2 - yy1) / 2);

                        myPen = new Pen(Color.Blue, 5);
                        pea1.Graphics.DrawLine(myPen, xx1, yy2 - (yy2 - yy1) / 2, xx2, yy2);
                    }
                    break;
                //default:
                //    break;
            }

            cm += 5;
        }

        public void string_troncon_paint(object sender, PaintEventArgs e)
        {
            if (cmpte >= string_troncon.Count)
                cmpte = 0;

            e.Graphics.DrawString(string_troncon[cmpte], new Font("Tahoma", 8), Brushes.BlueViolet, 0, 0);

            cmpte++;
        }

        private void panel1_click(object sender, EventArgs e)
        {
            string name_troncons = ((Panel)sender).Name;

            original.calcul1(name_troncons.Substring(0, name_troncons.IndexOf("_")), name_troncons.Remove(0, name_troncons.IndexOf("_") + 1));
        }

        // ////////////////////////////////////////////////////////

        public void dessiner(string ocr1, bool tel)
        {
            p = new Panel();
            p.Name = ocr1;
            //p.BackColor = Color.Aqua;
            p.Location = new Point(x1, y1);
            p.Size = new Size(23, 23);
            panel_gros.Controls.Add(p);
            p.Paint += new PaintEventHandler(panel_paint);
            p.Click += new System.EventHandler(panel_click);
            p.DoubleClick += new System.EventHandler(panel_doubleclick);

            p2 = new Panel();
            //p1.BackColor = Color.Aqua;
            p2.Location = new Point(x1 + 23, y1 - 12);
            p2.Size = new Size(59, 12);
            if (tel)
                p2.BackColor = Color.LightBlue;
            panel_gros.Controls.Add(p2);
            p2.Paint += new PaintEventHandler(panel_NOM_paint);
        }

        public void panel_paint(object sender, PaintEventArgs e)
        {
            myPen = new Pen(Color.Red, 1);
            pea = e;

            if (cmp >= dimentiona1.Count)
            {
                cmp = 0;
            }

            choisir_type(dimentiona1[cmp], dimentiona1[cmp + 1], dimentiona1[cmp + 2]);

            cmp = cmp + 3;
        }

        void choisir_type(string ta, string tp, string ouv)
        {
            switch (ta)
            {
                case "AA":
                    AA(ouv);
                    break;
                case "SA":
                    SA();
                    break;
                case "NOEUD":
                    NOEUD();
                    break;
                case "IACM":
                    IACM(ouv);
                    break;
                case "CEL":
                    CEL();
                    break;
                case "JB":
                    JB();
                    break;
                default :
                    break;
            }

            switch (tp)
            {
                case "AB":
                    AB();
                    break;
                case "DP":
                    DP();
                    break;
                case "MX":
                    MX();
                    break;
                default:
                    break;
            }
        }


        void AA(string ouv)
        {
            pea.Graphics.DrawRectangle(myPen, 0, 0, panel_w, panel_w);

            if (ouv != "")
            pea.Graphics.FillRectangle(brush2, 0, 0, panel_w, panel_w);

            pnt[0].X = panel_w / 2;
            pnt[0].Y = 0;
            pnt[1].X = panel_w;
            pnt[1].Y = panel_w;
            pnt[2].X = 0;
            pnt[2].Y = panel_w;
        }

        void SA()
        {
            pea.Graphics.DrawEllipse(myPen, 0, 0, panel_w, panel_w);

            pnt[0].X = panel_w / 2;
            pnt[0].Y = 0;
            pnt[1].X = panel_w - 1;
            pnt[1].Y = 17;
            pnt[2].X = 1;
            pnt[2].Y = 17;
        }

        void AB()
        {
            pea.Graphics.DrawPolygon(myPen, pnt);
            pea.Graphics.FillPolygon(brush, pnt);
        }

        void DP()
        {
            pea.Graphics.DrawPolygon(myPen, pnt);
        }

        void MX()
        {
            pnt2[0].X = panel_w / 2;
            pnt2[0].Y = 0;
            pnt2[1].X = panel_w / 2;
            pnt2[1].Y = panel_w;
            pnt2[2].X = 0;
            pnt2[2].Y = panel_w;
            pea.Graphics.DrawRectangle(myPen, 0, 0, panel_w, panel_w);
            pea.Graphics.DrawPolygon(myPen, pnt2);

            pnt2[0].X = panel_w / 2;
            pnt2[0].Y = 0;
            pnt2[1].X = panel_w / 2;
            pnt2[1].Y = panel_w;
            pnt2[2].X = panel_w;
            pnt2[2].Y = panel_w;
            pea.Graphics.DrawRectangle(myPen, 0, 0, panel_w, panel_w);
            pea.Graphics.FillPolygon(brush, pnt2);
            pea.Graphics.DrawPolygon(myPen, pnt2);
        }

        // etoile ////

        void NOEUD()
        {
            pea.Graphics.FillEllipse(brush, panel_w / 4, panel_w / 4, panel_w / 2, panel_w / 2);
        }

        // IACM

        void IACM(string ouv)
        {
            Point point1 = new Point(0, panel_w / 2);
            Point point2 = new Point(panel_w / 2, 0);
            Point point3 = new Point(panel_w, panel_w / 2);
            Point point4 = new Point(panel_w / 2, panel_w);
            Point[] curvePoints =
             {
                 point1,
                 point2,
                 point3,
                 point4
             };
            pea.Graphics.DrawPolygon(myPen, curvePoints);

            if(ouv != "")
            pea.Graphics.FillPolygon(brush2, curvePoints);
        }

        // CEL ///////////////////

        void CEL()
        {
            myPen = new Pen(Color.ForestGreen, 3);
            pea.Graphics.DrawRectangle(myPen, 2, 2, panel_w-3, panel_w-3);
        }

        // JB ///////////////////

        void JB()
        {
            pea.Graphics.FillRectangle(brush1, 0, 0, panel_w+1 , panel_w+1);
        }

        // OCR /////

        public void panel_NOM_paint(object sender, PaintEventArgs e)
        {
            if (cmpt >= string_nom_ocr.Count)
            {
                cmpt = 0;
            }

            e.Graphics.DrawString(string_nom_ocr[cmpt], new Font("Tahoma", 8), Brushes.Black, 0, 0);

            cmpt++;
        }

        private void panel_click(object sender, EventArgs e)
        {
            //original.chercher(((Panel)sender).Name);
            string name_ocr = ((Panel)sender).Name;
            if (name_ocr.ToUpper().Contains("P") && name_ocr.Length > 4)
            original.calcul(name_ocr.Substring(0,3), name_ocr.Remove(0,4));
        }

        private void panel_doubleclick(object sender, EventArgs e)
        {
            original.chercher(((Panel)sender).Name);
        }
    }
}
