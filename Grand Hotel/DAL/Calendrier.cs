//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calendrier
    {
        public Calendrier()
        {
            this.Reservation = new HashSet<Reservation>();
        }
    
        public System.DateTime Jour { get; set; }
    
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
