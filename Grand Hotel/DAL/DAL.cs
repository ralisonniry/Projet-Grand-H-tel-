﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Xml.Serialization;
using System.IO;

namespace DAL
{
    // Intermediaire avec BOL
    public class BDD
    {
        // -----------------------------GESTION DES CLIENTS--------------------------

        public static List<Client> AfficheListeClient()
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
            return DonneesClient.Instance.SaveEmail(email);
        }

        public static void SupprimerLeClient(int id)
        {
            DonneesClient.Instance.SupprimeClient(id);
        }
        public static List<Client> AfficheFacture()
        {
            return DonneesClient.Instance.AfficheListe();
        }

        // -----------------------------GESTION DES FACTURES--------------------------
        public static List<Facture> ChercheFactureClient(DateTime saisieDate, int saisieClient)
        {
            return DonneesClient.Instance.GetFacture(saisieDate, saisieClient);
        }

        public static List<LigneFacture> ChercheLigneFacture(int saisieID)
        {
            return DonneesClient.Instance.GetLigneFacture(saisieID);
        }

        public static void EnregistrerFacture(Facture nouvelleFacture)
        {
            DonneesClient.Instance.SaveFacture(nouvelleFacture);
        }

        public static void EnregistrerLigne(LigneFacture lf)
        {
            DonneesClient.Instance.SaveLigne(lf);
        }

        public static void EnregistrerMAJ(Facture facture)
        {
            DonneesClient.Instance.SaveMAJ(facture);
        }

        public static List<Facture> AfficheListeFacture(int saisieClient)
        {
            return DonneesClient.Instance.GetListeFacture(saisieClient);
        }



        // -----------------------------RESULTAT HOTEL--------------------------

        //public static List<Client> AfficheListeClientSM()
        //{
        //    return DonneesClient.Instance.GetListeClientSM();
        //}


    }


    public class DonneesClient : DbContext
    {


        #region instance
        private static DonneesClient _instance;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DonneesClient() : base("name=DAL.Properties.Settings1.GrandHotelChaine")
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
        public DbSet<Facture> DFacture { get; set; }
        public DbSet<LigneFacture> DLigneFacture { get; set; }

        #endregion


        // -----------------------------GESTION DES CLIENTS--------------------------

        // Charge la liste des clients
        public List<DAL.Client> AfficheListe()
        {
            return DClient.AsNoTracking().ToList();
        }

        // regarde en local l'adresse du client id
        public Adresse GetAddress(int id)
        {
            return DAdresse.Where(a => a.IdClient == id).FirstOrDefault();
        }

        // regarde en local le tel du client id
        public List<Telephone> GetTel(int id)
        {
            return DTelephone.Where(t => t.IdClient == id).ToList();
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
                if(adressebol != null)
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
                if (tele.IdClient == 0)
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

        // Enregistre le mail id dans la BDD
        internal bool SaveEmail(Email email)
        {
            try
            {
                DEmail.Add(email);
                SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        // Suppruime le client dans la BDD
        internal void SupprimeClient(int id)
        {
            try// faudra effacer les adresse, num tel etc, Ssi !!!! pas de reservation
            {
                Client c = DClient.Find(id);
                if (c != null)
                {

                    //Enleve l'adresse reliée
                    Adresse a = DAdresse.Find(c.Id);
                    if (a != null)
                        DAdresse.Remove(a);

                    //Enleve les telephones reliées
                    List<Telephone> tel = DTelephone.Where(t => t.IdClient == id).ToList();
                    if (tel != null)
                        foreach (var t in tel)
                            DTelephone.Remove(t);

                    //Enleve les telephones reliées
                    List<Email> email = DEmail.Where(t => t.IdClient == id).ToList();
                    if (email != null)
                        foreach (var t in email)
                            DEmail.Remove(t);


                    DClient.Remove(c);

                    SaveChanges();


                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        // -----------------------------GESTION DES FACTURES--------------------------
        // Affiche la liste des factures d'un client
        public List<Facture> GetFacture(DateTime saisieDate, int saisieClient)
        {
            DateTime saisiePlusAnnee = saisieDate.AddYears(1);
            return DFacture.Where(f => f.IdClient == saisieClient && (f.DateFacture >= saisieDate && f.DateFacture < saisiePlusAnnee)).ToList();
        }

        public List<LigneFacture> GetLigneFacture(int saisieID)
        {
            return DLigneFacture.Where(f => f.IdFacture == saisieID).ToList();
        }

        public void SaveFacture(Facture nouvelleFacture)
        {
            try
            {

                DFacture.Add(nouvelleFacture);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void SaveLigne(LigneFacture lf)
        {
            try
            {
                lf.NumLigne = 1;
                try
                {
                    lf.NumLigne = DLigneFacture.Where(c => c.IdFacture == lf.IdFacture).Max(c => c.NumLigne) + 1;

                }
                catch (Exception) { }
                DLigneFacture.Add(lf);
                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveMAJ(Facture facture)
        {
            Facture factureAModifier = DFacture.Find(facture.Id);
            try
            {
                factureAModifier.DatePaiement = facture.DatePaiement;
                factureAModifier.CodeModePaiement = facture.CodeModePaiement;

                SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Facture> GetListeFacture(int saisieClient)
        {
            return DFacture.Where(f => f.IdClient == saisieClient).ToList();
        }

        // -----------------------------RESULTAT HOTEL--------------------------
        //internal List<Client> GetListeClientSM()
        //{
        //    //return DClient.Where(c => c.Telephone.Where( t=> t.CodeType.Contains('M'))).ToList();
        //    // .DTelephone.Where(t=>t.CodeType!=M).ToList();
        //}


    }
}
