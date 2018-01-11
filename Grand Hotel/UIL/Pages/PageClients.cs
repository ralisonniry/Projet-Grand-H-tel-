using BOL;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace UIL

//GESTION DES CLIENTS
{
    class PageClients : MenuPage
    {
        private IList<DAL.Client> _clients;
        private object _client;
        public PageClients() : base("Page Clients")
        {
            Menu.AddOption("1", "Liste des cLients", AfficherClients);
            Menu.AddOption("2", "Coordonnées du client", InfoClient);
            Menu.AddOption("3", "Saisir un nouveau client", SaisirClient);
            Menu.AddOption("4", "Ajouter un N° de téléphone ou une adresse email", ModifClient);

        }


        //-----------------------------------------------------------------------------
        //1-Affichage de la liste des clients
        public void AfficherClients()
        {
            _clients = Metier.GetClients();
            ConsoleTable.From(_clients, "clients").Display("Clients");
        }

        //----------------------------------------------------------------------
        //2-Afficher Coordonnées du client 
        public void InfoClient()
        {
            //Saisie Identifiant Client
            int Id = Input.Read<int>("Veuillez saisir l'identifiant du client : ");
            string saisieId = Console.ReadLine();
            _client = Metier.GetCLient(Id);

            

            List<Client> Clientliste = new List<Client>();
            //Clientliste.Add(_client);


            ConsoleTable.From(Clientliste).Display("Coordonnées client: ");
        }
        //----------------------------------------------------------------------
        //3-Saisir un nouveau client
        public void SaisirClient()
        {
            Output.WriteLine("Voulez-vous entrer un nouveau client : \n1.Oui \n2.Non");
            string saisieClient = Console.ReadLine();
            bool saisie = false;
            switch (saisieClient)
            {
                case "1":
                    saisie = true;
                    break;
                case "2":
                    saisie = false;
                    break;
                default:
                    Output.WriteLine("Erreur de saisie!");
                    break;
            }


            Output.WriteLine("Saisissez les informations du nouveau client :");
            Client cli = new Client();
            cli.Civilite = Input.Read<string>("Civilité (M/Mlle/Mme) :");
            cli.Nom = Input.Read<string>("Nom :");
            cli.Prenom = Input.Read<string>("Prenom");
            cli.CarteFidelite = Input.Read<bool>("0 (Non) ou 1 (Oui) :");
            cli.Societe = Input.Read<string>("Nom (si renseigné) :");

            //Saisie adresse client
            Output.WriteLine("Voulez-vous entrer l'adresse du nouveau client : O/N");
            string choix = Console.ReadLine();
            if (choix == "O")
            {
                Output.WriteLine("Veuillez saisir les informations suivantes :");
                Adresse ad = new Adresse();
               // ad.RueEtComplement = Input.Read<string>("Rue et complément :");
                ad.CodePostal = Input.Read<string>("Code Postal:");
                ad.Ville = Input.Read<string>("Ville :");



            }
            else if (choix == "N")
            {


            }
            else
            {

                //erreur
            }

            

           // if (!Metier.Enregister(cli))
            //    Output.WriteLine(ConsoleColor.Blue, "Enregistrement du nouveau client avec succès");
            //else
            //    Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement!!!");
        }
        //----------------------------------------------------------------------
        //4-Ajouter un N° de téléphone ou une adresse email
        public void ModifClient()
        {
            //Saisie Identifiant Client
            int Id = Input.Read<int>("Veuillez saisir l'identifiant du client: ");
            string saisieId = Console.ReadLine();
            _client = (Client)Metier.GetCLient(Id);


            Output.WriteLine("Voulez-vous entrer : \n1. un N° de téléphone \n2. un email");
            string choix = Console.ReadLine();

            if (choix == "1")
            {
                Output.WriteLine("Veuillez saisir le numero de téléphone :");
                Telephone tel = new Telephone();
                tel.Numero= Input.Read<string>("Numero de téléphone :");
            }
        }


    }
}
