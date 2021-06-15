using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class NarudzbaDizajnera
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [ForeignKey("Korinisk")]
        public int korisnikID { get; set; }
        public string NazivGarderobe { get; set; }
        public string Boja { get; set; }
        public string Velicina { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public double Cijena { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumNarudzbe { get; set; }
        [DataType(DataType.Date)]
        public DateTime PreostaloVrijeme { get; set; }
    }
}
