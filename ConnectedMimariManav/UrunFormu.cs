using ConnectedMimariManav.Entities;
using ConnectedMimariManav.Repository;
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
    public partial class UrunFormu : Form
    {
        UrunRepo repo;
        public UrunFormu()
        {
            InitializeComponent();
            repo = new UrunRepo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrunEklemeFormu form=new UrunEklemeFormu();
            form.ShowDialog();
            FillDataGrid();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex==-1)
            {
                return;
            }
            var urun=(dataGridView1.DataSource as List<Urun>)[e.RowIndex];
            
            UrunEklemeFormu form = new UrunEklemeFormu();
            form.Tag = urun.UrunID;
            form.ShowDialog();
            FillDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            dataGridView1.DataSource=repo.GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
