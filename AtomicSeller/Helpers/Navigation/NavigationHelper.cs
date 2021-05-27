using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace AtomicSeller.Helpers.Navigation
{
    public class NavigationHelper
    {
        // Singleton stuff
        public static NavigationHelper Instance;

        public static NavigationHelper Init(RouteData routeData, TempDataDictionary tempData)
        {
            return Instance = new NavigationHelper(routeData, tempData);
        }

        // First-level menu items
        public List<MenuItem> MenuItems { get; private set; }
        // First-level footer menu items
        public List<MenuItem> FooterItems { get; private set; }
        private List<MenuItem> AllItems { get; set; }

        private readonly TempDataDictionary tempData;
        private readonly string controller;
        private readonly string action;

        public enum MenuItemsEnum
        {
            Home,
            Orders,
            Shipments,
            Labels,
            Settings,
            Doc,
            Info,
            Support,
            Admin,
            StoresSettings,
            LabelsSettings,
            UserPreferences,
            BackupRestore,
            ExportData,
            InvoicesSettings,
            BulkTools,
            ShipmentDisplay,
            ShipmentEdit,
            ClientsList,
            ClientSettings,
            ClientSuperSettings,
            UserSettings,
            UserClientSettings,
            EmailReportingSettings
        }

        private NavigationHelper(RouteData routeData, TempDataDictionary tempData)
        {
            this.tempData = tempData;
            buildLists();

            controller = routeData.Values["controller"].ToString();
            action = routeData.Values["action"].ToString();

            // Ensure that no MenuItem has both controller&action AND children
            if (AllItems.Any(item => (item.Controller != null || item.Action != null) && item.Children.Count > 0))
                throw new Exception("A MenuItem cannot have both action link and children.");

            // Determine active item
            var activeMenuItem = AllItems.FirstOrDefault(menuItem => menuItem.Controller == controller && menuItem.Action == action);
            if (activeMenuItem != null)
                activeMenuItem.IsActive = true;
        }

        private void buildLists()
        {
            var sessionBag = SessionBag.Instance;

            MenuItems = new List<MenuItem>();
            FooterItems = new List<MenuItem>();
            AllItems = new List<MenuItem>();

            // Menu mes commandes
            var MainMenuSection = MenuItem.NewSection(Local.TranslatedMessage("MITFAFShippingProcess"), Mdi.Store);
            MainMenuSection.AddChildren(
                MenuItem.NewItem(MenuItemsEnum.Home, Local.TranslatedMessage("MITFAFquickProcessToolStripMenuItem"), Mdi.Home, "Home", "Index")
            );


            MenuItems.Add(MainMenuSection);


            // Build AllItems list
            AllItems.AddRange(MenuItems);
            foreach (var menuItem in MenuItems)
                AllItems.AddRange(menuItem.Children);
            AllItems.AddRange(FooterItems);
        }

        private MenuItem getActiveMenuItem(MenuItem item = null)
        {
            return (item != null ? item.Children : AllItems).FirstOrDefault(menuItem => menuItem.IsActive);
        }

        public List<MenuItem> GetBreadcrumb()
        {
            var list = new List<MenuItem>();

            MenuItem parent = null;
            MenuItem activeChild;

            while ((activeChild = getActiveMenuItem(parent)) != null)
            {
                list.Add(activeChild);
                parent = activeChild;
            }            
            return list;
        }

        public void SetActiveMenuItem(MenuItemsEnum item)
        {
            var menuItem = AllItems.FirstOrDefault(m => m.MenuItemEnum == item);

            if (menuItem == null)
            { /*               
                LogToView(
                //"Aucun MenuItem ne correspond à \"" +
                Local.TranslatedMessage("MESNULNoMenuItemAccordingTo")+
                    item +
                //"\".\nUtilisez-vous un MenuItem de l'extranet salariés sur l'extranet adhérents ou vice-versa ?",
                Local.TranslatedMessage("MESNULPLEASEUSECLIENTACCESSWEBSITE"),
                    FlashMessageType.Error);
                    */
                return;
            }

            var activeMenuItem = getActiveMenuItem();
            if (activeMenuItem != null)
            {
                /*
                LogToView(
                //"MenuItem actif auto-détecté (" +
                Local.TranslatedMessage("MESNULACTIVEMENU") +
                    activeMenuItem.MenuItemEnum +
                //") manuellement re-défini (" +
                Local.TranslatedMessage("MESNULREDEFINED") +
                    menuItem + 
                    "). " +
                //"Ceci est déconseillé car entraîne des dysfonctionnements du fil d'ariane."
                Local.TranslatedMessage("MESNULPLEASEDONTUSE")
                    , FlashMessageType.Warning);
                    */
                activeMenuItem.IsActive = false;
                
            }

            menuItem.IsActive = true;
        }

        public void EnsureActiveItem()
        {
            /*
            if (getActiveMenuItem() == null)
                
                LogToView(
                //"Aucun MenuItem n'a explicitement été défini comme actif, impossible de trouver un candidat implicite pour le controller \"" +
                Local.TranslatedMessage("MESNULNOEXPLICITMENUITEM")+
                    controller +
                //"\" et l'action \"" +
                Local.TranslatedMessage("MESNULANDACTION") +
                    action + 
                    "\"", 
                    FlashMessageType.Error);
                    */
        }

        private void LogToView(string message, FlashMessageType type)
        {
            if (!SessionBag.IsProd)
                FlashMessage.Flash(tempData, new FlashMessage(message, type, "NavigationHelper", true));
        }
    }
}
