using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ReservationBOL
    {
        public int IdClient { get; set; }       // Id du client proprietaire de la facture -> permet de trouver la facture selon le client
        public DateTime Jour { get; set; }      // Jour de la reservation
        public int NumeroChambre { get; set; }
        public int NbPersonnes { get; set; }
        public int HeureArrivee { get; set; }
        public int Travail { get; set; }            // 0 : non renseigné  / 1 : personnel / 2 : travail
    }

    public class ChambreBOL
    {
        public int Numero { get; set; }
        public int Etage { get; set; }
        public bool Bain { get; set; }
        public bool Douche { get; set; }
        public bool WC { get; set; }
        public int NbrLits { get; set; }
        public int NumTel { get; set; }     // peut etre null

        public string CodeTarif { get; set; }
        public DateTime DateDebut { get; set; }     // selon un temps t, une chambre n'a qu'un prix et un code tarif
        public decimal Prix { get; set; }

        public List<ReservationBOL> ReservationDeLaChambre { get; set; }       // reservations effectuées pour cette chambre

    }

    // necessaire pour rendre le taux de réservation moyen
    public class TauxReservation
    {
        public int Mois { get; set; }
        public int Taux { get; set; }

    }

    // necessaire pour rendre le nombre quotidien de client par mois
    public class NbrQuotidien
    {

        public int Mois { get; set; }
        public int Nbrclient { get; set; }


    }

    //necessaire pour rendre le chiffre d'affaire par mois
    public class ChiffreAffaire
    {
        public int TrimerstreAnnee { get; set; }
        public int Chiffre { get; set; }
    }

    // necessaire pour rendre le nombre de client par chiffre d'affaire
    public class NbrClientChiffre
    {
        public double Chiffre { get; set; }
        public int nbrClient { get; set; }
    }



}
