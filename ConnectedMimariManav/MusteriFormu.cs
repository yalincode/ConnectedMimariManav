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
    public partial class MusteriFormu : Form
    {
        MusteriRepo musteriRepo;
        public MusteriFormu()
        {
            InitializeComponent();
            musteriRepo = new MusteriRepo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MusteriEklemeFormu form = new MusteriEklemeFormu();
            form.ShowDialog();
            FillDataGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            Musteri musteri = (dataGridView1.DataSource as List<Musteri>)[e.RowIndex];
            MusteriEklemeFormu form = new MusteriEklemeFormu();
            form.Tag = musteri.MusteriID;
            form.ShowDialog();
            FillDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            dataGridView1.DataSource = musteriRepo.GetAll();
        }
    }
}
