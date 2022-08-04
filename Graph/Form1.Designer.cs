namespace Graph
{
    partial class Form1
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
            this.valider = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ocr = new System.Windows.Forms.TextBox();
            this.tb_district = new System.Windows.Forms.TextBox();
            this.panel_gros = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p1 = new System.Windows.Forms.Panel();
            this.ll1 = new System.Windows.Forms.Label();
            this.l1 = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Panel();
            this.ll2 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.p3 = new System.Windows.Forms.Panel();
            this.ll3 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.p4 = new System.Windows.Forms.Panel();
            this.ll4 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();
            this.p5 = new System.Windows.Forms.Panel();
            this.ll5 = new System.Windows.Forms.Label();
            this.l5 = new System.Windows.Forms.Label();
            this.p6 = new System.Windows.Forms.Panel();
            this.ll6 = new System.Windows.Forms.Label();
            this.l6 = new System.Windows.Forms.Label();
            this.p7 = new System.Windows.Forms.Panel();
            this.ll7 = new System.Windows.Forms.Label();
            this.l7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_detail3 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_minimise = new System.Windows.Forms.PictureBox();
            this.pb_close = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.p1.SuspendLayout();
            this.p2.SuspendLayout();
            this.p3.SuspendLayout();
            this.p4.SuspendLayout();
            this.p5.SuspendLayout();
            this.p6.SuspendLayout();
            this.p7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_minimise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).BeginInit();
            this.SuspendLayout();
            // 
            // valider
            // 
            this.valider.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valider.Location = new System.Drawing.Point(177, 59);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(75, 23);
            this.valider.TabIndex = 0;
            this.valider.Text = "Valider";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Ocr / Noeud : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 59;
            this.label3.Text = "N° District : ";
            // 
            // tb_ocr
            // 
            this.tb_ocr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ocr.Location = new System.Drawing.Point(93, 59);
            this.tb_ocr.MaxLength = 7;
            this.tb_ocr.Name = "tb_ocr";
            this.tb_ocr.Size = new System.Drawing.Size(79, 21);
            this.tb_ocr.TabIndex = 58;
            this.tb_ocr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ocr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ocr_KeyPress);
            // 
            // tb_district
            // 
            this.tb_district.Location = new System.Drawing.Point(93, 29);
            this.tb_district.MaxLength = 3;
            this.tb_district.Name = "tb_district";
            this.tb_district.Size = new System.Drawing.Size(48, 20);
            this.tb_district.TabIndex = 57;
            this.tb_district.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_district_KeyPress);
            // 
            // panel_gros
            // 
            this.panel_gros.BackColor = System.Drawing.Color.Snow;
            this.panel_gros.Location = new System.Drawing.Point(2, 151);
            this.panel_gros.Name = "panel_gros";
            this.panel_gros.Size = new System.Drawing.Size(952, 520);
            this.panel_gros.TabIndex = 61;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.p1);
            this.panel1.Controls.Add(this.p2);
            this.panel1.Controls.Add(this.p3);
            this.panel1.Controls.Add(this.p4);
            this.panel1.Controls.Add(this.p5);
            this.panel1.Controls.Add(this.p6);
            this.panel1.Controls.Add(this.p7);
            this.panel1.Location = new System.Drawing.Point(298, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 125);
            this.panel1.TabIndex = 62;
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.Transparent;
            this.p1.Controls.Add(this.ll1);
            this.p1.Controls.Add(this.l1);
            this.p1.Location = new System.Drawing.Point(541, 0);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(129, 121);
            this.p1.TabIndex = 1;
            // 
            // ll1
            // 
            this.ll1.AutoSize = true;
            this.ll1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll1.Location = new System.Drawing.Point(3, 28);
            this.ll1.Name = "ll1";
            this.ll1.Size = new System.Drawing.Size(0, 18);
            this.ll1.TabIndex = 1;
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.Location = new System.Drawing.Point(2, 6);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(0, 18);
            this.l1.TabIndex = 0;
            // 
            // p2
            // 
            this.p2.BackColor = System.Drawing.Color.Transparent;
            this.p2.Controls.Add(this.ll2);
            this.p2.Controls.Add(this.l2);
            this.p2.Location = new System.Drawing.Point(451, 0);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(90, 121);
            this.p2.TabIndex = 1;
            // 
            // ll2
            // 
            this.ll2.AutoSize = true;
            this.ll2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll2.Location = new System.Drawing.Point(3, 28);
            this.ll2.Name = "ll2";
            this.ll2.Size = new System.Drawing.Size(0, 18);
            this.ll2.TabIndex = 1;
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l2.Location = new System.Drawing.Point(2, 6);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(0, 18);
            this.l2.TabIndex = 0;
            // 
            // p3
            // 
            this.p3.BackColor = System.Drawing.Color.Transparent;
            this.p3.Controls.Add(this.ll3);
            this.p3.Controls.Add(this.l3);
            this.p3.Location = new System.Drawing.Point(361, 0);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(90, 121);
            this.p3.TabIndex = 1;
            // 
            // ll3
            // 
            this.ll3.AutoSize = true;
            this.ll3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll3.Location = new System.Drawing.Point(3, 28);
            this.ll3.Name = "ll3";
            this.ll3.Size = new System.Drawing.Size(0, 18);
            this.ll3.TabIndex = 1;
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l3.Location = new System.Drawing.Point(2, 6);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(0, 18);
            this.l3.TabIndex = 0;
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.Color.Transparent;
            this.p4.Controls.Add(this.ll4);
            this.p4.Controls.Add(this.l4);
            this.p4.Location = new System.Drawing.Point(271, 0);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(90, 121);
            this.p4.TabIndex = 1;
            // 
            // ll4
            // 
            this.ll4.AutoSize = true;
            this.ll4.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll4.Location = new System.Drawing.Point(3, 28);
            this.ll4.Name = "ll4";
            this.ll4.Size = new System.Drawing.Size(0, 18);
            this.ll4.TabIndex = 1;
            // 
            // l4
            // 
            this.l4.AutoSize = true;
            this.l4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l4.Location = new System.Drawing.Point(2, 6);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(0, 18);
            this.l4.TabIndex = 0;
            // 
            // p5
            // 
            this.p5.BackColor = System.Drawing.Color.Transparent;
            this.p5.Controls.Add(this.ll5);
            this.p5.Controls.Add(this.l5);
            this.p5.Location = new System.Drawing.Point(181, 0);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(90, 121);
            this.p5.TabIndex = 2;
            // 
            // ll5
            // 
            this.ll5.AutoSize = true;
            this.ll5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll5.Location = new System.Drawing.Point(3, 28);
            this.ll5.Name = "ll5";
            this.ll5.Size = new System.Drawing.Size(0, 18);
            this.ll5.TabIndex = 1;
            // 
            // l5
            // 
            this.l5.AutoSize = true;
            this.l5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l5.Location = new System.Drawing.Point(2, 6);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(0, 18);
            this.l5.TabIndex = 0;
            // 
            // p6
            // 
            this.p6.BackColor = System.Drawing.Color.Transparent;
            this.p6.Controls.Add(this.ll6);
            this.p6.Controls.Add(this.l6);
            this.p6.Location = new System.Drawing.Point(91, 0);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(90, 121);
            this.p6.TabIndex = 1;
            // 
            // ll6
            // 
            this.ll6.AutoSize = true;
            this.ll6.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll6.Location = new System.Drawing.Point(3, 28);
            this.ll6.Name = "ll6";
            this.ll6.Size = new System.Drawing.Size(0, 18);
            this.ll6.TabIndex = 1;
            // 
            // l6
            // 
            this.l6.AutoSize = true;
            this.l6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l6.Location = new System.Drawing.Point(2, 6);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(0, 18);
            this.l6.TabIndex = 0;
            // 
            // p7
            // 
            this.p7.BackColor = System.Drawing.Color.Transparent;
            this.p7.Controls.Add(this.ll7);
            this.p7.Controls.Add(this.l7);
            this.p7.Location = new System.Drawing.Point(1, 0);
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(90, 121);
            this.p7.TabIndex = 0;
            // 
            // ll7
            // 
            this.ll7.AutoSize = true;
            this.ll7.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll7.Location = new System.Drawing.Point(3, 28);
            this.ll7.Name = "ll7";
            this.ll7.Size = new System.Drawing.Size(0, 18);
            this.ll7.TabIndex = 1;
            // 
            // l7
            // 
            this.l7.AutoSize = true;
            this.l7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l7.Location = new System.Drawing.Point(2, 6);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(0, 18);
            this.l7.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Snow;
            this.panel2.Controls.Add(this.lb_detail3);
            this.panel2.Location = new System.Drawing.Point(722, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 106);
            this.panel2.TabIndex = 63;
            // 
            // lb_detail3
            // 
            this.lb_detail3.BackColor = System.Drawing.Color.Snow;
            this.lb_detail3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_detail3.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_detail3.Location = new System.Drawing.Point(5, 4);
            this.lb_detail3.Multiline = true;
            this.lb_detail3.Name = "lb_detail3";
            this.lb_detail3.ReadOnly = true;
            this.lb_detail3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lb_detail3.Size = new System.Drawing.Size(235, 98);
            this.lb_detail3.TabIndex = 1;
            this.lb_detail3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.pb_minimise);
            this.panel3.Controls.Add(this.pb_close);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(972, 23);
            this.panel3.TabIndex = 65;
            this.panel3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDoubleClick);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(22, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 18);
            this.label1.TabIndex = 67;
            this.label1.Text = "Graph V1.0.      DD Chlef Nord - Division Téchnique Electricité";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Graph.Properties.Resources._187743_100002222418596_2705003_q;
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 66;
            this.pictureBox1.TabStop = false;
            // 
            // pb_minimise
            // 
            this.pb_minimise.Image = global::Graph.Properties.Resources.math_minus_icon1;
            this.pb_minimise.Location = new System.Drawing.Point(914, 2);
            this.pb_minimise.Name = "pb_minimise";
            this.pb_minimise.Size = new System.Drawing.Size(20, 21);
            this.pb_minimise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_minimise.TabIndex = 66;
            this.pb_minimise.TabStop = false;
            this.pb_minimise.Click += new System.EventHandler(this.pb_minimise_Click);
            // 
            // pb_close
            // 
            this.pb_close.Image = global::Graph.Properties.Resources.Close_2_icon;
            this.pb_close.Location = new System.Drawing.Point(945, 2);
            this.pb_close.Name = "pb_close";
            this.pb_close.Size = new System.Drawing.Size(20, 21);
            this.pb_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_close.TabIndex = 0;
            this.pb_close.TabStop = false;
            this.pb_close.Click += new System.EventHandler(this.pb_close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(951, 658);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 66;
            this.label2.Text = "BZ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(972, 674);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_gros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_ocr);
            this.Controls.Add(this.tb_district);
            this.Controls.Add(this.valider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRAPH - DD Chlef Nord";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            this.p2.ResumeLayout(false);
            this.p2.PerformLayout();
            this.p3.ResumeLayout(false);
            this.p3.PerformLayout();
            this.p4.ResumeLayout(false);
            this.p4.PerformLayout();
            this.p5.ResumeLayout(false);
            this.p5.PerformLayout();
            this.p6.ResumeLayout(false);
            this.p6.PerformLayout();
            this.p7.ResumeLayout(false);
            this.p7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_minimise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ocr;
        private System.Windows.Forms.TextBox tb_district;
        private System.Windows.Forms.Panel panel_gros;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Panel p2;
        private System.Windows.Forms.Panel p3;
        private System.Windows.Forms.Panel p4;
        private System.Windows.Forms.Panel p5;
        private System.Windows.Forms.Panel p6;
        private System.Windows.Forms.Panel p7;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.Label l6;
        private System.Windows.Forms.Label l7;
        private System.Windows.Forms.Label ll1;
        private System.Windows.Forms.Label ll2;
        private System.Windows.Forms.Label ll3;
        private System.Windows.Forms.Label ll4;
        private System.Windows.Forms.Label ll5;
        private System.Windows.Forms.Label ll6;
        private System.Windows.Forms.Label ll7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox lb_detail3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pb_close;
        private System.Windows.Forms.PictureBox pb_minimise;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;



    }
}

