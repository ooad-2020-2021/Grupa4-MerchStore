using Merch_store.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class AdminPostavkeModel
    {
        public IdentityUser temp1 { get; set; }
        public NarudzbaDizajnera temp2 { get; set; }
        public List<IdentityUser> korisnici { get; set; }
        public List<NarudzbaDizajnera> nepotrvrdjeneNarudzbe { get; set; }

        public int brojBoja { get; set; }
        public int brojVelicina { get; set; }
        public List<String> boje { get; set; }
        public List<String> velicine { get; set; }
    }
}
