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

        public static List<DAL.Client> AfficheListeClient()
        {
            return DonneesClient.Instance.AfficheListe();
        }

        public static Adresse ChercheAdresseClient(int id)
        {
            throw new NotImplementedException();
        }
    }


    public class DonneesClient : DbContext
    {


        #region instance
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

        #endregion

        #region Dbset
        public DbSet<Client> DClient { get; set; }



        #endregion




        // Charge la lsite des clients
        public List<DAL.Client> AfficheListe()
        {
            var listeclient = DClient.ToList();
            List<DAL.Client> liste = new List<Client>();

            foreach(var c in listeclient)
            {
                DAL.Client client1 = new Client();

                client1.Id = c.Id;
                client1.Nom = c.Nom;
                client1.Prenom = c.Prenom;
                client1.CarteFidelite = c.CarteFidelite;
                client1.Societe = c.Societe;
                client1.Civilite = c.Civilite;

                liste.Add(client1);

            }

            return liste;

        }               






    }




}
