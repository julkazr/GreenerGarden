using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GreenerGarden.Data.Entities
{
    public class Season
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime SeasonStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime SeasonEnd { get; set; }

        public virtual ICollection<Culture> Cultures { get; set; }
        public virtual ICollection<Expence> Expences { get; set; }
    }
}
