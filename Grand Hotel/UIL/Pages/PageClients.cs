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
            Menu.AddOption("1", "Liste des cLients", AfficherClients);
            Menu.AddOption("2", "Coordonnées du client", InfoClient);
            Menu.AddOption("3", "Saisir un nouveau client", SaisirClient);


        }

        private void SaisirClient()
        {
            Output.WriteLine("Saisissez les informations du nouveau client :");
            Client cli = new Client();
            cli.Civilite = Input.Read<string>("Civilité (M/Mlle/Mme) :");
            cli.Nom= Input.Read<string>("Nom :");
            cli.Prenom= Input.Read<string>("Prenom");
            cli.CarteFidelite= Input.Read<bool>("0 (Non) ou 1 (Oui) :");
            cli.Societe= Input.Read<string>("Nom (si renseigné) :");
            Output.WriteLine("Voulez-vous entrer l'adresse du nouveau client : O/N");
            string choix = Console.ReadLine();
            if (choix=="O")
            {
                Adresse ad = new Adresse();
                ad.RueEtComplement = Input.Read<string>("Rue et complément :");
                ad.CodePostal = Input.Read<string>("Code Postal:");
                ad.Ville = Input.Read<string>("Ville :");
            }
            else Enregister();
        }

        private void InfoClient()
        {
            int Id = Input.Read<int>("Veuillez saisir l'identifiant du client pour ses coordonnées: ");
            _client =  (Client)Metier.GetCLient(Id);

            List<Client> Clientliste = new List<Client>();
            Clientliste.Add(_client);


            ConsoleTable.From(Clientliste).Display("Coordonnées client: ");
        }


        //Affichage de la liste des clients
        private void AfficherClients()
        {
            _clients = Metier.GetClients();
            ConsoleTable.From(_clients).Display("Clients");
        }
    }
}
