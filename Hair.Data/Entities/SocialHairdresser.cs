using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hair.Data.Entities
{
    public class SocialHairdresser
    {
        public int SocialHairdresserId { get; set; }
        [Key, ForeignKey("HairdresserId")]
        public Hairdresser Hairdresser { get; set; }
        [Key, ForeignKey("SocialNetworkId")]
        public SocialNetwork SocialNetwork { get; set; }
        public string Url { get; set; }

    }
}
