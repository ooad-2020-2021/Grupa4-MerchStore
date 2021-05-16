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
        int ID { get; set; }
        string Naziv { get; set; }
        [NotMapped]
        List<string> DostupneBoje = new List<string>();
        [NotMapped]
        List<string> DostupneVelicine = new List<string>();
        [Required]
        double Cijena { get; set; }
        [Required]
        int Kolicina { get; set; }
        List<Tuple<int, int>> Pozicije = new List<Tuple<int, int>>();
    }
}
