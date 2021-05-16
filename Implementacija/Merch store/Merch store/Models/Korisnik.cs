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
        int ID { get; set;}
        [Required]
        string KorisnickoIme { get; set; }
        [Required]
        string EMail { get; set; }
        [Required]
        string Password { get; set; }
        
    }
}
