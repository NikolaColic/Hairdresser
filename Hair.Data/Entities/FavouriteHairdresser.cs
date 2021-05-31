using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hair.Data.Entities
{
    [Serializable]
    /// <summary>
    /// Class favourite hairdresser for user
    /// </summary>
    public class FavouriteHairdresser
    {
        /// <summary>
        /// Unique id
        /// </summary>
        [Key]
        public int FavouriteHairdresserId { get; set; }
        /// <summary>
        /// Informations about hairdresser
        /// </summary>
        [Key, ForeignKey("HairdresserId")]
        public Hairdresser Hairdresser { get; set; }
        /// <summary>
        /// Informations about user
        /// </summary>
        [Key, ForeignKey("UserId")]
        public User User { get; set; }
    }
}
