

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LigneFacture
    {

        [Key, Column(Order = 0)]
        [ForeignKey("Facture")]
        public int IdFacture { get; set; }
        [Key, Column(Order = 1)]
        public int NumLigne { get; set; }
        public short Quantite { get; set; }
        public decimal MontantHT { get; set; }
        public decimal TauxTVA { get; set; }
        public decimal TauxReduction { get; set; }
    
        public virtual Facture Facture { get; set; }
    }
}
