using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hair.Data.Entities
{
    public class HairdresserImage
    {
        [Key]
        public int HairdresserImageId { get; set; }
        [Key,ForeignKey("HairdresserId")]
        public Hairdresser Hairdresser { get; set; }
        public string Url { get; set; }

    }
}
