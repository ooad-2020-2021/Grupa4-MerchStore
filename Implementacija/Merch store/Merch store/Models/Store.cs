using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class Store
    {
        Adresa Adresa { get; set; }
        [Key]
        string Kod { get; set; }
        [NotMapped]
        List<NarudzbaDizajnera> Narudzbe = new List<NarudzbaDizajnera>();
        [NotMapped]
        List<MobilniUredaj> MobilniUredaji = new List<MobilniUredaj>();
        bool EmailNotifikacije { get; set; }
        bool UredajNotifikacije { get; set; }
    }
}
