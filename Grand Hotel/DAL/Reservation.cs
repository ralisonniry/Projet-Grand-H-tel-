

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reservation
    {

        [Key, Column(Order = 0)]
        [ForeignKey("Chambre")]
        public short NumChambre { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Calendrier")]
        public DateTime Jour { get; set; }
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public byte NbPersonnes { get; set; }
        public byte HeureArrivee { get; set; }
        public Nullable<bool> Travail { get; set; }
    
        public virtual Calendrier Calendrier { get; set; }
        public virtual Chambre Chambre { get; set; }
        public virtual Client Client { get; set; }
    }
}
