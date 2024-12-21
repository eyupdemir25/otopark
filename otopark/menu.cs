using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otopark
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            araç_kayıt kayıt = new araç_kayıt();
            kayıt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arac_cikis cikis = new arac_cikis();
            cikis.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            arac_fiyat fiyat = new arac_fiyat();
            fiyat.ShowDialog();

        }
    }
}
