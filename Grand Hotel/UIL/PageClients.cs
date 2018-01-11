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
        public PageClients(): base("Page Clients")
        {
            Menu.AddOption("1", "Liste des CLients", AfficherClients);
            Menu.AddOption("2", "Coordonnées du cLient", InfoClient);


        }

        private void InfoClient()
        {
            int 
        }

        private void AfficherClients()
        {
            var Clients = BOL.GetClients();
            ConsoleTable.From(Clients).Dispaly("Clients");
        }
    }
}
