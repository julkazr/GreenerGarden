using System;
using System.Collections.Generic;
using System.Text;

namespace GreenerGarden.Domain.Models
{
    public class CurrentSeasonDomainModel
    {
        public int SeasonId { get; set; }
        public string CropYield { get; set; }
        public float ExpenceAmount { get; set; }
        public string CultureName { get; set; }
        public float SeasonProfit { get; set; }
        public float CultureProfit { get; set; }
        public float SeasonExpence { get; set; }

    }
}
