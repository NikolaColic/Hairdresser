using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hair.Data.Entities
{
    public class Municipality
    {
        [Key]
        public int MunicipalityId { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
