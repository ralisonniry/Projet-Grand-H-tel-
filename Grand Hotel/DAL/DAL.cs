using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        private DbSet<Client> DClient { get; set; }


        public static List<Client> AfficheListeClient()
        {

            List<object> liste = new List<Client>();








            return liste;


        }







    }




}
