using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hair.Data.Entities
{
    [Serializable]
    public class Hairdresser
    {
        [Key]
        public int HairdresserId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        [MaxLength(12)]
        public string TaxId { get; set; }
        [MaxLength(12)]
        public string ParentId { get; set; }
        public string Number { get; set; }
        public string Gmail { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Pricelist { get; set; }
        public int Gender { get; set; }
        [ForeignKey("MunicipalityId")]
        public Municipality Municipality { get; set; }
        [ForeignKey("UserId")]
        public User Owner { get; set; }
        public IEnumerable<HairdresserImage> Images { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<SocialHairdresser> SocialNetworks { get; set; }
    }
}
