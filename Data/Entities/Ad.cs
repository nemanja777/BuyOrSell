using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyOrSell.Data.Entities
{
    public class Ad
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }

        public String Cattegory { get; set; }

        public string ApplicationUserId { get; set; }

        public string Town { get; set; }

        public DateTime Date { get; set; }
    }
}
