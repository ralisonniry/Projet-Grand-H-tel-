using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Reservation
    {
        public int IdClient { get; set; }       // Id du client proprietaire de la facture -> permet de trouver la facture selon le client
        public DateTime Jour { get; set; }      // Jour de la reservation
        public int NumeroChambre { get; set; }
        public int NbPersonnes { get; set; }
        public int HeureArrivee { get; set; }
        public int Travail { get; set; }            // 0 : non renseigné  / 1 : personnel / 2 : travail
    }





    public class Chambre
    {



        public List<Reservation> ReservationDeLaChambre { get; set; }       // reservations effectuées pour cette chambre

    }



}
