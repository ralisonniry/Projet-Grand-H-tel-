

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Email
    {
        [Key]
        public string Adresse { get; set; }
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public bool Pro { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
