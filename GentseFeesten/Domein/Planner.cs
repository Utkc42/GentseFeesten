using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class Planner
    {
        private List<Evenement> _evenementen = new List<Evenement>();

        public Planner(int id, int gebruikerId, string evenementId)
        {
            Id = id;
            GebruikerId = gebruikerId;
            EvenementId = evenementId;
        }

        public Planner(int gebruikerId)
        {
            
            GebruikerId = gebruikerId;
          
        }


        public int Id { get; }
        public int GebruikerId { get; }
        public string EvenementId { get; }

        public void VoegEvenementToeAanPlanner(Evenement evenement)
        {
            _evenementen.Add(evenement);
            
        }

        public void VerwijderEvenementVanPlanner(Evenement evenement)
        {
            _evenementen.Remove(evenement);
        }
        
        //public List<Evenement> SorteerChronologisch(Evenement evenement)
        //{
        //    // TODO _evenementen sorteren op datum
            
        //    return _evenementen.Sort(evenement.StartDatum);

        //}
        
        public int? TotalePrijs()
        {
            int? totaal = 0;
            foreach (Evenement e in _evenementen)
            {
                totaal += e.Prijs;
            }

            return totaal;
        }
    }
}
