using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Classi
{
    public class Review
    {
        public int? rating { get; set; }
        public string? comment { get; set; }
        public DateTime? date { get; set; }
        public string? reviewerName { get; set; }
        public string? reviewerEmail { get; set; }
    }
}
