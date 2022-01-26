using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectedMimariManav
{
    public partial class ManavAnaForm : Form
    {
        public ManavAnaForm()
        {
            InitializeComponent();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            KategoriFormu form=new KategoriFormu();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MusteriFormu form=new MusteriFormu();
            form.ShowDialog();
        }
    }
}
