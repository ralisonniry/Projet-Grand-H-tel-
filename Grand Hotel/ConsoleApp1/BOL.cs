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


        // Envoie la liste de tous les clients
        public static List<ClientBOL> GetClients()
        {
            List<DAL.Client> liste = BDD.AfficheListeClient();
            List<ClientBOL> listeBOL = new List<ClientBOL>();

             foreach(var c in liste)
            {
                ClientBOL client1 = new ClientBOL();
                client1.Id = c.Id;
                client1.Nom = c.Nom;
                client1.Prenom = c.Prenom;
                client1.CarteFidelite = c.CarteFidelite;
                client1.Societe = c.Societe;
                client1.Civilite = c.Civilite;

                listeBOL.Add(client1);
            }

            return listeBOL;
        }


        // Cherche le client selon l'id et envoie l'adresse de ce dernier
        public static AdresseBOL GetCLient(int id)
        {
            DAL.Adresse adresse = BDD.ChercheAdresseClient(id);
            ClientBOL adressebol = new ClientBOL();



            return adressebol;
            




        }




        public static bool Enregister(Client cli)
        {
            throw new NotImplementedException();
        }


    }
}
