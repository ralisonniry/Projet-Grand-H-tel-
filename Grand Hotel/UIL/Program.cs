using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class PageAccueil : MenuPage
    {
        public PageAccueil() : base("Acceuil", false)
        {
            Menu.AddOption("0", "Quitter l'application",
                () => Environment.Exit(0));


        }
    }





}
