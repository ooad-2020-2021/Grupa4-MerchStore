using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class Administrator
    {
        [Key]
        [Required]
        int ID { get; set; }
        [Required]
        string korisnickoIme { get; set; }
        [Required]
        string Email { get; set; }
        [Required]
        string Password { get; set; }
    }
}
