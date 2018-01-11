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


        public static List<object> AfficheListeClient()
        {

            DonneesClient clas = new DonneesClient();

             clas.AfficheListe();

            return new List<object>();

        }



    }


    public class DonneesClient : DbContext
    {


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DonneesClient() : base("name=test2.Properties.Settings1.GrandHotelChaine")
        {
        }



        public DbSet<Client> DClient { get; set; }







        public void AfficheListe()
        {

            List<Client> liste = new List<Client>();

            liste = DClient.ToList();


            Console.Read();



        }







    }




}
