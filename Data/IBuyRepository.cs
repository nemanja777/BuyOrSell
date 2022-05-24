using BuyOrSell.Data.Entities;
using System.Collections.Generic;

namespace BuyOrSell.Data
{
    public interface IBuyRepository
    {
        IEnumerable<Ad> GetAdsByName(string name);
        IEnumerable<Ad> GetAllAds();

        bool SaveAll();
    }
}