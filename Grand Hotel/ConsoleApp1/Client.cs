using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    public class ClientBOL
    {

        public int Id { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool CarteFidelite { get; set; }    
        public string Societe { get; set; }

    }


    public class TelephoneBOL
    {
        public string Numero { get; set; }
        public string CodeType { get; set; }          // 0 = fixe (F) / 1 = mobile (M)
        public bool Pro { get; set; }               // 0 = Particulier  /  1  = Pro

    }

    public class AdresseBOL
    {
        public string RueEtComplement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }

    public class EmailBOL
    {

        public string AdresseMail { get; set; }
        public bool Pro { get; set; }                   // 0 = Particulier  /  1  = Pro

    }




}
