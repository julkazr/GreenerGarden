using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GreenerGarden.Data.Entities
{
    public class Expence
    {
        public int ExpenceId { get; set; }
        [Required]
        public string ExpenceCategory { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpenceDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float ExpenceAmount { get; set; }

        public virtual Season Season { get; set; }
        public virtual Culture Culture { get; set; }
    }
}
