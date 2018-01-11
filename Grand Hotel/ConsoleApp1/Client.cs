using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    public class Client
    {

        public int Id { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool CarteFidelite { get; set; }     // 0 = pas de carte  /  1  = carte de fidelité
        public string Societe { get; set; }

        public List<Telephone> ListeTel { get; set; }   // peut etre null
        public List<Email> ListeEmail { get; set; }     // peut etre null
        public Adresse Adresse { get; set; }            // une seule adresse

        

    }


    public class Telephone
    {
        public string Numero { get; set; }
        public int IdClient { get; set; }
        public bool CodeType { get; set; }          // 0 = fixe (F) / 1 = mobile (M)
        public bool Pro { get; set; }               // 0 = Particulier  /  1  = Pro

    }

    public class Adresse
    {
        public string RueEtComplement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }
    
    public class Email
    {

        public string AdresseMail { get; set; }
        public bool Pro { get; set; }                   // 0 = Particulier  /  1  = Pro

    }


}
