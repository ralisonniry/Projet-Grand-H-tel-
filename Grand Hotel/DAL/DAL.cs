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
            return DonneesClient.Instance.GetAddress(id);
        }

        public static List<Telephone> GetTelephone(int id)
        {
            return DonneesClient.Instance.GetTel(id);

        }

        public static List<Email> GetEmail(int id)
        {
            return DonneesClient.Instance.GetMail(id);
        }

        public static bool EnregistreClient(Client c)
        {
            return DonneesClient.Instance.SaveClient(c);
        }

        public static bool EnregistreAdresse(Adresse adressebol)
        {
            return DonneesClient.Instance.SaveAdresse(adressebol);
        }

        public static bool EnregistreTelephone(Telephone tele)
        {
            return DonneesClient.Instance.SaveTelephone(tele);
        }

        public static bool EnregistreEmail(Email email)
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
        public DbSet<Telephone> DTelephone { get; set; }
        public DbSet<Adresse> DAdresse { get; set; }
        public DbSet<Email> DEmail { get; set; }

        #endregion




        // Charge la lsite des clients
        public List<DAL.Client> AfficheListe()
        {
            return DClient.ToList();
        }

        // regarde en local l'adresse du client id
        public Adresse GetAddress(int id)
        {
            return DAdresse.Where(a => a.IdClient == id).FirstOrDefault();
        }

        // regarde en local le tel du client id
        public List<Telephone> GetTel(int id)
        {
            return DTelephone.Where(t=> t.IdClient == id).ToList();
        }

        // regarde en local le mail du client id
        internal List<Email> GetMail(int id)
        {
            return DEmail.Where(t => t.IdClient == id).ToList();
        }

        // Enregistre le client id dans la BDD
        internal bool SaveClient(Client c)
        {
            try
            {
                DClient.Add(c);
                SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        // Enregistre le tel id dans la BDD
        internal bool SaveAdresse(Adresse adressebol)
        {
            try
            {
                adressebol.IdClient = DClient.Select(c => c.Id).Max();
                DAdresse.Add(adressebol);
                SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        // Enregistre le telephone id dans la BDD
        internal bool SaveTelephone(Telephone tele)
        {
            try
            {
                if(tele.IdClient == 0)
                tele.IdClient = DClient.Select(c => c.Id).Max();
                DTelephone.Add(tele);
                SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }





    }




}
