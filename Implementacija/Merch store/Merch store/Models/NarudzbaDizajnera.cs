using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class NarudzbaDizajnera
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string NazivGarderobe { get; set; }
        public string Boja { get; set; }
        public string Velicina { get; set; }
        [Required]
        public int Kolicina { get; set; }
        [Required]
        public double Cijena { get; set; }
        [EnumDataType(typeof(StatusNarudzbe))]
        public StatusNarudzbe StatusNarudzbe { get; set; }
        [EnumDataType(typeof(TipNarudzbe))]
        public TipNarudzbe TipNarudzbe { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumNarudzbe { get; set; }
        [DataType(DataType.Date)]
        public DateTime PreostaloVrijeme { get; set; }
        public List<Tuple<int, int>> Pozicije = new List<Tuple<int, int>>();
    }
}
