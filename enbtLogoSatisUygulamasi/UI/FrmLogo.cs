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
    public partial class FrmLogo : Form
    {
        public FrmLogo()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
        public Logo Logo { get; set; }
        public bool Güncelleme { get; set; } = false;
        private void btnOk_Click(object sender, EventArgs e)
        {

            
            if (!ErrorControl(cbLogoTipi)) return;
            if (!ErrorControl(cbBoyutu)) return;
            if (!ErrorControl(txtAdet)) return;
            if (!ErrorControl(txtRenk)) return;
            if (!ErrorControl(txtArkaPlan)) return;
            if (!ErrorControl(txtDetay)) return;

            Logo.Tipi = cbLogoTipi.Text;
            Logo.Boyutu = cbBoyutu.Text;
            Logo.Adet = txtAdet.Text;
            Logo.Rengi = txtRenk.Text;
            Logo.Arkaplani = txtArkaPlan.Text;
            Logo.Detay = txtDetay.Text;


            DialogResult = DialogResult.OK;
      
        }

        private bool ErrorControl(Control c)
        {

            if (c is TextBox || c is ComboBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }


            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value ==0)
                {
                    errorProvider1.SetError(c, "Eksik veya hatalı bilgi");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }


            return true;
        }


        private void FrmLogo_Load(object sender, EventArgs e)
        {
            txtID.Text = Logo.ID.ToString();
            if (Güncelleme)
            {

                cbLogoTipi.Text = Logo.Tipi;
                cbBoyutu.Text = Logo.Boyutu;
                txtAdet.Text = Logo.Adet;
                txtRenk.Text = Logo.Rengi;
                txtArkaPlan.Text = Logo.Arkaplani;
                txtDetay.Text = Logo.Detay;


            }
        }
    }
}
