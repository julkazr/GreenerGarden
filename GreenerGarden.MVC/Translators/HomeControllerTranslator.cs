using GreenerGarden.Domain.Models;
using GreenerGarden.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenerGarden.MVC.Translators
{
    public class HomeControllerTranslator
    {
        public HomeViewModel ToHomeViewModel(CurrentSeasonDomainModel seasonData)
        {
            var result = new HomeViewModel()
            {
                SeasonId = seasonData.SeasonId,
                TotalExpence = seasonData.SeasonExpence,
                TotalProfit = seasonData.SeasonProfit
                //CultureNames = seasonData.CultureNames,
                //CropYields = seasonData.CropYields,
                //ExpencesAmounts = seasonData.ExpencesAmounts,
                //CulturesProfits = seasonData.CulturesProfits
            };
            return result;
        }
    }
}
