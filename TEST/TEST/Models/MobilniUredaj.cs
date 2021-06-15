using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class MobilniUredaj
    {
        [Required]
        public string Broj { get; set; }
        public string NazivUredaja { get; set; }
    }
}
