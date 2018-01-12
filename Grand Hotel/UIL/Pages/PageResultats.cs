using BOL;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class PageResultats : MenuPage
    {

        public PageResultats() : base("Page GrandHotel")
        {
            Menu.AddOption("1", "Clients sans numéro de télephone portable", AfficherClientsSansMobile);
            Menu.AddOption("2", "Taux moyen de réservation selon le mois (mm/aaaa)", TauxReservationMois);
            //Menu.AddOption("3", "Saisir une nouvelle facture", SaisirFacture);
            //Menu.AddOption("4", "Saisir lignes de factures selon l'id de la facture", SaisirligneFacture);
            //Menu.AddOption("5", "Mettre à jour le paiement d'une facture", PaiementFacture);
            //Menu.AddOption("6", "Enregistrer un fichier xml contenant les factures d'un client ( idClient necessaire )", SauveFactureClient);
        }


        //Les clients pour lesquels on n’a pas de numéro de portable (id, nom) 
        private void AfficherClientsSansMobile()
        {
            List<ClientBOL> client = Metier.GetClientsSansMobile();
            ConsoleTable.From(client, "clients").Display("Clients");
        }

        //Le taux moyen de réservation de l’hôtel par mois-année (2015-01, 2015-02…), c'est à dire la moyenne sur les chambres du ratio (nombre de jours de réservation dans le mois / nombre de jours du mois) 
        private void TauxReservationMois()
        {
            throw new NotImplementedException();
        }




    }

}
