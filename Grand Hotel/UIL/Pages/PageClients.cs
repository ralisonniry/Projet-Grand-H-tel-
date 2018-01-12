using BOL;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UIL

//GESTION DES CLIENTS
{
    class PageClients : MenuPage
    {
        private IList<ClientBOL> _clients;
        private ClientBOL _client;
        public PageClients() : base("Page Clients")
        {
            Menu.AddOption("1", "Liste des cLients", AfficherClients);
            Menu.AddOption("2", "Coordonnées du client", InfoClient);
            Menu.AddOption("3", "Saisir un nouveau client", SaisirClient);
            Menu.AddOption("4", "Ajouter un N° de téléphone ou une adresse email", ModifClient);
            Menu.AddOption("5", "Supprimer un client", SupClient);
            Menu.AddOption("6", "Sauvegarder la liste des clients", SauveClient);
        }



        //-----------------------------------------------------------------------------
        //1-Affichage de la liste des clients
        public void AfficherClients()
        {
            _clients = Metier.GetClients();
            ConsoleTable.From(_clients, "clients sans Mobile").Display("Clients");
        }

        //----------------------------------------------------------------------
        //2-Afficher Coordonnées du client 
        public void InfoClient()
        {
            //Saisie Identifiant Client
            int Id = Input.Read<int>("Veuillez saisir l'identifiant du client: ");


            //Demande choix Coordonnées
            Output.WriteLine("Voulez-vous afficher : \n1.son adresse \n2.ses N° de teléphone \n3.ses emails");
            string saisie = Console.ReadLine();
            switch (saisie)
            {
                case "1":
                    {
                        var adresse = Metier.GetAdresse(Id);
                        List<AdresseBOL> listeadresse = new List<AdresseBOL>();
                        listeadresse.Add(adresse);
                        ConsoleTable.From(listeadresse, "Adressse").Display("Adresse");
                    }
                    break;
                case "2":
                    var tel = Metier.GetTel(Id);
                    ConsoleTable.From(tel, "Teléphones").Display("Teléphones");
                    break;
                case "3":
                    var email = Metier.GetEmail(Id);
                    ConsoleTable.From(email, "Emails").Display("Emails");
                    break;
                default:
                    Output.WriteLine("Erreur de saisie!");
                    break;
            }

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
            ClientBOL cli = new ClientBOL();
            cli.Civilite = Input.Read<string>("Civilité (M/Mlle/Mme) :");
            cli.Nom = Input.Read<string>("Nom :");
            cli.Prenom = Input.Read<string>("Prenom");
            cli.CarteFidelite = Input.Read<bool>("Avez vous une carte de fidelité: 0 (False) ou 1 (True) :");
            cli.Societe = Input.Read<string>("Nom de société (si renseigné) :");

            Metier.Enregister(cli);
            AdresseBOL ad = new AdresseBOL();
            //Saisie adresse client
            Output.WriteLine("Voulez-vous entrer l'adresse du nouveau client : O/N");
            string choix = Console.ReadLine();
            if (choix == "O")
            {
                Output.WriteLine("Veuillez saisir les informations suivantes :");
                ad.RueEtComplement = Input.Read<string>("Rue et complément :");
                ad.CodePostal = Input.Read<string>("Code Postal:");
                ad.Ville = Input.Read<string>("Ville :");

            }
            else if (choix == "N")
            {


            }
            else
            {
                Output.WriteLine("Erreur de saisie!");
            }

            if (Metier.Enregister(ad))
                Output.WriteLine(ConsoleColor.Blue, "Enregistrement du nouveau client avec succès");
            else
                Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement!!!");
        }
        //----------------------------------------------------------------------
        //4-Ajouter un N° de téléphone ou une adresse email
        public void ModifClient()
        {
            //Saisie Identifiant Client

            int saisieId = Input.Read<int>("Veuillez saisir l'identifiant du client: ");

            //Saisie N° de teléphone 
            Output.WriteLine("Voulez-vous entrer un N° de teléphone : O/N");
            string choixTel = Console.ReadLine();

            if (choixTel == "O")
            {
                Output.WriteLine("Veuillez saisir le numero de téléphone :");
                TelephoneBOL tel = new TelephoneBOL();
                tel.Numero= Input.Read<string>("Numero de téléphone :");
                string saisieCT = Input.Read<string>("Fixe (F) ou Mobile (M) :");
                bool saisie = false;
                switch (saisieCT)
                {
                    case "F":
                        saisie = true;
                        tel.CodeType = saisieCT;
                        break;
                    case "M":
                        saisie = true;
                        tel.CodeType = saisieCT;
                        break;
                    default:
                        Output.WriteLine("Erreur de saisie!");
                        break;
                }
                tel.Pro= Input.Read<bool>("Teléphone professionnel?: Oui (True) ou Non (False)");

                //Enregistrement teléphone
                if (Metier.Enregister(tel, saisieId))
                    Output.WriteLine(ConsoleColor.Blue, "Enregistrement du nouveau teléphone avec succès");
                else
                    Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement!!!");
            }
            else
            {

            }


            //Saisie Email 
            Output.WriteLine("Voulez-vous entrer un email : O/N");
            string choixEmail = Console.ReadLine();

            if (choixEmail == "O")
            {
                Output.WriteLine("Veuillez saisir l'email :");
                EmailBOL em = new EmailBOL();
                em.AdresseMail = Input.Read<string>("Email :");
                em.Pro= Input.Read<bool>("Adresse Email professionnel?: Oui (True) ou Non (False)");


                //Enregistrement Email
                if (Metier.Enregister(em, saisieId))
                    Output.WriteLine(ConsoleColor.Blue, "Enregistrement du nouveau mail avec succès");
                else
                    Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement!!!");

            }
            else
            {

            }

        }
        //----------------------------------------------------------------------
        //5-Supprimer un client

        public void SupClient()
        {
            int id = Input.Read<int>("Id du client à supprimer :");
            try
            {
                Metier.SupprimerCLient(id);
            }
            catch (Exception)
            {
                GérerErreurSql();
            }
        }

        private void GérerErreurSql()
        {

            Output.WriteLine(ConsoleColor.Red, "Erreur ! Client relié à une facture et/ou à une reservation !");
        }
        //----------------------------------------------------------------------
        //6-Sauvegarder la liste des clients

        private void SauveClient()
        {
            Console.WriteLine("Exportation de la liste des clients en format XML");
            if (Metier.ExporterXml())
                Output.WriteLine(ConsoleColor.Blue, "Succès de l'opération Export");
            else
                Output.WriteLine(ConsoleColor.Red, "Erreur de l'opération Export!!!");
        }

    }
}
