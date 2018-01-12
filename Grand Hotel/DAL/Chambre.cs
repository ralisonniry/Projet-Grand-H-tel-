

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Chambre
    {

        [Key]
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
