﻿using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIL
{
    class PageAccueil : MenuPage
    {
        public PageAccueil() : base("Accueil", false)
        {
            Menu.AddOption("0", "Quitter l'application",
                () => Environment.Exit(0));

            Menu.AddOption("1", "Clients",
            () => GrandHotelApp.Instance.NavigateTo(typeof(PageClients)));
            Menu.AddOption("2", "Factures",
            () => GrandHotelApp.Instance.NavigateTo(typeof(PageFactures)));



        }
    }





}
