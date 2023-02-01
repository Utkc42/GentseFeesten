using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class DomeinController
    {

        private IEvenementRepository iEvenementRepo;
        private IPlannerRepository iPlannerRepo;

        public DomeinController(IEvenementRepository eRepo, IPlannerRepository iPlanner)
        {
            this.iEvenementRepo = eRepo;
            this.iPlannerRepo = iPlanner;
        }

        //Evenement
        public List<Evenement> GeefAlleEvenementen()
        {

            return iEvenementRepo.GeefAlleEvenementen();
        }

        public List<Evenement> GeefBijEvenementen(Evenement parent)
        {
            return iEvenementRepo.GeefBijEvenementen(parent);
        }

        public List<Evenement> GeefTopLevelEvenementen()
        {
            return iEvenementRepo.GeefTopLevelEvenementen();
        }

        public void VerwijderEvenement(Evenement evenement)
        {
            iEvenementRepo.VerwijderEvenement(evenement);

        }

        public void VoegEvenementToe(Evenement evenement)
        {
            iEvenementRepo.VoegEvenementToe(evenement); 
        }


        // Planning
        public List<Planner> GeefAllePlanningen(int idVanGebruiker)
        {
            return iPlannerRepo.GeefAllePlanningen(idVanGebruiker);
        }

        public void VoegPlanning(Planner pl)
        {
            iPlannerRepo.VoegPlanning(pl);
        }

        public void VerwijderPlanning(Planner pl)
        {
            iPlannerRepo.VerwijderPlanning(pl);
        }

        public void PrijsOpvragen()
        {
            iPlannerRepo.TotalePrijs();
        }
    }
}
