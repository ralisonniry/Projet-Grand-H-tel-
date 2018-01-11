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

            return AfficheListeClient();



        }











    }


    public class DonneesClient : DbContext
    {


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public DbSet<Client> DClient { get; set; }



        public List<Client> AfficheListeClient()
        {

            List<Client> liste = new List<Client>();

            liste = DClient.ToList();




            return liste;


        }







    }




}
