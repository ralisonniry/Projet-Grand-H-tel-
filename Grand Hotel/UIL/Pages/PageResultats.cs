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
            Menu.AddOption("3", "Nombre moyen de client durant une année", NombreClientAnnee);
            Menu.AddOption("4", "Le chiffre d’affaire par trimestre de chaque année", ChiffreAffaireAnnee);
            Menu.AddOption("6", "Nombre de client par tranche de 1000€ de chiffre d'affaire", NbrClientChiffre);

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
            
            DateTime dateChoisie = DateTime.MinValue;
            //string saisieDate;
            //string intermedaire;

            ////Converti un mm/aaaa en un DateTime
            //do
            //{
            //    saisieDate = Input.Read<string>("Vous voulez affichez le taux moyen de réservation pour quel mois ? ( mm/aaaa )");
            //    intermedaire = "01/" + saisieDate;
            //    DateTime.TryParse(intermedaire, out dateChoisie);

            //} while (dateChoisie == DateTime.MinValue);

            try
            {
                List<TauxReservation> taux = Metier.TauxReservationMois();
                ConsoleTable.From(taux, "Le taux(nombre de jours de réservation dans le mois / nombre de jours du mois) pour chaque mois ").Display("Nombre quotidien de clien");

            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur..." + e);
            }

        }

        // Le nombre quotidien moyen de clients présents dans l’hôtel pour chaque mois de l’année 2017, en tenant compte du nombre de personnes dans les chambres
        private void NombreClientAnnee()
        {

            //DateTime dateChoisie = DateTime.MinValue;
            //string saisieDate;
            //string intermedaire;

            //Converti un mm/aaaa en un DateTime
            //do
            //{
            //    saisieDate = Input.Read<string>("Vous voulez affichez le taux moyen de réservation pour quel annee ? ( aaaa )");
            //    intermedaire = "01/01" + saisieDate;
            //    DateTime.TryParse(intermedaire, out dateChoisie);

            //} while (dateChoisie == DateTime.MinValue);

            try
            {
                List<NbrQuotidien> nbrQuotidien = Metier.NombreClientAnnee();
                ConsoleTable.From(nbrQuotidien, "Le nombre quotidien moyen de clients présents dans l’hôtel pour chaque mois de l’année 2017 ").Display("Nombre quotidien de clien");

            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur..." + e);
            }
        }

        //	Le chiffre d’affaire de l’hôtel par trimestre de chaque année
        private void ChiffreAffaireAnnee()
        {
            try
            {
                List<ChiffreAffaire> nbrQuotidien = Metier.ChiffreAffaireAnnee();
                ConsoleTable.From(nbrQuotidien, "  chiffre d’affaire de l’hôtel par trimestre de chaque année ").Display("Nombre quotidien de clients");

            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur..." + e);
            }
        }



        //	Le nombre de clients dans chaque tranche de 1000 € de chiffre d’affaire total généré. La première tranche est < 5000 €, et la dernière >= 8000 €
        private void NbrClientChiffre()
        {
            throw new NotImplementedException();
        }





    }

}
