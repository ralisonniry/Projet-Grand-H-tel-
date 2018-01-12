using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{

    public class FactureBOL
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public DateTime Datefacture { get; set; }
        public Nullable<DateTime> DatePaiement { get; set; }
        public string CodeModePaiement { get; set; }        // peut etre nul

        public List<LigneFactureBOL> ListeFacture { get; set; }

    }



    public class LigneFactureBOL
    {
        public int NumLigne { get; set; }
        public int Quantite { get; set; }
        public decimal MontantHT { get; set; }
        public decimal TauxTVA { get; set; }
        public decimal TauxReduction { get; set; }
    }

}
