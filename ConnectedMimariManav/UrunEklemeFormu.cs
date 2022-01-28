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
    public partial class UrunEklemeFormu : Form
    {
        KategoriRepo kategoriRepo;
        MusteriRepo musteriRepo;
        UrunRepo urunRepo;
        Urun selectedUrun = null;
        public UrunEklemeFormu()
        {
            InitializeComponent();
            kategoriRepo = new KategoriRepo();
            urunRepo = new UrunRepo();
            musteriRepo = new MusteriRepo();
        }

        private void UrunEklemeFormu_Load(object sender, EventArgs e)
        {
            FillForm();
            
        }

        private void FillForm()
        {
            FillControls();
            FillDatas();
        }

        private void FillDatas()
        {
            int UrunID=(Convert.ToInt32(this.Tag));
            if (UrunID>0)
            {
                var Urun = urunRepo.Get(UrunID);
                if (Urun!=null)
                {
                    selectedUrun=Urun;
                    txtUrunAdi.Text = Urun.UrunAd;
                    nuSiparis.Value = Convert.ToDecimal(Urun.Siparis);
                    nuUrunFiyat.Value = Convert.ToDecimal(Urun.UnitPrice);
                    NuStok.Value = Convert.ToDecimal(Urun.Stok);
                    cmbKategori.SelectedValue = Urun.KategoriID;
                    cmbMusteri.SelectedValue=Urun.MusteriID;
                }
            }
        }

        private void FillControls()
        {
            FillMusteri();
            FillKategori();
        }

        private void FillKategori()
        {
            var Kategoriler = kategoriRepo.GetAll();
            cmbKategori.DataSource = Kategoriler;
            cmbKategori.ValueMember = "KategoriID";
            cmbKategori.DisplayMember = "KategoriAd";
        }

        private void FillMusteri()
        {
            var Musteriler=musteriRepo.GetAll();
            cmbMusteri.DataSource = Musteriler;
            cmbMusteri.ValueMember = "MusteriID";
            cmbMusteri.DisplayMember = "MusteriAd";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {
                if (txtUrunAdi.Text == "" || nuUrunFiyat.Value==0  || Convert.ToInt16(NuStok.Value) == 0 || Convert.ToInt16(nuSiparis.Value) ==0)
                {
                    MessageBox.Show("Lütfen alanları düzgün doldurun.");
                    return;
                }
                if (selectedUrun == null)
                {
                    selectedUrun = new Urun();
                }
                selectedUrun.UrunAd = txtUrunAdi.Text;
                selectedUrun.KategoriID = Convert.ToInt32(cmbKategori.SelectedValue);
                selectedUrun.MusteriID = Convert.ToInt32(cmbMusteri.SelectedValue);
                selectedUrun.UnitPrice = nuUrunFiyat.Value;
                selectedUrun.Stok = Convert.ToInt16(NuStok.Value);
                selectedUrun.Siparis = Convert.ToInt16(nuSiparis.Value);

                if (Convert.ToInt32(this.Tag) == 0)
                {
                    int UrunID = urunRepo.Create(selectedUrun);
                    selectedUrun.UrunID = UrunID;
                    this.Tag = UrunID;
                }
                else
                {
                    selectedUrun.UrunID = urunRepo.Update(selectedUrun);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUrun == null)
            {
                return;
            }
            else
            {
                int id = selectedUrun.UrunID;
                urunRepo.Delete(id);
                this.Close();
            }
        }
    }
}
