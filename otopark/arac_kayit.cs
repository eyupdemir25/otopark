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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace otopark
{
    public partial class arac_kayit : Form
    {
        public arac_kayit()
        {
            InitializeComponent();
        }
        OleDbConnection conn= new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = otopark.mdb");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO kayitlar (aractipi,aracplaka,tarih,girisSaati) " +
            "VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";

            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
         private void aractipi()
        {
            conn.Open();
            string sql = "SELECT * FROM aractipleri ";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader oku = cmd.ExecuteReader();


            while(oku.Read())
            {
                comboBox1.Items.Add(oku[1]);
                comboBox2.Items.Add(oku[1]);

                
            }
            conn.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM kayitlar", conn);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void arac_kayit_Load(object sender, EventArgs e)
        {
            aractipi();
        }
    }
}
