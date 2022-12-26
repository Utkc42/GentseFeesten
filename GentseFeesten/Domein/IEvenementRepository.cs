using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public interface IEvenementRepository
    {
        public List<Evenement> GeefTopLevelEvenementen();
        public List<Evenement> GeefAlleEvenementen();
        public List<Evenement> GeefBijEvenementen(Evenement parent);

        public void VoegEvenementToe(Evenement evenement);
        public void VerwijderEvenement(Evenement evenement);

    }
}
