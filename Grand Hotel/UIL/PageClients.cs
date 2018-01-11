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
            int Id = Input.Read<int>("Veuillez saisir l'identifiant du client pour ses coordonnées");
            Metier.GetId(Id);

            var coordonnees =_clients.Where(c=>c.Id == Id).Select(c=>c.Client).FirstOrDefault();
            ConsoleTable.From(coordonnees).Display("Coordonnées");
        }


        //Affichage de la liste des clients
        private void AfficherClients()
        {
            _clients = Metier.GetClients();
            ConsoleTable.From(_clients).Display("Clients");
        }
    }
}
