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
    public partial class KategoriEklemeFormu : Form
    {
        KategoriRepo repo;
        Kategori selectedKategori=null;
        public KategoriEklemeFormu()
        {
            InitializeComponent();
            repo = new KategoriRepo();
        }

        private void KategoriEklemeFormu_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            int KategoriID = Convert.ToInt32(this.Tag);
            
            if (KategoriID>0)
            {
                var Kategori = repo.Get(KategoriID);
                if (KategoriID!=0)
                {
                    selectedKategori = Kategori;
                    txtKategoriAd.Text = Kategori.KategoriAd;
                    txtKategoriDes.Text = Kategori.KategoriDes; 
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            if (selectedKategori==null)
            {
                selectedKategori=new Kategori();
            }
            selectedKategori.KategoriAd=txtKategoriAd.Text;
            selectedKategori.KategoriDes=txtKategoriDes.Text;

            if (Convert.ToInt32(this.Tag)==0)
            {
                selectedKategori.KategoriID = repo.Create(selectedKategori);
                this.Tag = selectedKategori.KategoriID;
            }
            else
            {
                selectedKategori.KategoriID = repo.Update(selectedKategori);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedKategori == null)
            {
                return;
            }
            else
            {
                int id = selectedKategori.KategoriID;
                repo.Delete(id);
                this.Close();
            }
            
        }
    }
}
