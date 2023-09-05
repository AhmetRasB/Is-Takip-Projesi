using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;
using DevExpress.XtraEditors;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        DbistakipEntities db = new DbistakipEntities();
        void personeller()
        {
            var degerler = from x in db.TblPersonels
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               x.Telefon,
                               x.Durum,
                               Departman = x.TblDepartmanlar.Ad
                               
                           };
            gridControl1.DataSource = degerler.Where(x=>x.Durum==true).ToList();
        }


        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personeller();

            var departmanlar = (from x in db.TblDepartmanlars
                                select new
                                {
                                    x.Ad,
                                    x.ID
                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.Ad = TxtAd.Text;
            t.Soyad =TxtSoyad.Text;
            t.Mail = TxtMail.Text;
            t.Gorsel = TxtGorsel.Text;
            t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            t.Durum = true;
            db.TblPersonels.Add(t);
            db.SaveChanges();                           
            XtraMessageBox.Show("Yeni Personel Kaydı Başarılı Şekilde Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();
             

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(TxtID.Text);
            var deger = db.TblPersonels.Find(x);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel Kaydı Başarıılı Şekilde Silindi, Silinen Personeller Listesinden Tüm Silinmiş Personel Bilgilerine Ulaşabilirsiniz...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personeller();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
           // TxtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
           lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();
            

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(TxtID.Text);
            var deger = db.TblPersonels.Find(x);
            deger.Ad = TxtAd.Text;
            deger.Soyad = TxtSoyad.Text;
            deger.Mail = TxtMail.Text;
            deger.Gorsel = TxtGorsel.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel Kaydı Başarılı Şekilde Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personeller();


        }
    }
}
