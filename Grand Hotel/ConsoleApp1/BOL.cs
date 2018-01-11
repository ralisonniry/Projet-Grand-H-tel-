using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace BOL

{
    public static class Metier
    {

        public static List<Client> GetClients()
        {
            return  BDD.AfficheListeClient();
        }







    }


}
