using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merch_store.Models
{
    public enum StatusNarudzbe
    {
        [Display(Name = "Nepotvrđena")]
        Nepotvrdjena,
        [Display(Name = "Validirana")]
        Validirana,
        [Display(Name = "Invalidirana")]
        Invalidirana
    }
}
