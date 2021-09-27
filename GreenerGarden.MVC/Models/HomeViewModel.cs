using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenerGarden.MVC.Models
{
    public class HomeViewModel
    {
        public int SeasonId { get; set; }
        public float TotalProfit { get; set; }
        public float TotalExpence { get; set; }
        //public ICollection<CultureViewModel> Cultures { get; set; }
        //public List<float> CropYields { get; set; }
        //public List<float> ExpencesAmounts { get; set; }
        //public List<float> CulturesProfits { get; set; }

    }

}
