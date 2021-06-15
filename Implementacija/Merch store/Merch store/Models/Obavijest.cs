using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class Obavijest
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public int korisnikID { get; set; }
        public string sadrzaj { get; set; }
        public int tip { get; set; }
    }
}
