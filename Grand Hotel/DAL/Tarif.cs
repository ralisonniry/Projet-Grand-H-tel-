

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public  class Tarif
    {


    
        [Key]
        public string Code { get; set; }
        public System.DateTime DateDebut { get; set; }
        public decimal Prix { get; set; }
    
        public virtual ICollection<Chambre> Chambre { get; set; }
    }
}
