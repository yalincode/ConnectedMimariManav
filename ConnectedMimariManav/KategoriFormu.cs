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
    public partial class KategoriFormu : Form
    {
        
        KategoriRepo kategoriRepo;
        public KategoriFormu()
        {
            InitializeComponent();
            kategoriRepo = new KategoriRepo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FillGrid();
        }

        private void FillGrid()
        {
            dataGridView1.DataSource = kategoriRepo.GetAll();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var kategori = (dataGridView1.DataSource as List<Kategori>)[e.RowIndex];

            KategoriEklemeFormu eklemeFormu = new KategoriEklemeFormu();
            eklemeFormu.Tag = kategori.KategoriID;
            eklemeFormu.ShowDialog();
            FillGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KategoriEklemeFormu eklemeFormu = new KategoriEklemeFormu();
            eklemeFormu.ShowDialog();
            FillGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
