using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class BDD : DbContext
    {
        public DbSet<Client> Client { get; set; }


        public static List<Client> AfficheListeClient()
        {
            





        }
    }
}
