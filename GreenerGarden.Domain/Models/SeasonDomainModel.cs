using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GreenerGarden.Domain.Models
{
    public class SeasonDomainModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime SeasonStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime SeasonEnd { get; set; }
    }
}
