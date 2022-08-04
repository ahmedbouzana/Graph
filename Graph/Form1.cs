using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Graph
{
    public partial class Form1 : Form
    {
        afficher af;

        OleDbConnection con;
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader rd;
        List<string> relations = new List<string>(), relations1 = new List<string>(), string_nom_ocr = new List<string>(), string_troncon = new List<string>(), liste_i = new List<string>(), liste_j = new List<string>();
        decimal longueur = 0;
        string date1, code_ouv, ouv, nom_depart, t2, prefix = null;
        int x1, y1, x_initial, y_initial, lol = 94 , lal = 7, lap = 23, ext = 80;
        bool ta2, ts2, effacer = false, telecom, tel;
        Brush brush = default(Brush);
        List<int> dimention = new List<int>(); List<string> dimentiona1 = new List<string>();
        DataTable table_acc = new DataTable(), table_mac_a = new DataTable(), table_mac_b = new DataTable(), table_mac_c_d = new DataTable();
        

        public Form1()
        {
            InitializeComponent();
            af = new afficher(this,panel_gros);
            x_initial = panel_gros.Width;
            y_initial = panel_gros.Height;
            brush = new SolidBrush(Color.Red);
        }
        
        private void valider_Click(object sender, EventArgs e)
        {
            chercher(tb_district.Text + tb_ocr.Text);
        }

        private void tb_district_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 13)
            {
                e.Handled = true;
            }
            else
                if (e.KeyChar == (char)Keys.Return)
                {
                    tb_ocr.Focus();
                    tb_ocr.Select(0, 7);
                    e.Handled = true;
                }
        }

        private void tb_ocr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                //initialiser();
                chercher(tb_district.Text + tb_ocr.Text);
            }
        }

        // //////////////////////////////////////////////////////////////////////////////////////////////////

        internal void chercher(string ocr)
        {
            if (ocr != null && ocr.Length >= 5)
            {
                tb_district.Text = ocr.Substring(0, 3);
                tb_ocr.Text = ocr.Remove(0, 3);
                tb_ocr.Focus();
                panel_gros.Controls.Clear();
                l1.Text = l2.Text = l3.Text = l4.Text = l5.Text = l6.Text = "";
                ll1.Text = ll2.Text = ll3.Text = ll4.Text = ll5.Text = ll6.Text = ll7.Text = lb_detail3.Text = "";

                x1 = x_initial; y1 = y_initial;
                if (connecter())
                {
                    try
                    {
                        string_troncon.Clear();
                        string_nom_ocr.Clear();
                        dimentiona1.Clear();
                        relations.Clear();
                        dimention.Clear();

                        if (effacer)
                        {
                            try
                            {
                                af.string_troncon.Clear();
                                af.string_nom_ocr.Clear();
                                af.dimentiona1.Clear();
                                af.dimention.Clear();
                            }
                            catch{}
                        }
                        effacer = true;

                        con.Open();

                        cmd = con.CreateCommand();

                        if (!ocr.ToUpper().Contains("B"))
                        {
                            cmd.CommandText = "select  * from " + prefix + "segment where noeud1 ='" + ocr + "'";
                            rd = cmd.ExecuteReader();
                            while (rd.Read())
                            {
                                relations.Add(rd["noeud2"].ToString());
                                relations.Add(rd["troncon"].ToString());
                            }
                            rd.Close();

                            cmd.CommandText = "select  * from " + prefix + "segment where noeud2 = '" + ocr + "'";
                            rd = cmd.ExecuteReader();
                            while (rd.Read())
                            {
                                relations.Add(rd["noeud1"].ToString());
                                relations.Add(rd["troncon"].ToString());
                            }
                            rd.Close();
                        }

                        //lb_ocr.Text = ocr;

                        if (relations.Count > 0)
                        {
                            x1 = (int)x1 / 2 - 11;
                            y1 = (int)y1 / 2 - 11;

                            af.cmp = 0;
                            af.x1 = x1;
                            af.y1 = y1;


                            type_ocr(ocr.ToUpper());

                            /////////////////////////////////////


                            af.cm = 0;
                            af.cmpt = 0;
                            af.cmpte = 0;
                            for (int i = 0; i < relations.Count; i += 2)
                            {
                                string_troncon.Add("T" + relations[i + 1]);
                                switch (i)
                                {
                                    case 0:
                                        dimention.Add(nature_arc(relations[i], ocr));
                                        dimention.Add(0);
                                        dimention.Add(3);
                                        dimention.Add(lol + ext);
                                        dimention.Add(3);

                                        af.xpl = x1 - lol - ext;
                                        af.ypl = y1 + 9;
                                        af.xps = lol + ext;
                                        af.yps = lal;

                                        af.ligne(relations[i] + "_" + ocr);

                                        chercher1(relations[i], ocr);
                                        swotch1(i, relations[i]);
                                        break;
                                    case 2:
                                        dimention.Add(nature_arc(ocr, relations[i]));
                                        dimention.Add(0);
                                        dimention.Add(3);
                                        dimention.Add(lol + ext);
                                        dimention.Add(3);

                                        af.xpl = x1 + lap;
                                        af.ypl = y1 + 9;
                                        af.xps = lol + ext;
                                        af.yps = lal;

                                        af.ligne(relations[i] + "_" + ocr);

                                        chercher1(relations[i], ocr);
                                        swotch1(i, relations[i]);
                                        break;
                                    case 4:
                                        dimention.Add(nature_arc(ocr, relations[i]));
                                        dimention.Add(3);
                                        dimention.Add(0);
                                        dimention.Add(3);
                                        dimention.Add(lol);

                                        af.xpl = x1 + 9;
                                        af.ypl = y1 + lap;
                                        af.xps = lal;
                                        af.yps = lol;

                                        af.ligne(relations[i] + "_" + ocr);

                                        chercher1(relations[i], ocr);
                                        swotch1(i, relations[i]);
                                        break;
                                    case 6:
                                        dimention.Add(nature_arc(relations[i], ocr));
                                        dimention.Add(3);
                                        dimention.Add(0);
                                        dimention.Add(3);
                                        dimention.Add(lol);

                                        af.xpl = x1 + 9;
                                        af.ypl = y1 - lol;
                                        af.xps = lal;
                                        af.yps = lol;

                                        af.ligne(relations[i] + "_" + ocr);

                                        chercher1(relations[i], ocr);
                                        swotch1(i, relations[i]);
                                        break;
                                }
                            }

                            af.dimentiona1 = dimentiona1;
                            af.dimention = dimention;
                            af.string_nom_ocr = string_nom_ocr;
                            af.string_troncon = string_troncon;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        //Panel pp = new Panel();
                        //panel_gros.Controls.Add(pp);
                        //pp.Location = new Point(5, 5);
                        //pp.Size = new Size(900, 500);
                        //pp.BackColor = System.Drawing.Color.Blue;


                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Les données sont invalides !!", "Erreur !!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tb_district.Focus();
            }
        }

        int nature_arc(string ocr, string ocr1)
        {
            t2 = null;
            ta2 = true; ts2 = true;
            cmd.CommandText = "select  * from " + prefix + "arc where noeud1 ='" + ocr + "' and noeud2 ='" + ocr1 + "' order by noeud1, n_arc";
            rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    if (ta2 && rd["nat_arc"].ToString() == "A")
                    {
                        t2 += "1";
                        ta2 = false;
                    }
                    else if (ts2 && rd["nat_arc"].ToString() == "S")
                    {
                        t2 += "6";
                        ts2= false;
                    }
                }
                rd.Close();
            }
            else
            {
                rd.Close();

                cmd.CommandText = "select  * from " + prefix + "arc where noeud1 ='" + ocr1 + "' and noeud2 ='" + ocr + "' order by noeud1, n_arc";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                    while (rd.Read())
                    {
                        if (ta2 && rd["nat_arc"].ToString() == "A")
                        {
                            t2 = "1" + t2;
                            ta2 = false;
                        }
                        else if (ts2 && rd["nat_arc"].ToString() == "S")
                        {
                            t2 = "6" + t2;
                            ts2 = false;
                        }
                    }
                rd.Close();
            }
            if (t2 != null)
                return Convert.ToInt32(t2);
            else
                return 1;
        }

        protected void type_ocr(string ocr1)
        {
            string_nom_ocr.Add(ocr1);

            tel = false;
            ouv = "";
            if (ocr1.Contains("P"))
            {
                string ta, tp = "DP";
                cmd.CommandText = "select * from " + prefix + "coup_cmp where agence = " + tb_district.Text + " and t_noeud = 'P' and  n_noeud = " + ocr1.Remove(0, ocr1.IndexOf("P") + 1) + " and t_compos = 'J'";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    ta = "AA";
                    while (rd.Read())
                    {
                        if (rd["telecom"].ToString() == "O")
                        {
                            tel = true;
                            break;
                        }
                    }
                }
                else
                {
                    ta = "SA";
                }
                rd.Close();

                cmd.CommandText = "select  * from " + prefix + "poste_lig where agence = " + tb_district.Text + " and  n_noeud = " + ocr1.Remove(0, ocr1.IndexOf("P") + 1) + "";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    if (rd["t_poste"] != DBNull.Value)
                    {
                        tp = rd["fonction"].ToString();
                    }
                }
                rd.Close();

                af.brush = brush;
                //af.myPen = mp1;
                dimentiona1.Add(ta);
                dimentiona1.Add(tp);

                cmd.CommandText = "select  * from " + prefix + "ouverture";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        code_ouv = rd["code"].ToString().ToUpper();

                        if (code_ouv.Contains("J") && code_ouv.Contains("P"))
                        {
                            if (code_ouv.Remove(code_ouv.Length - 2) == ocr1.ToUpper())
                            {
                                ouv = "1";
                                break;
                            }
                        }
                    }
                }
                rd.Close();
                dimentiona1.Add(ouv);

                af.dessiner(ocr1, tel);
            }
            else
            {
                if (ocr1.Contains("E"))
                {
                    af.brush = brush;
                    dimentiona1.Add("NOEUD");
                    dimentiona1.Add("0");
                    dimentiona1.Add("");

                    af.dessiner(ocr1, tel);
                }
                else
                {
                    if (ocr1.Contains("J"))
                    {
                        dimentiona1.Add("IACM");
                        dimentiona1.Add("0");

                        cmd.CommandText = "select  * from " + prefix + "ouverture";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                code_ouv = rd["code"].ToString().ToUpper();

                                if (code_ouv.Contains("J"))
                                {
                                    if (code_ouv == ocr1.ToUpper())
                                    {
                                        ouv = "1";
                                        break;
                                    }
                                }
                            }
                        }
                        rd.Close();
                        dimentiona1.Add(ouv);

                        cmd.CommandText = "select * from " + prefix + "coup_lig where agence = " + tb_district.Text + " and t_noeud = 'J' and  n_noeud = " + ocr1.Remove(0, ocr1.IndexOf("J") + 1) + "";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                if (rd["telecom"].ToString() == "O")
                                {
                                    tel = true;
                                    break;
                                }
                            }
                        }
                        rd.Close();
                        af.dessiner(ocr1, tel);
                    }
                    else
                    {
                        if (ocr1.Contains("C"))
                        {
                            dimentiona1.Add("CEL");
                            dimentiona1.Add("0");
                            dimentiona1.Add("");
                            af.dessiner(ocr1, tel);
                        }
                        else
                        {
                            if (ocr1.Contains("B"))
                            {
                                dimentiona1.Add("JB");
                                dimentiona1.Add("0");
                                dimentiona1.Add("");
                                af.dessiner(ocr1, tel);
                            }
                        }
                    }
                }
            }
            //else
        }

        // ////////////////////////////

        private void chercher1(string ocr1, string ocr0)
        {
            relations1.Clear();

            if (!ocr1.ToUpper().Contains("B"))
            {
                cmd.CommandText = "select  * from " + prefix + "segment where noeud1 ='" + ocr1 + "' and noeud2 <> '" + ocr0 + "'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    relations1.Add(rd["noeud2"].ToString());
                    relations1.Add(rd["troncon"].ToString());
                }
                rd.Close();

                cmd.CommandText = "select  * from " + prefix + "segment where noeud2 = '" + ocr1 + "' and noeud1 <> '" + ocr0 + "'";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    relations1.Add(rd["noeud1"].ToString());
                    relations1.Add(rd["troncon"].ToString());
                }
                rd.Close();
            }
        }

        private void swotch1(int j, string ocr)
        {
            switch (j)
            {
                case 0:

                    af.x1 = x1 - lol - ext - lap;
                    af.y1 = y1;
                    type_ocr(relations[j].ToUpper());
                    for (int i = 0; i < relations1.Count; i += 2)
                    {
                        string_troncon.Add("T" + relations1[i + 1]);
                        switch (i)
                        {
                            case 0:
                                dimention.Add(nature_arc(relations1[i],ocr));
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);
                                dimention.Add(3);

                                af.xpl = x1 - lol - lap - lol - ext;
                                af.ypl = y1 + 9;
                                af.xps = lol;
                                af.yps = lal;

                                af.x1 = x1 - lol - ext - lap - lol -lap;
                                af.y1 = y1;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 2:
                                dimention.Add(nature_arc(ocr, relations1[i]));
                                dimention.Add(3);
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);

                                af.xpl = x1 - lol - lap + 9 - ext;
                                af.ypl = y1 + lap;
                                af.xps = lal;
                                af.yps = lol;

                                af.x1 = x1 - lol - ext - lap;
                                af.y1 = y1 + lap + lol;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 4:
                                dimention.Add(nature_arc(relations1[i],ocr));
                                dimention.Add(3);
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);

                                af.xpl = x1 - lol - lap + 9 - ext;
                                af.ypl = y1 - lol;
                                af.xps = lal;
                                af.yps = lol;

                                af.x1 = x1 - lol - ext - lap;
                                af.y1 = y1 - lol - lap;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                        }
                    }
                    break;

                case 2:
                    af.x1 = x1 + lap + lol + ext;
                    af.y1 = y1;
                    type_ocr(relations[j].ToUpper());
                    for (int i = 0; i < relations1.Count; i += 2)
                    {
                        string_troncon.Add("T" + relations1[i + 1]);
                        switch (i)
                        {
                            case 0:
                                dimention.Add(nature_arc(ocr, relations1[i]));
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);
                                dimention.Add(3);

                                af.xpl = x1 + lap + lol + lap + ext;
                                af.ypl = y1 + 9;
                                af.xps = lol;
                                af.yps = lal;

                                af.x1 = x1 + lap + lol + ext + lap + lol;
                                af.y1 = y1;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 2:
                                dimention.Add(nature_arc(ocr, relations1[i]));
                                dimention.Add(3);
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);

                                af.xpl = x1 + lap + lol + 9 + ext;
                                af.ypl = y1 + lap;
                                af.xps = lal;
                                af.yps = lol;

                                af.x1 = x1 + lap + lol + ext;
                                af.y1 = y1 + lap + lol;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 4:
                                dimention.Add(nature_arc(relations1[i],ocr));
                                dimention.Add(3);
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);

                                af.xpl = x1 + lap + lol + 9 + ext;
                                af.ypl = y1 - lol;
                                af.xps = lal;
                                af.yps = lol;

                                af.x1 = x1 + lap + lol + ext;
                                af.y1 = y1 - lol - lap;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                        }
                    }
                    break;

                case 4:

                    af.x1 = x1;
                    af.y1 = y1 + lap + lol;
                    type_ocr(relations[j].ToUpper());
                    for (int i = 0; i < relations1.Count; i += 2)
                    {
                        string_troncon.Add("T" + relations1[i + 1]);
                        switch (i)
                        {
                            case 0:
                                dimention.Add(nature_arc(ocr, relations1[i]));
                                dimention.Add(3);
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);

                                af.xpl = x1 + 9;
                                af.ypl = y1 + lap + lol + lap;
                                af.xps = lal;
                                af.yps = lol;

                                af.x1 = x1;
                                af.y1 = y1 + lap + lol + lap + lol;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 2:
                                dimention.Add(nature_arc(relations1[i],ocr));
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);
                                dimention.Add(3);

                                af.xpl = x1 - lol;
                                af.ypl = y1 + lap + lol + 9;
                                af.xps = lol;
                                af.yps = lal;

                                af.x1 = x1 - lol - lap;
                                af.y1 = y1 + lap + lol;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 4:
                                dimention.Add(nature_arc(ocr, relations1[i]));
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);
                                dimention.Add(3);

                                af.xpl = x1 + lap;
                                af.ypl = y1 + lap + lol + 9;
                                af.xps = lol;
                                af.yps = lal;

                                af.x1 = x1 + lap + lol;
                                af.y1 = y1 + +lap + lol;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                        }
                    }
                    break;

                case 6:

                    af.x1 = x1;
                    af.y1 = y1 - lol - lap;
                    type_ocr(relations[j].ToUpper());
                    for (int i = 0; i < relations1.Count; i += 2)
                    {
                        string_troncon.Add("T" + relations1[i + 1]);
                        switch (i)
                        {
                            case 0:
                                dimention.Add(nature_arc(relations1[i],ocr));
                                dimention.Add(3);
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);

                                af.xpl = x1 + 9;
                                af.ypl = y1 - lol - lap - lol;
                                af.xps = lal;
                                af.yps = lol;

                                af.x1 = x1;
                                af.y1 = y1 - lol - lap -lol -lap;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 2:
                                dimention.Add(nature_arc(relations1[i],ocr));
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);
                                dimention.Add(3);

                                af.xpl = x1 - lol;
                                af.ypl = y1 - lol - lap + 9;
                                af.xps = lol;
                                af.yps = lal;

                                af.x1 = x1 - lol - lap;
                                af.y1 = y1 - lol - lap;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                            case 4:
                                dimention.Add(nature_arc(ocr, relations1[i]));
                                dimention.Add(0);
                                dimention.Add(3);
                                dimention.Add(lol);
                                dimention.Add(3);

                                af.xpl = x1 + lap;
                                af.ypl = y1 - lol - lap + 9;
                                af.xps = lol;
                                af.yps = lal;

                                af.x1 = x1 + lap + lol;
                                af.y1 = y1 - lol - lap;
                                type_ocr(relations1[i].ToUpper());

                                af.ligne(relations1[i] + "_" + ocr);
                                break;
                        }
                    }
                    break;
            }
        }

        // //////////////////////////////////////

        protected bool connecter()
        {
            //if (System.IO.File.Exists(@"C:\base\gdo.accdb"))
            //{
            //    con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\base\gdo.accdb;Persist Security Info=False;");
            //    return true;
            //}
            //else
            //    if (System.IO.File.Exists(@"C:\base\gdo.mdb"))
            //    {
            //        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\base\gdo.mdb");
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Base des donnees introuvable ! C:\\base\\gdo");
            //        return true;
            //    }

            if (System.IO.File.Exists("gdo.accdb"))
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=gdo.accdb;Persist Security Info=False;");
                return true;
            }
            else
                if (System.IO.File.Exists("gdo.mdb"))
                {
                    con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=gdo.mdb");
                    return true;
                }
                else
                {
                    MessageBox.Show("Base des donnees introuvable ! gdo.accdb  OU  gdo.mdb");
                    return false;
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (connecter())
            {
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "select  * from gdo_segment";
                    rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    { prefix = "gdo_"; }
                    rd.Close();
                }
                catch{}
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            tb_district.Select();

            remplir_datatible();
        }

        internal void calcul(string d, string p)
        {
            try
            {
                con.Open();
                date1 = null;
                l1.Text = l2.Text = l3.Text = l4.Text = l5.Text = l6.Text = "";
                ll1.Text = ll2.Text = ll3.Text = ll4.Text = ll5.Text = ll6.Text = ll7.Text = lb_detail3.Text = "";
                int nb_tst = 0;
                cmd = con.CreateCommand();
                cmd.CommandText = "select  * from " + prefix + "trsfomt_bt, " + prefix + "constructeurs where agence = " + d + " and  n_noeud = " + p + " and  trsfomt_bt.construct = constructeurs.construct";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    l1.Text = "Nom_cst";
                    l2.Text = "N_serie";
                    l3.Text = "An_mes";
                    l4.Text = "Fonction";
                    l5.Text = "P.m.d.";
                    l6.Text = "Puissance";
                    ll7.Text = "Transformateur:";
                    while (rd.Read())
                    {
                        date1 = (rd["an_mes"].ToString().Length >= 10 ? rd["an_mes"].ToString().Substring(0, 10) : "/");

                        nb_tst++;
                        ll1.Text = ll1.Text + rd["nom_cst"] + "\n";
                        ll2.Text = ll2.Text + rd["n_transf"] + "\n";
                        ll3.Text = ll3.Text + date1 + "\n";
                        ll4.Text = ll4.Text + rd["fonction"] + "\n";
                        ll5.Text = ll5.Text + rd["pmd"] + "\n";
                        ll6.Text = ll6.Text + rd["p_nom"] + "\n";
                    }
                }
                else
                {
                    lb_detail3.Text = "Il n y a pas d enregistrement sur la base des donnees !!!";
                }
                rd.Close();

                int coup_i = 0, coup_s = 0, isol_i = 0, hastrst = 0;
                telecom = false;
                string dep1 = null, arr1 = null, isol1 = null;
                //////////////////////////////
                try
                {
                    liste_j = new List<string>();
                    liste_i = new List<string>();

                    cmd.CommandText = "select  * from " + prefix + "coup_cmp, " + prefix + "constructeurs where agence = " + d + " and  n_noeud = " + p + " and constructeurs.construct = coup_cmp.construct";
                    rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            if (rd["telecom"].ToString().ToUpper() == "O")
                                telecom = true;

                            switch (rd["t_compos"].ToString().ToUpper())
                            {
                                case "J":
                                    liste_j.Add(rd["n_compos"].ToString().Trim());
                                    liste_j.Add(rd["nom_cst"] + "\r\n    N_serie: " + rd["n_serie"] + ".");

                                    if (rd["fonction"].ToString() == "S")
                                        coup_s++;
                                    else
                                        coup_i++;
                                    break;
                                case "I":
                                    liste_i.Add(rd["nom_cst"] + "\r\n    N_serie: " + rd["n_serie"] + ".");

                                    hastrst = 1;
                                    isol_i++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    rd.Close();

                    int c_dep = 0, c_arr = 0, c_isol = 0;
                    cmd.CommandText = "select  * from " + prefix + "segment where noeud1 ='" + d + "P" + p + "' or noeud2 = '" + d + "P" + p + "'";
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd["noeud1"].ToString().Trim() == (d + "P" + p).Trim())
                        {
                            c_dep++;
                            for (int k = 0; k < liste_j.Count; k = k + 2)
                            {
                                if (rd["borne1"].ToString().Trim() == liste_j[k])
                                {
                                    dep1 += "\r\nConst_Dep J" + c_dep + ": " + liste_j[k + 1];
                                    break;
                                }
                            }
                        }
                        else
                        {
                            c_arr++;
                            for (int k = 0; k < liste_j.Count; k = k + 2)
                            {
                                if (rd["borne2"].ToString().Trim() == liste_j[k])
                                {
                                    arr1 += "\r\nConst_Arr J" + c_arr + ": " + liste_j[k + 1];
                                    break;
                                }
                            }
                        }
                    }
                    rd.Close();

                    foreach (string st in liste_i)
                    {
                        c_isol++;
                        isol1 += "\r\nConst_Isol I" + c_isol + ": " + st;
                    }
                }
                catch
                {
                    coup_i = 0; coup_s = 0; isol_i = 0; hastrst = 0;
                    telecom = false;
                }

                ////////////////////////////////

                string fonction = null, f1 = null, f2 = null, f3 = null, f4 = null, tp_ocr = null;
                int p_instal = 0;
                cmd.CommandText = "select  * from " + prefix + "poste_lig where agence = " + d + " and  n_noeud = " + p + "";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    fonction = rd["fonction"].ToString().ToUpper();
                    tp_ocr = rd["t_poste"].ToString().ToUpper();
                    p_instal = Convert.ToInt32(rd["p_instal"]);

                    f1 = "Poste: " + d + "P" + p + "_" + fonction + "  " + tp_ocr;
                    f2 = "\r\nNom: " + rd["nom_pst"] + "\r\nLocalité: " + rd["localite"] + ".\r\nDépart: ";
                    nom_depart = rd["n_depart"].ToString();
                    f4 = "\r\nAn_mes: " + (rd["an_mes"].ToString().Length >= 10 ? rd["an_mes"].ToString().Substring(0, 10) : "/");;

                    rd.Close();

                    try
                    {
                        cmd.CommandText = "select  * from " + prefix + "dep_ali where cellul = '" + nom_depart + "'";
                        rd = cmd.ExecuteReader();
                        if (rd.HasRows)
                        {
                            rd.Read();
                            nom_depart += " -"+ rd["nom"].ToString();
                        }
                        rd.Close();
                    }
                    catch { }
                    f2 += nom_depart;

                    if (tp_ocr.Length > 1)
                    {
                        tp_ocr = tp_ocr.Substring(0, 1);
                        if (tp_ocr == "M" || tp_ocr == "I")
                        {
                            if (telecom)
                            {
                                //MessageBox.Show(fonction + "  " + coup_i + "  " + coup_s + "  " + isol_i);
                                foreach (DataRow row in table_mac_c_d.Rows)
                                {
                                    if (row[0].ToString() == fonction && row[1].ToString() == coup_i.ToString() && row[2].ToString() == coup_s.ToString() && row[3].ToString() == isol_i.ToString())
                                    {
                                        f3 = "MAC_CD_" + row[4].ToString();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (nb_tst == 1)
                                {
                                    foreach (DataRow row in table_mac_a.Rows)
                                    {
                                        if (row[0].ToString() == fonction && row[1].ToString() == coup_i.ToString() && row[2].ToString() == coup_s.ToString() && row[3].ToString() == isol_i.ToString())
                                        {
                                            f3 = "MAC_A_" + row[4].ToString();
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (nb_tst > 1)
                                    {
                                        foreach (DataRow row in table_mac_b.Rows)
                                        {
                                            if (row[0].ToString() == fonction && row[1].ToString() == coup_i.ToString() && row[2].ToString() == coup_s.ToString() && row[3].ToString() == isol_i.ToString())
                                            {
                                                f3 = "MAC_B_" + row[4].ToString();
                                                break;
                                            }
                                        }
                                    }
                                    /////////////////
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow row in table_acc.Rows)
                            {
                                if (row[0].ToString() == fonction && row[1].ToString() == hastrst.ToString() && row[2].ToString() == p_instal.ToString())
                                {
                                    f3 = row[3].ToString();
                                    break;
                                }
                            }
                        }
                        if (f3 != "" && f3 != null)
                            f3 = " -(" + f3 + ")";
                        lb_detail3.Text = f1 + f3 + f2 + f4 + arr1 + dep1 + isol1; ;
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        internal void calcul1(string a, string b)
        {
            try
            {
                date1 = null;
                con.Open();

                l1.Text = l2.Text = l3.Text = l4.Text = l5.Text = l6.Text = "";
                ll1.Text = ll2.Text = ll3.Text = ll4.Text = ll5.Text = ll6.Text = ll7.Text = lb_detail3.Text = "";

                longueur = 0;

                cmd = con.CreateCommand();
                cmd.CommandText = "select  * from " + prefix + "arc where (noeud1 = '" + a.Trim() + "' and noeud2 = '" + b.Trim() + "') or (noeud1 = '" + b + "' and noeud2 = '" + a + "') order by n_arc";
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    l1.Text = "An_mes";
                    l2.Text = "Nat_cond";
                    l3.Text = "Nat_arc";
                    l4.Text = "Longueur";
                    l5.Text = "Section";
                    ll6.Text = "Tronçon:";
                    while (rd.Read())
                    {
                        date1 = (rd["an_mes"].ToString().Length >= 10 ? rd["an_mes"].ToString().Substring(0, 10) : "/");

                        ll1.Text = ll1.Text + date1 + "\n";
                        ll2.Text = ll2.Text + rd["nat_cond"] + "\n";
                        ll3.Text = ll3.Text + rd["nat_arc"] + "\n";
                        ll4.Text = ll4.Text + rd["longueur"] + "\n";
                        ll5.Text = ll5.Text + rd["section"] + "\n";

                        longueur += Convert.ToDecimal(rd["longueur"]);
                    }
                    lb_detail3.Text = "Tronçon:  " + a + "-" + b + "\r\nLongueur: " + longueur + " m.";
                }
                else
                {
                    lb_detail3.Text = "Il n y a pas d enregistrement sur la base des donnees !!!";
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        void remplir_datatible()
        {

            table_acc.Columns.Add("ocr", typeof(string));
            table_acc.Columns.Add("appreil", typeof(string));
            table_acc.Columns.Add("charge", typeof(string));
            table_acc.Columns.Add("type", typeof(string));
            DataRow workRow;
            int j = 0;
            for (int i = 1; i >= 0; i--)
            {
                workRow = table_acc.NewRow();
                workRow[0] = "AB";
                workRow[1] = i.ToString();
                workRow[2] = "50";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
                workRow = table_acc.NewRow();
                workRow[0] = "AB";
                workRow[1] = i.ToString();
                workRow[2] = "63";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
                workRow = table_acc.NewRow();
                workRow[0] = "AB";
                workRow[1] = i.ToString();
                workRow[2] = "100";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
                workRow = table_acc.NewRow();
                workRow[0] = "AB";
                workRow[1] = i.ToString();
                workRow[2] = "160";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
            }

            for (int i = 1; i >= 0; i--)
            {
                workRow = table_acc.NewRow();
                workRow[0] = "DP";
                workRow[1] = i.ToString();
                workRow[2] = "50";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
                workRow = table_acc.NewRow();
                workRow[0] = "DP";
                workRow[1] = i.ToString();
                workRow[2] = "63";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
                workRow = table_acc.NewRow();
                workRow[0] = "DP";
                workRow[1] = i.ToString();
                workRow[2] = "100";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
                workRow = table_acc.NewRow();
                workRow[0] = "DP";
                workRow[1] = i.ToString();
                workRow[2] = "160";
                workRow[3] = "ACC_" + ++j;
                table_acc.Rows.Add(workRow);
            }

            ///////////////////////////////////////////////////////

            table_mac_a.Columns.Add("fonction", typeof(string));
            table_mac_a.Columns.Add("Coup_I", typeof(int));
            table_mac_a.Columns.Add("Coup_S", typeof(int));
            table_mac_a.Columns.Add("Isol_I", typeof(int));
            table_mac_a.Columns.Add("Types", typeof(int));

            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 1;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 2;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 3;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 4;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 0;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 5;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 1;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 6;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 0;
            workRow[4] = 7;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 0;
            workRow[4] = 8;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 0;
            workRow[4] = 9;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 0;
            workRow[4] = 10;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 0;
            workRow[4] = 11;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 0;
            workRow[4] = 12;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 0;
            workRow[2] = 2;
            workRow[3] = 1;
            workRow[4] = 13;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 14;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 15;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 3;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 16;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "AB";
            workRow[1] = 3;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 17;
            table_mac_a.Rows.Add(workRow);
            workRow = table_mac_a.NewRow();
            workRow[0] = "DP";
            workRow[1] = 4;
            workRow[2] = 2;
            workRow[3] = 1;
            workRow[4] = 18;
            table_mac_a.Rows.Add(workRow);

            ////////////////////////
            table_mac_b.Columns.Add("fonction", typeof(string));
            table_mac_b.Columns.Add("Coup_I", typeof(int));
            table_mac_b.Columns.Add("Coup_S", typeof(int));
            table_mac_b.Columns.Add("Isol_I", typeof(int));
            table_mac_b.Columns.Add("Types", typeof(int));

            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 1;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 2;
            workRow[4] = 2;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 3;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 2;
            workRow[4] = 4;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 0;
            workRow[4] = 5;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 3;
            workRow[2] = 1;
            workRow[3] = 0;
            workRow[4] = 6;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "AB";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 2;
            workRow[4] = 7;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "DP";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 2;
            workRow[4] = 8;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "AB";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 2;
            workRow[4] = 9;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 2;
            workRow[4] = 10;
            table_mac_b.Rows.Add(workRow);

            ////////////
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 1;
            workRow[2] = 0;
            workRow[3] = 2;
            workRow[4] = 11;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "AB";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 3;
            workRow[4] = 12;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "DB";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 3;
            workRow[4] = 13;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "AB";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 3;
            workRow[4] = 14;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "DB";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 3;
            workRow[4] = 15;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "AB";
            workRow[1] = 4;
            workRow[2] = 2;
            workRow[3] = 1;
            workRow[4] = 16;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "MX";
            workRow[1] = 3;
            workRow[2] = 1;
            workRow[3] = 2;
            workRow[4] = 17;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "AB";
            workRow[1] = 4;
            workRow[2] = 3;
            workRow[3] = 0;
            workRow[4] = 18;
            table_mac_b.Rows.Add(workRow);
            workRow = table_mac_b.NewRow();
            workRow[0] = "DB";
            workRow[1] = 4;
            workRow[2] = 2;
            workRow[3] = 0;
            workRow[4] = 19;
            table_mac_b.Rows.Add(workRow);


            /////////////////////////////////////////////////
            table_mac_c_d.Columns.Add("fonction", typeof(string));
            table_mac_c_d.Columns.Add("Coup_I", typeof(int));
            table_mac_c_d.Columns.Add("Coup_S", typeof(int));
            table_mac_c_d.Columns.Add("Isol_I", typeof(int));
            table_mac_c_d.Columns.Add("Types", typeof(int));

            workRow = table_mac_c_d.NewRow();
            workRow[0] = "DP";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 1;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "DP";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 2;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "DP";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 3;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "DP";
            workRow[1] = 3;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 4;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "MX";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 2;
            workRow[4] = 5;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "MX";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 2;
            workRow[4] = 6;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "MX";
            workRow[1] = 3;
            workRow[2] = 0;
            workRow[3] = 2;
            workRow[4] = 7;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "MX";
            workRow[1] = 2;
            workRow[2] = 1;
            workRow[3] = 2;
            workRow[4] = 8;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "AB";
            workRow[1] = 1;
            workRow[2] = 1;
            workRow[3] = 1;
            workRow[4] = 9;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "AB";
            workRow[1] = 2;
            workRow[2] = 0;
            workRow[3] = 1;
            workRow[4] = 10;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "AB";
            workRow[1] = 1;
            workRow[2] = 0;
            workRow[3] = 3;
            workRow[4] = 11;
            table_mac_c_d.Rows.Add(workRow);
            workRow = table_mac_c_d.NewRow();
            workRow[0] = "DP";
            workRow[1] = 1;
            workRow[2] = 0;
            workRow[3] = 4;
            workRow[4] = 12;
            table_mac_c_d.Rows.Add(workRow);
        }

        int xx_l = 972, yy_l = 674;
        bool mouseIsDown = false, mouseIsDown1 = false;
        Point firstPoint;
        int x1_l, y1_l, x2_l, y2_l;

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {

            try
            {
                if (mouseIsDown && mouseIsDown1)
                {
                    // Get the difference between the two points
                    int xDiff = firstPoint.X - e.Location.X;
                    int yDiff = firstPoint.Y - e.Location.Y;

                    // Set the new point
                    int x = this.Location.X - xDiff;
                    int y = this.Location.Y - yDiff;
                    this.Location = new Point(x, y);



                    x1_l = Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - xx_l;
                    y1_l = Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - yy_l;

                    x2_l = this.Location.X;
                    y2_l = this.Location.Y;

                    if (x2_l > x1_l)
                    {
                        this.SetBounds(x1_l, y2_l, xx_l, yy_l);
                        mouseIsDown = false;
                    }
                    else if (x2_l < Screen.PrimaryScreen.WorkingArea.X)
                    {
                        this.SetBounds(0, y2_l, xx_l, yy_l);
                        mouseIsDown = false;
                    }
                    else
                    {
                        mouseIsDown = true;
                    }



                    if (y2_l > Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - yy_l)
                    {
                        this.SetBounds(x2_l, y1_l, xx_l, yy_l);
                        mouseIsDown1 = false;
                    }
                    else if (y2_l < Screen.PrimaryScreen.WorkingArea.Y)
                    {
                        this.SetBounds(x2_l, 0, xx_l, yy_l);
                        mouseIsDown1 = false;
                    }
                    else
                    {
                        mouseIsDown1 = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
            mouseIsDown1 = false;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
            mouseIsDown1 = true;

            //firstPoint = e.Location;

            //x1_l = Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - xx_l;
            //y1_l = Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - yy_l;

            //x2_l = this.Location.X;
            //y2_l = this.Location.Y;

            //if (x2_l > x1_l)
            //{
            //    this.SetBounds(x1_l, y2_l, xx_l, yy_l);
            //    mouseIsDown = false;
            //}
            //else if (x2_l < Screen.PrimaryScreen.WorkingArea.X)
            //{
            //    this.SetBounds(0, y2_l, xx_l, yy_l);
            //    mouseIsDown = false;
            //}
            //else
            //{
            //    mouseIsDown = true;
            //}



            //if (y2_l > Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - yy_l)
            //{
            //    this.SetBounds(x2_l, y1_l, xx_l, yy_l);
            //    mouseIsDown1 = false;
            //}
            //else if (y2_l < Screen.PrimaryScreen.WorkingArea.Y)
            //{
            //    this.SetBounds(x2_l, 0, xx_l, yy_l);
            //    mouseIsDown1 = false;
            //}
            //else
            //{
            //    mouseIsDown1 = true;
            //}
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pb_minimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
