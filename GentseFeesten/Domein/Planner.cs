using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class Planner
    {
        private List<Evenement> _evenementen;

        public Planner(int id, int gebruikerId, string evenementId)
        {
            Id = id;
            GebruikerId = gebruikerId;
            EvenementId = evenementId;
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
        //}

        public int? TotalePrijs()
        {
            int? totaal = 0;
            foreach (Evenement e in _evenementen)
            {
                totaal = totaal + e.Prijs;
            }

            return totaal;
        }
    }
}
