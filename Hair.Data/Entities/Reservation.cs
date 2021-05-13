using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hair.Data.Entities
{
    [Serializable]
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        [Key, ForeignKey("HairdresserId")]
        public Hairdresser Hairdresser { get; set; }
        [Key, ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int Mark { get; set; }

    }
}
