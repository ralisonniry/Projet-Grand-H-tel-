

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Facture
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public System.DateTime DateFacture { get; set; }
        public Nullable<System.DateTime> DatePaiement { get; set; }
        [ForeignKey("ModePaiement")]
        public string CodeModePaiement { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ModePaiement ModePaiement { get; set; }
        public virtual ICollection<LigneFacture> LigneFacture { get; set; }
    }
}
