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
        public List<string> CultureNames { get; set; }
        public List<float> CropYields { get; set; }
        public List<float> ExpencesAmounts { get; set; }
        public List<float> CulturesProfits { get; set; }
    }
}
