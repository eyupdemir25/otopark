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
    public partial class arac_cikis : Form
    {
        public arac_cikis()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = otopark.mdb");
        private void button2_Click(object sender, EventArgs e)
        {

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
        private void arac_cikis_Load(object sender, EventArgs e)
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
