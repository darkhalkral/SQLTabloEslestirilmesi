using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace ders11
{
    public partial class Form1 : Form
    {
        OleDbConnection con;
        Hashtable ht = new Hashtable();
        Hashtable ht2 = new Hashtable();
        Hashtable ht3 = new Hashtable();
        public Form1()
        {
            InitializeComponent();
        }

        void baglanti()
        {
            ht.Clear();
            ht2.Clear();
            ht3.Clear();
            dataGridView1.Rows.Clear();
            con = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0; Data Source=C:\\Users\\halid\\source\\repos\\deneme.mdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader dr;
            cmd.Connection = con;
            cmd.CommandText = "Select * from ogrenci4";
            con.Open();
            dr = cmd.ExecuteReader();
            int i = 1;
            while (dr.Read())
            {
                ht.Add(i, dr["ogrno"]);
                i++;
                ht.Add(i, dr["ad"]);
                i++;
                ht.Add(i, dr["soyad"]);
                i++;
                ht.Add(i, dr["dyeri"]);
                i++;
                ht.Add(i, dr["dtarihi"]);
                i++;
            }
            con.Close();
            cmd.CommandText = "Select * from ders";
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ht2.Add(dr["dno"], dr["dadı"]);
            }
            con.Close();
            cmd.CommandText = "Select * from dnot";
            con.Open();
            dr = cmd.ExecuteReader();
            i = 1;
            while (dr.Read())
            {
                ht3.Add(i, dr["ogrno"]);
                i++;
                ht3.Add(i, dr["dno"]);
                i++;
                ht3.Add(i, dr["vize1"]);
                i++;
                ht3.Add(i, dr["vize2"]);
                i++;
                ht3.Add(i, dr["final"]);
                i++;
            }
            con.Close();
            for (int k = 1; k <= ht3.Count; k+=5)
            {
                for (int l = 1; l < ht.Count; l+=5)
                {
                    if(ht[l].ToString()==ht3[k].ToString())
                    {
                        dataGridView1.Rows.Add(ht[l], ht[l + 1], ht[l + 2], ht[l + 3], ht[l + 4], ht2[ht3[k + 1]], ht3[k + 2], ht3[k + 3], ht3[k + 4]);
                    }
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Öğrenci No";
            dataGridView1.Columns[1].Name = "Ad";
            dataGridView1.Columns[2].Name = "Soyad";
            dataGridView1.Columns[3].Name = "Doğum Yeri";
            dataGridView1.Columns[4].Name = "Doğum Tarihi";
            dataGridView1.Columns[5].Name = "Ders Adı";
            dataGridView1.Columns[6].Name = "Vize1";
            dataGridView1.Columns[7].Name = "Vize2";
            dataGridView1.Columns[8].Name = "Final";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            int sayi = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Kaç Değer Gireceksiniz"));
            for (int i = 0; i < sayi; i++)
            { 
                //veri ekleme
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti();
        }
    }
}
