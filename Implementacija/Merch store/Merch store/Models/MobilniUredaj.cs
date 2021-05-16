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
        string Broj { get; set; }
        string NazivUredaja { get; set; }
    }
}
