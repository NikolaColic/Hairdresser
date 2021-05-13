using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hair.Data.Entities
{
    [Serializable]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public IEnumerable<Reservation> ReservationsHistory { get; set; }
        public IEnumerable<FavouriteHairdresser> FavouritesHairdresser { get; set; }

    }
}
