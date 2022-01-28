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
    public partial class MusteriEklemeFormu : Form
    {

        MusteriRepo repo;
        Musteri selectedMusteri = null;
        public MusteriEklemeFormu()
        {
            InitializeComponent();
            repo = new MusteriRepo();
        }

        private void MusteriEklemeFormu_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            int MusteriID = Convert.ToInt32(this.Tag);
            if (MusteriID>0)
            {
                var Musteri = repo.Get(MusteriID);
                if (Musteri != null)
                {
                    selectedMusteri = Musteri;
                    txtMusteriAd.Text = Musteri.MusteriAd;
                    txtMusteriSoyad.Text=Musteri.MusteriSoyad;
                    txtMusteriTelefon.Text = Musteri.MusteriTelefon;
                    txtMusteriAdres.Text = Musteri.MusteriAdres;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();

        }

        private void FormSave()
        {
            try
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "" || txtMusteriTelefon.Text=="")
                {
                    MessageBox.Show("Lütfen alanları düzgün doldurun.");
                    return;
                }
                if (selectedMusteri == null)
                {
                    selectedMusteri = new Musteri();
                }
                selectedMusteri.MusteriAd = txtMusteriAd.Text;
                selectedMusteri.MusteriSoyad = txtMusteriSoyad.Text;
                selectedMusteri.MusteriTelefon = txtMusteriTelefon.Text;
                selectedMusteri.MusteriAdres = txtMusteriAdres.Text;
                if (Convert.ToInt32(this.Tag) == 0)
                {
                    selectedMusteri.MusteriID = repo.Create(selectedMusteri);
                    this.Tag = selectedMusteri.MusteriID;
                }
                else
                {
                    selectedMusteri.MusteriID = repo.Update(selectedMusteri);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMusteri == null)
            {
                return;
            }
            else
            {
                int id = selectedMusteri.MusteriID;
                repo.Delete(id);
                this.Close();
            }
        }
    }
}
