using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Prijs { get; set; }
        public int Stardatum { get; set; }
        public int Einddatum { get; set; }
    }
}
