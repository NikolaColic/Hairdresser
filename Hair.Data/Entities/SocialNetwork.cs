using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hair.Data.Entities
{
    [Serializable]
    public class SocialNetwork
    {
        [Key]
        public int SocialNetworkId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
