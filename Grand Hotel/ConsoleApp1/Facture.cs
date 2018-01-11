using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    internal class Facture
    {
        internal int Id { get; set; }
        internal int IdClient { get; set; }
        internal DateTime Datefacture { get; set; }
        internal DateTime DatePaiement { get; set; }
        internal string CodeModePaiement { get; set; }        // peut etre nul

        internal List<LigneFacture> ListeFacture { get; set; }

    }



    internal class LigneFacture
    {
        internal int NumLigne { get; set; }
        internal int Quantite { get; set; }
        internal decimal MontantHT { get; set; }
        internal decimal TauxTVA { get; set; }
        internal decimal TauxReduction { get; set; }
    }

}
