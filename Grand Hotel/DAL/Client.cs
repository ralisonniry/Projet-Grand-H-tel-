
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {

        [Key]
        public int Id { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool CarteFidelite { get; set; }  // 0 = pas de carte  /  1  = carte de fidelité
        public string Societe { get; set; }
    
        public virtual Adresse Adresse { get; set; }                // une seule adresse
        public virtual ICollection<Email> Email { get; set; }       // peut etre null
        public virtual ICollection<Facture> Facture { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<Telephone> Telephone { get; set; }           // peut etre null

    }
}
