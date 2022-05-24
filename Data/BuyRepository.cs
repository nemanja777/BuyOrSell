using BuyOrSell.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyOrSell.Data
{
    public class BuyRepository : IBuyRepository
    {
        private readonly BuyContext _ctx;

        public BuyRepository(BuyContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Ad> GetAllAds()
        {
            return _ctx.Ads
                .OrderByDescending(a => a.Id)
                .ToList();
        }

        public IEnumerable<Ad> GetAdsByName(string name)
        {
            return _ctx.Ads
                .Where(a => a.Name == name)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

    }
}
