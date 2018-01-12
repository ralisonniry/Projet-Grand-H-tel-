using BOL;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class PageFactures : MenuPage
    {

        public PageFactures() : base("Page Factures")
        {
            Menu.AddOption("1", "Liste des Factures sur 1 an", AfficherFactureAnnee);
            Menu.AddOption("2", "Ligne Facture (necessite l'id de la facture)", AfficherFactureSelonId);
            Menu.AddOption("3", "Saisir une nouvelle facture", SaisirFacture);
            Menu.AddOption("4", "Saisir lignes de factures", SaisirligneFacture);
            //Menu.AddOption("5", "Supprimer un client", SupClient);
            //Menu.AddOption("6", "Sauvegarder la liste des clients", SauveClient);
        }

        private void SaisirligneFacture()
        {
            throw new NotImplementedException();
        }

        private void AfficherFactureAnnee()
        {
            bool passer = false;
            do
            {

                List<ClientBOL>  clients = Metier.GetClients();
                ConsoleTable.From(clients, "clients").Display("Clients");

                int saisieClient = Input.Read<int>("De quel client voulez vous voir les factures ? ( Id )");

                DateTime saisieDate = Input.Read<DateTime>("A partir de quelle date voulez vous voir ses factures ? ( jj/mm/aaaa )");


                List<FactureBOL> factures = Metier.GetFacture(saisieDate, saisieClient);
                ConsoleTable.From(factures, "Liste des factures du client" + saisieClient +" jusqu'a 1 an, à partir de " + saisieDate).Display("Liste des factures");

                passer =  Input.Read<bool>("Voulez-vous enore voir d'autres factures ? ( Oui : true / Non : false )");

            } while (passer);
        }


        private void AfficherFactureSelonId()
        {
            bool passer = false;
            do
            {
                int saisieID = Input.Read<int>("De quelle facture voulez vous voir les lignes de factures ? ( Id de la facture )");

                List<LigneFactureBOL> lignefactures = Metier.GetLignesFactureID(saisieID);
                ConsoleTable.From(lignefactures, "Ligne de la facture " + saisieID).Display("Ligne de la facture " + saisieID);

                passer = Input.Read<bool>("Voulez-vous enore voir d'autres factures ? (Oui : true / Non ; false");

            } while (passer);

        }


        private void SaisirFacture()
        {
            bool passer = false;
            bool modepaiment = false;
            do
            {
                FactureBOL nouvelleFacture = new FactureBOL();

                List<ClientBOL> clients = Metier.GetClients();
                ConsoleTable.From(clients, "clients").Display("Clients");
                nouvelleFacture.IdClient = Input.Read<int>("Quel est l'id du client");

                nouvelleFacture.Datefacture = Input.Read<DateTime>("Quel est la date de la facture");
                if (Input.Read<bool>("Le client a deja payé ? ( Oui : true / Non : false )"))
                {
                    nouvelleFacture.DatePaiement = Input.Read<DateTime>("Quel est la date de paiement ?");
                    do
                    {
                        // saisie du mode de paiement
                        string saisieMode = Input.Read<string>("Quel etait le mode de paiement ? ( CB / CHQ / ESP )");
                        switch (saisieMode)
                        {
                            case "CB":
                                nouvelleFacture.CodeModePaiement = saisieMode;

                                modepaiment = true;
                                break;
                            case "CHQ":
                                nouvelleFacture.CodeModePaiement = saisieMode;
                                modepaiment = true;
                                break;
                            case "ESP":
                                nouvelleFacture.CodeModePaiement = saisieMode;
                                modepaiment = true;
                                break;
                            default:
                                break;
                        }
                    } while (!modepaiment);

                }
                else
                {
                    //mode de paiement par defaut CB
                    nouvelleFacture.CodeModePaiement = "CB";
                }

                try
                {
                    Metier.SaisirFacture(nouvelleFacture);
                    Console.WriteLine("Facture Saisie avec succés !");

                }
                catch(Exception)
                {
                    Console.WriteLine("Erreur...");
                }

                passer = Input.Read<bool>("Voulez-vous enore saisir d'autres factures ? (Oui : true / Non ; false");

            } while (passer);
        }













    }


}
