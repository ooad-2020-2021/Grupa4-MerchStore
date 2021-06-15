using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class Garderoba
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string DostupneBoje { get; set; }
        public string DostupneVelicine { get; set; }
        [Required]
        public double Cijena { get; set; }
        [Required]
        public int Kolicina { get; set; }
    }
}
