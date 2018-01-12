

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ModePaiement
    {
    
        [Key]
        public string Code { get; set; }
        public string Libelle { get; set; }
    
        public virtual ICollection<Facture> Facture { get; set; }
    }
}
