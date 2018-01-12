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
            Menu.AddOption("3", "Saisir un nouveau client", SaisirClient);
            Menu.AddOption("4", "Ajouter un N° de téléphone ou une adresse email", ModifClient);
            Menu.AddOption("5", "Supprimer un client", SupClient);
            Menu.AddOption("6", "Sauvegarder la liste des clients", SauveClient);
        }


        private void AfficherFactureAnnee()
        {
            bool passer = false;
            do
            {
                DateTime saisieDate = Input.Read<DateTime>("A partir de quelle date voulez vous voir les factures ? (jj/mm/aaaa");

                List<FactureBOL> factures = Metier.GetFacture(saisieDate);
                ConsoleTable.From(factures, "Liste des factures").Display("Liste des factures");

                passer =  Input.Read<bool>("Voulez-vous enore voir d'autres factures ? (Oui : true / Non ; false");

            } while (passer);
        }


        private void AfficherFactureSelonId()
        {
            bool passer = false;
            do
            {
                int saisieID = Input.Read<int>("De quelle facture voulez vous voir les lignes de factures ? ( Id de la facture)");

                List<LigneFactureBOL> lignefactures = Metier.GetLignesFactureID(saisieID);
                ConsoleTable.From(lignefactures, "Ligne de la facture " + saisieID).Display("Ligne de la facture " + saisieID);

                passer = Input.Read<bool>("Voulez-vous enore voir d'autres factures ? (Oui : true / Non ; false");

            } while (passer);


        }












    }


}
