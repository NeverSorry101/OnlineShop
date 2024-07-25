using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Classi
{
    public class Meta
    {
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? barcode { get; set; }
        public string? qrCode { get; set; }
    }
}
