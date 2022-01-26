using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedMimariManav.Entities
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public int KategoriID { get; set; }
        public int MusteriID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Stok { get; set; }
        public short Siparis { get; set; }
    }
}
