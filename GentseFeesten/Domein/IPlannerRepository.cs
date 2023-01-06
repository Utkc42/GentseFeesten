using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public interface IPlannerRepository
    {
        public List<Planner> GeefAllePlanningen(int idVanGebruiker);
        public void VoegPlanning(Planner p);
        public void VerwijderPlanning(Planner p); 
    }
}
