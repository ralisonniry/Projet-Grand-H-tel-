using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;



namespace BOL

{
    public static class Metier
    {



        public static List<DAL.Client> GetClients()
        {
            List<DAL.Client> liste = BDD.AfficheListeClient();
            return liste;
        }

        public static object GetCLient(int id)
        {
            throw new NotImplementedException();
        }

        public static void Enregister(object cli)
        {
            throw new NotImplementedException();
        }

        // public static ClientBOL GetId(int id)
        // {
        // ClientBOL client =  BDD.GetClient(id);

        // return client;
        // }
    }


}
