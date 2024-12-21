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

namespace otopark
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        OleDbConnection conn=new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = otopark.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "SELECT * FROM kullanicilar WHERE k_adi='" + kullaniciAdiTextbox.Text + "' AND parola='" + parolaText.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader oku = cmd.ExecuteReader();

            if(oku.Read())
            {
                
                araç_kayıt kayıt = new araç_kayıt();
                kayıt.ShowDialog();
            }
            else
            {
                MessageBox.Show("girilen bilgiler yanlış!!!");

            }
            conn.Close();
        }
    }
}
