using System;
using System.Collections.Generic;
using System.Text;

namespace GreenerGarden.Domain.Models
{
    public class CurrentSeasonDomainModel
    {
        public int SeasonId { get; set; }
        public float SeasonProfit { get; set; }
        public float SeasonExpence { get; set; }
        public ICollection<CultureDomainModel> Cultures { get; set; }
        public List<float> CultureCropYields { get; set; }
        public List<float> CultureExpencesAmounts { get; set; }
        public List<float> CultureProfits { get; set; }
    }
}
