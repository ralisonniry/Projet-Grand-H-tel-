using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class Program
    {
        static void Main(string[] args)
        {
            GrandHotelApp app = GrandHotelApp.Instance;
            app.Title = "Grand Hotel";

            // Ajout des pages
            Page accueil = new PageAccueil();
            app.AddPage(accueil);
            app.AddPage(new PageClients());
            app.AddPage(new PageFactures());
            app.AddPage(new PageResultats());

            // Affichage de la page d'accueil
            app.NavigateTo(accueil);

            // Lancement de l'appli
            app.Run();
        }
    }
}
