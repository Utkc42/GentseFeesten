using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class Evenement
    {
        public string Id { get; set; }
        public string Naam { get; set; }
        public int Prijs { get; set; }
        public string Beschrijving { get; set; }
        public string ParentId { get; set; }
        public DateTime EindDatum { get; }
        public DateTime StartDatum { get; }

        public List<string> kinderEvenementenIds { get; set; }

        public Evenement(string id, DateTime eindDatum, DateTime startDatum, string[] kinderEvenementen, string idParent, string beschrijving, string naam, int prijs)
        {
            Id = id;
            EindDatum = eindDatum;
            StartDatum = startDatum;
            Beschrijving = beschrijving;
            Naam = naam;
            Prijs = prijs;
            this.kinderEvenementenIds = new List<string>(kinderEvenementen.ToList<string>());
            this.ParentId= idParent;
        }
    }
}
