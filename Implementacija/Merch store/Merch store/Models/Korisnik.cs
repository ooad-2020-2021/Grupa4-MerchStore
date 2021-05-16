using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class Korisnik
    {
        [Key]
        [Required]
        public int ID { get; set;}
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
