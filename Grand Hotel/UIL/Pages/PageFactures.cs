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
            Menu.AddOption("4", "Saisir lignes de factures selon l'id de la facture", SaisirligneFacture);
            Menu.AddOption("5", "Mettre à jour le paiement d'une facture", PaiementFacture);
            Menu.AddOption("6", "Enregistrer un fichier xml contenant les factures d'un client ( idClient necessaire )", SauveFactureClient);
        }




        //	Afficher la liste des factures d’un client à partir d’une date donnée (par défaut sur un an glissant) 
        private void AfficherFactureAnnee()
        {
            bool passer = false;
            do
            {

                List<ClientBOL> clients = Metier.GetClients();
                ConsoleTable.From(clients, "clients").Display("Clients");

                int saisieClient = Input.Read<int>("De quel client voulez vous voir les factures ? ( Id )");

                DateTime saisieDate = Input.Read<DateTime>("A partir de quelle date voulez vous voir ses factures ? ( jj/mm/aaaa )");


                List<FactureBOL> factures = Metier.GetFacture(saisieDate, saisieClient);
                ConsoleTable.From(factures, "Liste des factures du client" + saisieClient + " jusqu'a 1 an, à partir de " + saisieDate).Display("Liste des factures");

                passer = Input.Read<bool>("Voulez-vous encore voir d'autres factures ? ( Oui : true / Non : false ) \n");

            } while (passer);
        }

        //	Afficher les lignes d’une facture identifiée par son Id 
        private void AfficherFactureSelonId()
        {
            bool passer = false;
            do
            {
                int saisieID = Input.Read<int>("De quelle facture voulez vous voir les lignes de factures ? ( Id de la facture )\n");

                List<LigneFactureBOL> lignefactures = Metier.GetLignesFactureID(saisieID);
                ConsoleTable.From(lignefactures, "Ligne de la facture " + saisieID).Display("Ligne de la facture " + saisieID);

                passer = Input.Read<bool>("Voulez-vous encore voir d'autres factures ? (Oui : true / Non : false )\n");

            } while (passer);

        }

        //	Saisir une facture 
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
                    nouvelleFacture.DatePaiement = Input.Read<DateTime>("Quel est la date de paiement ? ( jj/mm/aaaa )");
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
                catch (Exception e)
                {
                    Console.WriteLine("Erreur..." + e);
                }

                passer = Input.Read<bool>("Voulez-vous encore saisir d'autres factures ? (Oui : true / Non ; false \n");

            } while (passer);
        }

        //  Saisir les lignes de facture d’une facture donnée 
        private void SaisirligneFacture()
        {
            bool passer = false;
            int saisieIDfacture = Input.Read<int>("Quel est l'id de la facture");

            do
            {

                LigneFactureBOL nouvelleLigneFacture = new LigneFactureBOL
                {
                    Quantite = Input.Read<short>("Quel est la quantité du service fourni"),
                    MontantHT = Input.Read<decimal>("Quel est la montant du service fourni"),
                    TauxTVA = Input.Read<decimal>("Quel est le taux TVA du service fourni"),
                    TauxReduction = Input.Read<decimal>("Quel est le taux de reduction du service fourni")
                };

                try
                {
                    Metier.SaisirLigneFacture(nouvelleLigneFacture, saisieIDfacture);
                    Console.WriteLine("Ligne de facture saisie avec succés !\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur..." + e);
                }

                passer = Input.Read<bool>("Voulez-vous encore saisir d'autres ligne  pour cette facture ? (Oui : true / Non :false ) \n");

            } while (passer);
        }

        // 	Mettre à jour la date et le mode de paiement d’une facture
        private void PaiementFacture()
        {
            bool modepaiment = false;

            int saisieID = Input.Read<int>("De quelle facture voulez vous mettre à jour le paiement ? ( Id de la facture )");

            DateTime saisieDatepaiement = Input.Read<DateTime>("Quel est la date de paiement ? ( jj/mm/aaaa )");

            do
            {
                string saisieMode = Input.Read<string>("Quel etait le mode de paiement ? ( CB / CHQ / ESP )");
                switch (saisieMode)
                {
                    case "CB":
                        try
                        {
                            Metier.MiseAJourPaiement(saisieID, saisieDatepaiement, saisieMode);
                            Console.WriteLine("Validé !\n");
                        }
                        catch (Exception e) { Console.WriteLine("Erreur..." + e); }
                        modepaiment = true;
                        break;
                    case "CHQ":
                        try
                        {
                            Metier.MiseAJourPaiement(saisieID, saisieDatepaiement, saisieMode);
                            Console.WriteLine("Validé !\n");
                        }
                        catch (Exception e) { Console.WriteLine("Erreur..." + e); }
                        modepaiment = true;
                        break;
                    case "ESP":
                        try
                        {
                            Metier.MiseAJourPaiement(saisieID, saisieDatepaiement, saisieMode);
                            Console.WriteLine("Validé !\n");
                        }
                        catch (Exception e) { Console.WriteLine("Erreur..." + e); }
                        modepaiment = true;
                        break;
                    default:
                        break;
                }
            } while (!modepaiment);
        }

        //Exporter les factures d’un client donné au format xml, sans le détail des lignes, mais avec le montant total de la facture
        private void SauveFactureClient()
        {

            List<ClientBOL> clients = Metier.GetClients();
            ConsoleTable.From(clients, "clients").Display("Clients");

            int saisieClient = Input.Read<int>("De quel client voulez vous enregistrer les factures ? ( Id )");

            try
            {
                Metier.EnregistreFacturesXML(saisieClient);
                Console.WriteLine("Validé !\n");
            }
            catch (Exception e) { Console.WriteLine("Erreur..." + e); }
        }


    }

}



