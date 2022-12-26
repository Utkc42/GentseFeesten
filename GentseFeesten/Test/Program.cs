
using Domein;
using Persistentie;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constring = @"Data Source=LAPTOP-UMGHNHQ1\SQLEXPRESS;Initial Catalog=GentseFeestenA;Integrated Security=True";

            PlannerRepository pr = new PlannerRepository(constring);


            Planner p = new Planner(3,"bla");

            pr.VoegPlanning(p);
        }
    }
}