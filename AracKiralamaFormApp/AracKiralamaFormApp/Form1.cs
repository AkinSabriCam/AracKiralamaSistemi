using AracKiralamaWebService;
using Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaFormApp
{
    public partial class Form1 : Form
    {
        public int sirketId { get; set; }
        public int aracId { get; set; }
        public int musteriId { get; set; }
        public int calisanId { get; set; }
        public DateTime baslangic { get; set; }
        public DateTime bitis { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private string Encrypt(string clearText)
        {  // kullanıcı şifresinin kodlanarak şifrelendiği metotdur.
            // şifreyi kodlanmış  şekilde geri döndürür.
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private void tumAraclarMenu_Click(object sender, EventArgs e)
        {
            aracListele();

        }
        public void aracListele()
        {
            grpAllCars.Visible = true;
            grbGiris.Visible = false;
            grbAracBilgileri.Visible = false;
            grbAracKirala.Visible = false;
            grbCalisanlar.Visible = false;
            grbKiralamaGecmisi.Visible = false;
            grbTalepler.Visible = false;
            grbTarihBilgileri.Visible = false;
            grpAllCars.Width = 1200;
            grpAllCars.Height = 400;
            dgwAllCars.Width = 1100;
            grpAllCars.Location = new Point(50,50);
            AracWebService aracWebService = new AracWebService();
            var model = aracWebService.GetAllCars(sirketId);

            dgwAllCars.DataSource = model;


            dgwAllCars.Columns[1].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grbGiris.Visible = true;
            grbGiris.Width = 1200;
            grbGiris.Height = 400;
            grbGiris.Location = new Point(50, 50);

            btnGuncelle.Enabled = false;

        }

        private void btnGiriş_Click_1(object sender, EventArgs e)
        {
            var kullaniciWebService = new KullaniciWebService();
            var sifre = Encrypt(txtPassword.Text);
            var model = kullaniciWebService.GetByUsernamePassword(txtUsername.Text, sifre);
            if (model != null)
            {
                sirketId = Convert.ToInt16(model.sirketID);
                if (model.rolID == 1)
                {
                    aracKiralaMenu.Visible = true;
                    kiralamaTalepleriMenu.Visible = true;
                    kiralamaGecmisiMenu.Visible = true;
                    cikisMenu.Visible = true;

                }
                else if (model.rolID == 2)
                {
                    aracKiralaMenu.Visible = true;
                    kiralamaTalepleriMenu.Visible = true;
                    kiralamaGecmisiMenu.Visible = true;
                    tumAraclarMenu.Visible = true;
                    calisanlarMenu.Visible = true;
                    cikisMenu.Visible = true;
                }
                grbGiris.Visible = false;
            }
        }


        private void dgwAllCars_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            aracId = Convert.ToInt16(dgwAllCars.CurrentRow.Cells[0].Value);
            txtMarka.Text = dgwAllCars.CurrentRow.Cells[3].Value.ToString();
            txtModel.Text = dgwAllCars.CurrentRow.Cells[4].Value.ToString();
            txtFiyat.Text = dgwAllCars.CurrentRow.Cells[12].Value.ToString();
            txtGunlukKm.Text = dgwAllCars.CurrentRow.Cells[7].Value.ToString();
            txtKm.Text = dgwAllCars.CurrentRow.Cells[8].Value.ToString();
            txtKoltuk.Text = dgwAllCars.CurrentRow.Cells[11].Value.ToString();
            txtEhliyetyas.Text = dgwAllCars.CurrentRow.Cells[6].Value.ToString();
            txtBagaj.Text = dgwAllCars.CurrentRow.Cells[10].Value.ToString();
            txtYas.Text = dgwAllCars.CurrentRow.Cells[5].Value.ToString();
            if (dgwAllCars.CurrentRow.Cells[9].Value.ToString() == "True")
                cmbBxAirbag.SelectedIndex = 0;
            else
                cmbBxAirbag.SelectedIndex = 1;

            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            AracWebService aracWebService = new AracWebService();
            Arac arac = new Arac();
            if (cmbBxAirbag.Text == "Var")
                arac.airbag = true;
            else
                arac.airbag = false;
            arac.bagajHacmi = Convert.ToInt16(txtBagaj.Text);
            arac.ehliyetYasi = Convert.ToInt16(txtEhliyetyas.Text);
            arac.gunlukFiyat = Convert.ToDecimal(txtFiyat.Text);
            arac.gunlukKm = Convert.ToInt16(txtGunlukKm.Text);
            arac.koltukSayisi = Convert.ToInt16(txtKoltuk.Text);
            arac.KM = Convert.ToUInt32(txtKm.Text);
            arac.marka = txtMarka.Text;
            arac.model = txtModel.Text;
            arac.sirketID = sirketId;
            arac.yasSiniri = Convert.ToInt16(txtYas.Text);

            aracWebService.Add(arac);
            aracListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            AracWebService aracWebService = new AracWebService();
            Arac arac = new Arac();
            if (cmbBxAirbag.Text == "Var")
                arac.airbag = true;
            else
                arac.airbag = false;
            arac.aracID = aracId;
            arac.bagajHacmi = Convert.ToInt16(txtBagaj.Text);
            arac.ehliyetYasi = Convert.ToInt16(txtEhliyetyas.Text);
            arac.gunlukFiyat = Convert.ToDecimal(txtFiyat.Text);
            arac.gunlukKm = Convert.ToInt16(txtGunlukKm.Text);
            arac.koltukSayisi = Convert.ToInt16(txtKoltuk.Text);
            arac.KM = Convert.ToUInt32(txtKm.Text);
            arac.marka = txtMarka.Text;
            arac.model = txtModel.Text;
            arac.sirketID = sirketId;
            arac.yasSiniri = Convert.ToInt16(txtYas.Text);

            aracWebService.Update(arac);
            aracListele();

        }

        private void btnCalisanEkle_Click(object sender, EventArgs e)
        {
            KullaniciWebService kullaniciWebService = new KullaniciWebService();
            Kullanici kullanici = new Kullanici();
            
            kullanici.adi = txtCalisanAd.Text;
            kullanici.soyadi = txtCalisanSoyad.Text;
            kullanici.username = txtCalisanUsername.Text;
            kullanici.password = Encrypt(txtCalisanpwd.Text);
            kullanici.rolID = 1;
            kullanici.sirketID = sirketId;

            kullaniciWebService.Add(kullanici);
            calisanListele();
        }

        private void calisanlarMenu_Click(object sender, EventArgs e)
        {
            calisanListele();
        }
        public void calisanListele()
        {

            grbCalisanlar.Visible = true;
            grbGiris.Visible = false;
            grbAracBilgileri.Visible = false;
            grbAracKirala.Visible = false;
            grbKiralamaGecmisi.Visible = false;
            grbTalepler.Visible = false;
            grbTarihBilgileri.Visible = false;
            grpAllCars.Visible = false;
            grbCalisanlar.Width = 1200;
            grbCalisanlar.Height = 400;
            dgwCalisanlar.Width = 1100;
            grbCalisanlar.Location = new Point(50, 50);
            KullaniciWebService kullaniciWebService = new KullaniciWebService();
            var model = kullaniciWebService.Get(sirketId);

            dgwCalisanlar.DataSource = model;

            btnSil.Enabled = false;

            dgwCalisanlar.Columns[0].Visible = false;
            dgwCalisanlar.Columns[1].Visible = false;
            dgwCalisanlar.Columns[3].Visible = false;
            dgwCalisanlar.Columns[4].Visible = false;
            dgwCalisanlar.Columns[7].Visible = false;
            dgwCalisanlar.Columns[8].Visible = false;


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            KullaniciWebService kullaniciWebService = new KullaniciWebService();
            kullaniciWebService.Delete(calisanId);
            calisanListele();
            btnSil.Enabled = false;
            btnCalisanEkle.Enabled = true;
        }

        private void dgwCalisanlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSil.Enabled = true;
            btnCalisanEkle.Enabled = false;
            calisanId = Convert.ToInt16(dgwCalisanlar.CurrentRow.Cells[0].Value);

        }

        private void btnKiralıkArac_Click(object sender, EventArgs e)
        {
            grbTarihBilgileri.Visible = false;
            grbAracBilgileri.Visible = true;

            grbAracBilgileri.Width = 1200;
            grbAracBilgileri.Height = 600;
            grbAracBilgileri.Location = new Point(50, 50);

            dgwKiralikAraclar.Width = 1100;
            baslangic = dtBaslangic.Value;
            bitis = dtBitis.Value;
            txtBasTar.Text = baslangic.ToString();
            txtBitTar.Text = bitis.ToString();
            kiralikAraclar();


        }
        public void kiralikAraclar()
        {
            AracWebService aracWebService = new AracWebService();
            var model = aracWebService.GetForUsers(baslangic, bitis, sirketId);

            dgwKiralikAraclar.DataSource = model;
        }

        private void aracKiralaMenu_Click(object sender, EventArgs e)
        {
            grbAracKirala.Visible = true;
            grbGiris.Visible = false;
            grbAracBilgileri.Visible = false;
            grbCalisanlar.Visible = false;
            grbKiralamaGecmisi.Visible = false;
            grbTalepler.Visible = false;
            grbTarihBilgileri.Visible = false;
            grpAllCars.Visible = false;
            grbTarihBilgileri.Visible = true;
            grbTarihBilgileri.Width = 600;
            grbTarihBilgileri.Height = 400;
            grbAracKirala.Width = 1300;
            grbAracKirala.Height = 600;
            grbAracKirala.Location = new Point(50, 50);
            grbTarihBilgileri.Location = new Point(50, 50);

        }

        private void dgwKiralikAraclar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            aracId = Convert.ToInt16(dgwKiralikAraclar.CurrentRow.Cells[0].Value);

            txtAracMarka.Text = dgwKiralikAraclar.CurrentRow.Cells[3].Value.ToString();
            txtAracModel.Text = dgwKiralikAraclar.CurrentRow.Cells[4].Value.ToString();
            txtAracId.Text = dgwKiralikAraclar.CurrentRow.Cells[0].Value.ToString();

            btnKirala.Enabled = true;

        }

        private void btnKirala_Click(object sender, EventArgs e)
        {
            MusteriBilgileri musteri = new MusteriBilgileri();
            musteri.adi = txtAd.Text;
            musteri.soyadi = txtSoyad.Text;
            musteri.telNo = txtTelNo.Text;
            if (rdErkek.Checked)
                musteri.cinsiyet = true;
            else if (rdKadın.Checked)
                musteri.cinsiyet = false;
            else
                MessageBox.Show("Cinsiyetinizi Seçiniz!");
            musteri.dogumTarihi = dtDogum.Value;
            musteri.ehliyetTarihi = dtEhliyet.Value;
            musteri.ilID = cmbIl.SelectedIndex;
            musteri.acikAdres = txtAcikAdres.Text;

            KiralamaWebService kiralamaWebService = new KiralamaWebService();
            kiralamaWebService.Add(baslangic, bitis, aracId, musteri);
            kiralikAraclar();

        }

        private void kiralamaTalepleriMenu_Click(object sender, EventArgs e)
        {

            grbTalepler.Visible = true;
            grbGiris.Visible = false;
            grbAracBilgileri.Visible = false;
            grbAracKirala.Visible = false;
            grbCalisanlar.Visible = false;
            grbKiralamaGecmisi.Visible = false;
            grbTarihBilgileri.Visible = false;
            grpAllCars.Visible = false;
            grbTalepler.Width = 1150;
            grbTalepler.Height = 500;
            grbTalepler.Location = new Point(50, 50);

            TalepleriListele();

        }
        public void TalepleriListele()
        {
            IstekWebService istekWebService = new IstekWebService();
            var model = istekWebService.GetAll(sirketId);

            dgwTalepler.DataSource = model;
        }

        private void dgwTalepler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOnay.Enabled = true;
            aracId = Convert.ToInt16(dgwTalepler.CurrentRow.Cells[7].Value);
            musteriId = Convert.ToInt16(dgwTalepler.CurrentRow.Cells[1].Value);
            baslangic = Convert.ToDateTime(dgwTalepler.CurrentRow.Cells[8].Value);
            bitis = Convert.ToDateTime(dgwTalepler.CurrentRow.Cells[9].Value);

        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            KiralamaWebService kiralamaWebService = new KiralamaWebService();
            kiralamaWebService.Add(musteriId, aracId, baslangic, bitis);
            TalepleriListele();
            btnOnay.Enabled = false;
        }

        private void kiralamaGecmisiMenu_Click(object sender, EventArgs e)
        {
            grbKiralamaGecmisi.Visible = true;
            grbGiris.Visible = false;
            grbAracBilgileri.Visible = false;
            grbAracKirala.Visible = false;
            grbCalisanlar.Visible = false;
            grbTalepler.Visible = false;
            grbTarihBilgileri.Visible = false;
            grpAllCars.Visible = false;
            grbKiralamaGecmisi.Width = 1150;
            grbKiralamaGecmisi.Height = 500;
            grbKiralamaGecmisi.Location = new Point(50, 50);
            kiralamaGecmisi();
        }
        public void kiralamaGecmisi()
        {
            KiralamaWebService kiralamaWebService = new KiralamaWebService();
            var model = kiralamaWebService.Get(sirketId);

            dgwKiralamaGecmisi.DataSource = model;
        }

        private void cikisMenu_Click(object sender, EventArgs e)
        {
            grbGiris.Visible = true;
            grbAracBilgileri.Visible = false;
            grbAracKirala.Visible = false;
            grbCalisanlar.Visible = false;
            grbKiralamaGecmisi.Visible = false;
            grbTalepler.Visible = false;
            grbTarihBilgileri.Visible = false;
            grpAllCars.Visible = false;


        }
    }
}
