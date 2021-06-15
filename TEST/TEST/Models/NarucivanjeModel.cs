using Merch_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class NarucivanjeModel
    {
        public List<Garderoba> garderoba { get; set; }
        public List<List<String>> dostupneBojeString { get; set; }
        public List<List<String>> dostupneVelicineString { get; set; }
        public String odabranaBoja { get; set; }
        public String odabaranaVelicina { get; set; }
    }
}
