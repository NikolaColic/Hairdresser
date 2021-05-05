using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hair.Data.Entities
{
    public class FavouriteHairdresser
    {
        [Key]
        public int FavouriteHairdresserId { get; set; }
        [Key, ForeignKey("HairdresserId")]
        public Hairdresser Hairdresser { get; set; }
        [Key, ForeignKey("UserId")]
        public User User { get; set; }
    }
}
