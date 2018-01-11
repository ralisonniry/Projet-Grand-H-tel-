using BOL;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class PageClients : MenuPage
    {
        private IList<Client> _clients;
        public PageClients(): base("Page Clients")
        {
            Menu.AddOption("1", "Liste des CLients", AfficherClients);
            Menu.AddOption("2", "Coordonnées du cLient", InfoClient);


        }

        private void InfoClient()
        {
            int client = Input.Read<int>("Veuillez saisir l'identifiant du client");
            var coordonnees =
            ConsoleTable.From(fournisseurs).Display("Fournisseurs");
        }


        //Affichage de la liste des clients
        private void AfficherClients()
        {
            var Clients = GrandHotelApp.GetClients();
            ConsoleTable.From(Clients).Dispaly("Clients");
        }
    }
}
