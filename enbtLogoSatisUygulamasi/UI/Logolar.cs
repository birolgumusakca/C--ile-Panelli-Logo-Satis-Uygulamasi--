using enbtLogoSatisUygulamasi.BL;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enbtLogoSatisUygulamasi.UI
{
    public partial class Ürünler : Form
    {
        public Ürünler()
        {
            InitializeComponent();
        }

        private void btnÜrünEkle_Click(object sender, EventArgs e)
        {

            FrmLogo frm = new FrmLogo()
            {
                Text = "Ürün Ekle",
                Logo = new Logo() { ID = Guid.NewGuid() },
            };

        tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunEkle(frm.Logo);

                if (b)
                {

                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;

            }
        }

        private void btnÜrünBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.UrunGetir(toolStripTextBox2.Text);
            if (ds != null)
                dataGridView2.DataSource = ds.Tables[0];
        }

        private void btnÜrünDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];

            FrmLogo frm = new FrmLogo()
            {
                Text = "Ürün Güncelle",
                Güncelleme = true,
                Logo = new Logo()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Tipi = row.Cells[1].Value.ToString(),
                    Boyutu = row.Cells[2].Value.ToString(),
                    Adet = row.Cells[6].Value.ToString(),
                    Rengi = row.Cells[6].Value.ToString(),
                    Arkaplani = row.Cells[5].Value.ToString(),
                    Detay = row.Cells[6].Value.ToString(),

                },
            };

            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunGüncelle(frm.Logo);

                if (b)
                {
                    row.Cells[1].Value = frm.Logo.Tipi;
                    row.Cells[2].Value = frm.Logo.Boyutu;
                    row.Cells[3].Value = frm.Logo.Adet;
                    row.Cells[4].Value = frm.Logo.Rengi;
                    row.Cells[5].Value = frm.Logo.Arkaplani;
                    row.Cells[6].Value = frm.Logo.Detay;

                }

            }
        }

        private void btnÜrünSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunSil(ID);

                if (b)
                {

                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }

            }

        }

        private void Ürünler_Load(object sender, EventArgs e)
        {
            DataSet ds2 = BLogic.UrunGetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];

        }

        public Logo Logo { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];


            Logo = new Logo()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Tipi = row.Cells[1].Value.ToString(),
                Boyutu = row.Cells[2].Value.ToString(),
                Adet = row.Cells[3].Value.ToString(),
                Rengi = row.Cells[4].Value.ToString(),
                Arkaplani = row.Cells[5].Value.ToString(),
                Detay = row.Cells[6].Value.ToString(),


            };

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
