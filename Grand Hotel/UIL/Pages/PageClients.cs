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
        private List<ClientBOL> _clients;

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
            string saisie = Input.Read<string>("Voulez-vous afficher : \n1.son adresse \n2.ses N° de teléphone \n3.ses emails");
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

            Output.WriteLine("Saisissez les informations du nouveau client :\n");
            ClientBOL cli = new ClientBOL
            {
                Civilite = Input.Read<string>("Civilité (M/Mlle/Mme) :"),
                Nom = Input.Read<string>("Nom :"),
                Prenom = Input.Read<string>("Prenom"),
                CarteFidelite = Input.Read<bool>("Avez vous une carte de fidelité: 0 (False) ou 1 (True) :"),
                Societe = Input.Read<string>("Nom de société (si renseigné) :")
            };

            if (Metier.Enregister(cli))
            {
                Output.WriteLine(ConsoleColor.Green, "Enregistrement du nouveau client avec succès");

                //Saisie adresse client si le client est enregistré avec succes
                AdresseBOL ad = new AdresseBOL();
                Output.WriteLine("Voulez-vous entrer l'adresse du nouveau client : O/N");
                string choix = Console.ReadLine();
                if (choix == "O")
                {
                    Output.WriteLine("Veuillez saisir les informations suivantes :\n");
                    ad.RueEtComplement = Input.Read<string>("Rue et complément :");
                    ad.CodePostal = Input.Read<string>("Code Postal:");
                    ad.Ville = Input.Read<string>("Ville :");
                }
                else if (choix == "N") { }
                else
                {
                    Output.WriteLine("Erreur de saisie!");
                }

                if (Metier.Enregister(ad))
                    Output.WriteLine(ConsoleColor.Green, "Enregistrement du nouveau client avec succès");
                else
                    Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement de l'adresse!!!");

            }
            else
                Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement du client!!!");

           
        }

        //----------------------------------------------------------------------
        //4-Ajouter un N° de téléphone ou une adresse email
        public void ModifClient()
        {
            //Saisie Identifiant Client

            int saisieId = Input.Read<int>("Veuillez saisir l'identifiant du client: ");

            //Saisie N° de teléphone 
            string choixTel = Input.Read<string>("Voulez-vous entrer un N° de teléphone : O/N");

            if (choixTel == "O")
            {
                Output.WriteLine("Veuillez saisir le numero de téléphone :");
                TelephoneBOL tel = new TelephoneBOL();
                tel.Numero= Input.Read<string>("Numero de téléphone :");
                string saisieCT = Input.Read<string>("Fixe (F) ou Mobile (M) :");
                bool saisie = false;

                do
                {
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
                } while (!saisie);      // repete tant que la saisie est fausse
                tel.Pro = Input.Read<bool>("Teléphone professionnel?: Oui (True) ou Non (False)");

                //Enregistrement teléphone
                if (Metier.Enregister(tel, saisieId))
                    Output.WriteLine(ConsoleColor.Blue, "Enregistrement du nouveau teléphone avec succès");
                else
                    Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement!!!");
            }


            //Saisie Email 
            string choixEmail = Input.Read<string>("Voulez-vous entrer un email : O/N");

            if (choixEmail == "O")
            {
                Output.WriteLine("Veuillez saisir l'email `\n");
                EmailBOL em = new EmailBOL
                {
                    AdresseMail = Input.Read<string>("Email :"),
                    Pro = Input.Read<bool>("Adresse Email professionnel?: Oui (True) ou Non (False)")
                };

                //Enregistrement Email
                if (Metier.Enregister(em, saisieId))
                    Output.WriteLine(ConsoleColor.Blue, "Enregistrement du nouveau mail avec succès");
                else
                    Output.WriteLine(ConsoleColor.Red, "Erreur d'enregistrement!!!");

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
