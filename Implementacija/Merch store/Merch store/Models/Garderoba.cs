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
        [NotMapped]
        public List<string> DostupneBoje = new List<string>();
        [NotMapped]
        public List<string> DostupneVelicine = new List<string>();
        [Required]
        public double Cijena { get; set; }
        [Required]
        public int Kolicina { get; set; }
        List<Tuple<int, int>> Pozicije = new List<Tuple<int, int>>();
    }
}
