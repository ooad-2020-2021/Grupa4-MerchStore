using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public enum TipNarudzbe
    {
        [Display(Name = "Narudzba na adresu")]
        NarudzbaNaAdresu,
        [Display(Name = "Narudzba na store")]
        NarudzbaNaStore
    }
}
