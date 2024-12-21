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
    public partial class arac_fiyat : Form
    {
        public arac_fiyat()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = otopark.mdb");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void verileri_goster()
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM aractipleri", conn);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO aractipleri (aractipi,saatücreti) " +
           "VALUES ('" + textBox1.Text + "','"+textBox2.Text+"')";


            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            verileri_goster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kimlik = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string sorgu = "UPDATE aractipleri SET aractipi='" + textBox4.Text + "',saatücreti='" +textBox3.Text + "'WHERE Kimlik=" + kimlik + "";

            OleDbCommand guncelle = new OleDbCommand(sorgu, conn);
            conn.Open();
            guncelle.ExecuteNonQuery();
            conn.Close();

            verileri_goster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM aractipleri WHERE Kimlik=" + textBox6.Text + "";

            OleDbCommand sql_komut = new OleDbCommand(sorgu, conn);

            conn.Open();
            sql_komut.ExecuteNonQuery();
            conn.Close();
            verileri_goster();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void arac_fiyat_Load(object sender, EventArgs e)
        {
            verileri_goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu anamenu = new menu();
            this.Hide();
            anamenu.ShowDialog();

            
        }
    }
}
