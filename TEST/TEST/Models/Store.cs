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
        [NotMapped]
        public Adresa Adresa { get; set; }
        [Key]
        public string Kod { get; set; }
        [NotMapped]
        public List<NarudzbaDizajnera> Narudzbe = new List<NarudzbaDizajnera>();
        [NotMapped]
        public List<MobilniUredaj> MobilniUredaji = new List<MobilniUredaj>();
        public bool EmailNotifikacije { get; set; }
        public bool UredajNotifikacije { get; set; }
    }
}
