using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace GreenerGarden.Data.Entities
{
    public class Note
    {
        public int NoteId { get; set; }
        [Required]
        public string NoteCategory { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime NoteDate { get; set; }
        [Required]
        public string NoteBody { get; set; }
    }
}
