using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public class GlavniViewModel
    {
        public List<NarudzbaDizajnera> artikli { get; set; }
        public List<Obavijest> obavijesti { get; set; }
        public List<Obavijest> obavijestiNarucivanja { get; set; }
    }
}
