using BOL;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class GrandHotelApp:ConsoleApplication
    {
        private static GrandHotelApp _instance;
        private static IContexteBOL _ContexteBOL;

        /// <summary>
        /// Obtient l'instance unique de l'application
        /// </summary>
        public static GrandHotelApp Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GrandHotelApp();

                return _instance;
            }
        }

        public static IContexteBOL ContexteBOL
        {
            get
            {
                if (_ContexteBOL == null) _ContexteBOL = new BOL.BOL();     // maintenant on a juste a modifier ce contexte et on saura quel contexte ça va utiliser
                return _ContexteBOL;
            }

        }



        // Constructeur
        public GrandHotelApp()
        {
            // Définition des options de menu à ajouter dans tous les menus de pages
            MenuPage.DefaultOptions.Add(
               new Option("a", "Accueil", () => _instance.NavigateHome()));
        }
    }
}
