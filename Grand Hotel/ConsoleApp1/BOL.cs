using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Serialization;
using System.IO;

namespace BOL
{
    public static class Metier
    {

        #region ClientService
        // Envoie la liste de tous les clients
        public static List<ClientBOL> GetClients()
        {
            List<Client> liste = BDD.AfficheListeClient();
            List<ClientBOL> listeBOL = new List<ClientBOL>();

            foreach (Client c in liste)
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

        public static List<ClientBOL> GetClientsSansMobile()
        {
            throw new NotImplementedException();
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
        public static List<EmailBOL> GetEmail(int id)
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


        // Enregistre le client dans la BDD
        public static bool Enregister(ClientBOL c)
        {
            Client client1 = new Client
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                CarteFidelite = c.CarteFidelite,
                Societe = c.Societe,
                Civilite = c.Civilite
            };

            return BDD.EnregistreClient(client1);
        }

        public static bool Enregister(AdresseBOL adresse)
        {
            Adresse adressebol = new Adresse
            {
                Rue = adresse.RueEtComplement,
                CodePostal = adresse.CodePostal,
                Ville = adresse.Ville
            };

            return BDD.EnregistreAdresse(adressebol);

        }

        //public static bool Enregister(TelephoneBOL c)
        //{
        //    Telephone tele = new Telephone
        //    {
        //         Numero = c.Numero,
        //         Pro = c.Pro,
        //         CodeType = c.CodeType

        //};

        //    return BDD.EnregistreTelephone(tele);
        //}

        public static bool Enregister(TelephoneBOL c, int saisieId)
        {
            Telephone tele = new Telephone
            {
                Numero = c.Numero,
                Pro = c.Pro,
                CodeType = c.CodeType,
                IdClient = saisieId

            };

            return BDD.EnregistreTelephone(tele);
        }

        public static bool Enregister(EmailBOL em, int saisieId)
        {
            Email email = new Email
            {
                Adresse = em.AdresseMail,
                IdClient = saisieId,
                Pro = em.Pro


            };

            return BDD.EnregistreEmail(email);
        }


        public static void SupprimerCLient(int id)
        {
            BDD.SupprimerLeClient(id);
        }


        //Exporter la liste des clients au format XML
        public static bool ExporterXml()
        {
            List<Client> listeDAL = BDD.AfficheListeClient();

            List<ClientBOL> listeBOL = new List<ClientBOL>();
            foreach (Client c in listeDAL)
            {
                ClientBOL client1 = new ClientBOL
                {
                    Id = c.Id,
                    Nom = c.Nom,
                    Prenom = c.Prenom,
                    CarteFidelite = c.CarteFidelite,
                    Societe = c.Societe,
                    Civilite = c.Civilite
                };

                listeBOL.Add(client1);

            }


            XmlSerializer xmlserialise = new XmlSerializer(typeof(List<ClientBOL>),
                                         new XmlRootAttribute("ListeClients"));

            using (var sw = new StreamWriter(@"..\..\XML_Liste_Client.xml"))
            {

                xmlserialise.Serialize(sw, listeBOL);


            }
            return true;


        }

        #endregion

        //-----------------------------GESTION DES FACTURES--------------
        // Cherche les factures  selon l'id et renvoie la liste des adresses de ce dernier

        public static List<FactureBOL> GetFacture(DateTime saisieDate, int saisieClient)
        {
            List<Facture> facture = BDD.ChercheFactureClient(saisieDate, saisieClient);
            List<FactureBOL> facturebol = new List<FactureBOL>();

            foreach (Facture f in facture)
            {
                FactureBOL facture1 = new FactureBOL();
                facture1.Id = f.Id;
                facture1.IdClient = f.IdClient;
                facture1.Datefacture = f.DateFacture;
                facture1.DatePaiement = f.DatePaiement;
                facture1.CodeModePaiement = f.CodeModePaiement;

                facturebol.Add(facture1);
            }
            return facturebol;
        }

        //Afficher les lignes d'une facture identifiée par son Id

        public static List<LigneFactureBOL> GetLignesFactureID(int saisieID)
        {
            List<LigneFacture> ligneFacture = BDD.ChercheLigneFacture(saisieID);
            List<LigneFactureBOL> ligneFacturebol = new List<LigneFactureBOL>();

            foreach (LigneFacture lf in ligneFacture)
            {
                LigneFactureBOL ligneFacture1 = new LigneFactureBOL();
                ligneFacture1.NumLigne = lf.NumLigne;
                ligneFacture1.Quantite = lf.Quantite;
                ligneFacture1.MontantHT = lf.MontantHT;
                ligneFacture1.TauxTVA = lf.TauxTVA;
                ligneFacture1.TauxReduction = lf.TauxReduction;

                ligneFacturebol.Add(ligneFacture1);
            }
            return ligneFacturebol;
        }



        //Saisir une facture
        public static void SaisirFacture(FactureBOL nouvelleFacture)
        {
            Facture nouvelleFacture1 = new Facture
            {
                IdClient = nouvelleFacture.IdClient,
                DateFacture = nouvelleFacture.Datefacture,
                DatePaiement = nouvelleFacture.DatePaiement,
                CodeModePaiement = nouvelleFacture.CodeModePaiement
            };

            BDD.EnregistrerFacture(nouvelleFacture1);
        }

        //Saisir les lignes d'une facture donnée
        public static void SaisirLigneFacture(LigneFactureBOL nouvelleLigneFacture, int saisieIDfacture)
        {
            LigneFacture lf = new LigneFacture
            {
                IdFacture = saisieIDfacture,
                Quantite = nouvelleLigneFacture.Quantite,
                MontantHT = nouvelleLigneFacture.MontantHT,
                TauxTVA = nouvelleLigneFacture.TauxTVA,
                TauxReduction = nouvelleLigneFacture.TauxReduction

            };

            BDD.EnregistrerLigne(lf);
        }


        //Mettre à jour la date et le mode de paiement d'une facture
        public static void MiseAJourPaiement(int saisieID, DateTime saisieDatepaiement, string saisieMode)
        {
            Facture facture = new Facture
            {
                Id = saisieID,
                DatePaiement = saisieDatepaiement,
                CodeModePaiement = saisieMode
            };

            BDD.EnregistrerMAJ(facture);
        }

        //Exporter factures en XML
        public static bool EnregistreFacturesXML(int saisieClient)
        {
            List<Facture> listeFacture = BDD.AfficheListeFacture(saisieClient);


            List<FactureBOL> factureBOL = new List<FactureBOL>();
            foreach (Facture f in listeFacture)
            {
                FactureBOL facture1 = new FactureBOL
                {
                    Id = f.Id,
                    IdClient = f.IdClient,
                    Datefacture = f.DateFacture,
                    DatePaiement = f.DatePaiement,
                    CodeModePaiement = f.CodeModePaiement,
                    MontantFacture = f.LigneFacture
                };

                factureBOL.Add(facture1);
            }


            XmlSerializer xmlserialise = new XmlSerializer(typeof(List<FactureBOL>),
                                         new XmlRootAttribute("ListeFactures"));

            using (var sw = new StreamWriter(@"..\..\XML_Liste_Facture.xml"))
            {

                xmlserialise.Serialize(sw, factureBOL);
            }
            return true;


        }
    }
}
