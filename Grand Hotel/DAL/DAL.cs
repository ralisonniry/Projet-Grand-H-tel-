using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class BDD 
    {

        public static List<string> AfficheListeClient()
        {
            return DonneesClient.Instance.AfficheListe();
        }






    }


    public class DonneesClient : DbContext
    {
        private static DonneesClient _instance;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DonneesClient() : base("name=UIL.Properties.Settings1.GrandHotelChaine")
        {
                
        }

        public static DonneesClient Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new DonneesClient();

                return _instance;
            }

        }           // pour instance unique de Donnees Clients

        #region Dbset
        public DbSet<Client> DClient { get; set; }



        #endregion





        public List<string> AfficheListe()
        {
            var liste = DClient.Select(c => c.Prenom+ "\t" + c.Nom).ToList();

            return liste;

        }







    }




}
