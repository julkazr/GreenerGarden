using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GreenerGarden.Domain.Models
{
    public class SeasonDomainModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
    }
}
