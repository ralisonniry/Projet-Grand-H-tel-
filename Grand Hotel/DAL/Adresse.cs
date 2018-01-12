
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Adresse
    {
        [Key]
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public string Rue { get; set; }
        public string Complement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
