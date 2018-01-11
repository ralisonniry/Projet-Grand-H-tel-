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
        public static AdresseBOL GetAdresse(int id)
        {
            DAL.Adresse adresse = BDD.ChercheAdresseClient(id);
            AdresseBOL adressebol = new AdresseBOL();

            adressebol.RueEtComplement = adresse.Rue + "\t" + adresse.Complement;
            adressebol.CodePostal = adresse.CodePostal;
            adressebol.Ville = adresse.Ville;

            return adressebol;
        }

        // Cherche le client selon l'id et envoie l'adresse de ce dernier
        public static List<TelephoneBOL> GetTel(int id)
        {
            List<DAL.Telephone> liste = BDD.GetTelephone(id);
            List<TelephoneBOL> listeBOL = new List<TelephoneBOL>();

            foreach (var c in liste)
            {
                TelephoneBOL tel1 = new TelephoneBOL();
                tel1.Numero = c.Numero;
                tel1.Pro = c.Pro;
                tel1.CodeType = c.CodeType;

                listeBOL.Add(tel1);
            }

            return listeBOL;
        }

        // Cherche le client selon l'id et envoie l'adresse de ce dernier
        public static object GetEmail(int id)
        {
            List<DAL.Email> liste = BDD.GetEmail(id);
            List<EmailBOL> listeBOL = new List<EmailBOL>();

            foreach (var c in liste)
            {
                EmailBOL o1 = new EmailBOL();
                o1.AdresseMail = c.Adresse;
                o1.Pro = c.Pro;

                listeBOL.Add(o1);
            }

            return listeBOL;
        }



        public static bool Enregister(Client cli)
        {
            throw new NotImplementedException();
        }


    }
}
