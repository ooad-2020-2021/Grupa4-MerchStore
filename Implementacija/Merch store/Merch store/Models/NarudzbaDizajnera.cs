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
        int ID { get; set; }
        string NazivGarderobe { get; set; }
        string Boja { get; set; }
        string Velicina { get; set; }
        [Required]
        int Kolicina { get; set; }
        [Required]
        double Cijena { get; set; }
        [EnumDataType(typeof(StatusNarudzbe))]
        StatusNarudzbe StatusNarudzbe { get; set; }
        [EnumDataType(typeof(TipNarudzbe))]
        TipNarudzbe TipNarudzbe { get; set; }
        [DataType(DataType.Date)]
        DateTime DatumNarudzbe { get; set; }
        [DataType(DataType.Date)]
        DateTime PreostaloVrijeme { get; set; }
        List<Tuple<int, int>> Pozicije = new List<Tuple<int, int>>();
    }
}
