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
    using System.ComponentModel.DataAnnotations;

    public partial class Tarif
    {


    
        [Key]
        public string Code { get; set; }
        public System.DateTime DateDebut { get; set; }
        public decimal Prix { get; set; }
    
        public virtual ICollection<Chambre> Chambre { get; set; }
    }
}
