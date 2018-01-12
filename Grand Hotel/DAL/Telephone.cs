

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Telephone
    {
        [Key]
        public string Numero { get; set; }
        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public string CodeType { get; set; }
        public bool Pro { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
