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
    
    public partial class Chambre
    {
        public Chambre()
        {
            this.Reservation = new HashSet<Reservation>();
            this.Tarif = new HashSet<Tarif>();
        }
    
        public short Numero { get; set; }
        public byte Etage { get; set; }
        public bool Bain { get; set; }
        public bool Douche { get; set; }
        public bool WC { get; set; }
        public byte NbLits { get; set; }
        public Nullable<short> NumTel { get; set; }
    
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<Tarif> Tarif { get; set; }
    }
}
