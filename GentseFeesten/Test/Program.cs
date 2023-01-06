
using Domein;
using Persistentie;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string constring = @"Data Source=LAPTOP-UMGHNHQ1\SQLEXPRESS;Initial Catalog=GentseFeesten;Integrated Security=True";

            PlannerRepository pr = new PlannerRepository(constring);

            EvenementRepository repo = new EvenementRepository(constring);

            List<Evenement> evenementen = repo.GeefTopLevelEvenementen();

            foreach (Evenement evenement in evenementen)
            {
                Console.WriteLine(evenement.Id);
            }
            //Planner p = new Planner(3, "29dec22");

            //pr.VoegPlanning(p);

























        }
    }
}