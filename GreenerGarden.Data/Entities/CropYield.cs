using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GreenerGarden.Data.Entities
{
    public class CropYield
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        [DataType(DataType.Currency)]
        public float Amount { get; set; }

        public virtual Season Season { get; set; }
        public virtual Culture Culture { get; set; }
    }
}
