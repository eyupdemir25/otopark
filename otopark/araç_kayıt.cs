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
    public partial class araç_kayıt : Form
    {
        public araç_kayıt()
        {
            InitializeComponent();
        }
        OleDbConnection conn= new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = otopark.mdb");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        void arac_tipi_goster()
        {
            conn.Open();
            string sql = "SELECT * FROM aractipleri";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader oku = cmd.ExecuteReader();


            while (oku.Read())
            {
                comboBox1.Items.Add(oku.GetString(1));
                comboBox2.Items.Add(oku.GetString(1));
            }
            conn.Close();
        }
        void verileri_goster()
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM kayitlar", conn);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            string sorgu = "INSERT INTO kayitlar (aractipi,aracplaka,tarih,girisSaati) " +
            "VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker2.Value.ToString("HH:mm:ss") + "')";
              
            
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sorgu, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            
            verileri_goster();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void araç_kayıt_Load(object sender, EventArgs e)
        {
            arac_tipi_goster();
            verileri_goster();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kimlik=int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string sorgu = "UPDATE kayitlar SET aractipi='" + comboBox2.Text + "',aracplaka='" + textBox2.Text + "',tarih='" + dateTimePicker4.Text + "',girisSaati='" + dateTimePicker2.Text + "'WHERE Kimlik=" + kimlik +"";

            OleDbCommand guncelle = new OleDbCommand(sorgu, conn);
            conn.Open();
            guncelle.ExecuteNonQuery();
            conn.Close();

            verileri_goster();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult deneme_buton = MessageBox.Show("SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ", "UYARI!", MessageBoxButtons.YesNo);
            if (deneme_buton == DialogResult.Yes)
            {
                string sorgu = "DELETE FROM kayitlar WHERE Kimlik=" + textBox3.Text + "";

                OleDbCommand sql_komut = new OleDbCommand(sorgu, conn);

                conn.Open();
                sql_komut.ExecuteNonQuery();
                conn.Close();
                verileri_goster();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("VERİLERİ EKSİKSİZ GİRİN!");

            }

            else
            {
                MessageBox.Show("veriler silinmedİ");

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            menu anamenu = new menu();
            this.Hide();
            anamenu.ShowDialog();
        }
    }
}
