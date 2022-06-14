using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enbtLogoSatisUygulamasi
{
    public class Musteri
    {

        public Guid ID { get; set; }
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }


        public override string ToString()
        {
            return $"{Ad} {Soyad}"; 
        }

    }

    public class Logo  
    {
        public Guid ID { get; set; }

        public string Tipi { get; set; }
        public string Boyutu { get; set; }
        public string Adet { get; set; }
        public string Rengi { get; set; }
        public string Arkaplani { get; set; }
        public string Detay { get; set; }


        public override string ToString()
        {
            return $"{Rengi} {Detay}";
        }

    }

    public class Satis
    {
        public Guid ID { get; set; }

        public Guid MusteriID { get; set; }
        public Guid LogoID { get; set; }
        public DateTime Tarih { get; set; }

        public double Fiyat { get; set; }




    }

    public class Odeme
    {
        public Guid ID { get; set; }

        public Guid MusteriID { get; set; }

        public DateTime Tarih { get; set; }

        public double Tutar { get; set; }

        public string Aciklama { get; set; }
    }



}
