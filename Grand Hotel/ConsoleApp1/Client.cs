using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    public class Client
    {

        public int id { get; set; }
        public string civilite { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public bool carteFidelite { get; set; }
        public string Societe { get; set; }
    }


    public class Telephone
    {
        public string Numero { get; set; }
        public int idClient { get; set; }
        public bool codeType { get; set; }
        public bool pro { get; set; }

    }

    public class Adresse
    {
        public int MyProperty { get; set; }

    }

}
