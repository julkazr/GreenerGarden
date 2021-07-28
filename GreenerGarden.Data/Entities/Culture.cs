using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GreenerGarden.Data.Entities
{
    public class Culture
    {
        public int CultureId { get; set; }
        public int SeasonId { get; set; }
        public int YieldId { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        public virtual Season Season { get; set; }
        public virtual Yield Yield { get; set; }
    }
}
