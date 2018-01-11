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
        private Client _client;
        public PageClients(): base("Page Clients")
        {
            Menu.AddOption("1", "Liste des CLients", AfficherClients);
            Menu.AddOption("2", "Coordonnées du cLient", InfoClient);


        }

        private void InfoClient()
        {
            int Id = Input.Read<int>("Veuillez saisir l'identifiant du client pour ses coordonnées");
            _client =  Metier.GetCLient(Id);

            Client c = new Client();

            c.Adresse = _client.Adresse;
            c.ListeTel = _client.ListeTel;
            c.ListeEmail = _client.ListeEmail;

            ConsoleTable.From(_client).Display("Coordonnées client");
        }


        //Affichage de la liste des clients
        private void AfficherClients()
        {
            _clients = Metier.GetClients();
            ConsoleTable.From(_clients).Display("Clients");
        }
    }
}
