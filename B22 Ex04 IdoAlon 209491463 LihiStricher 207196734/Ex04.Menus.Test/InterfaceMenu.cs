using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class InterfaceMenu
    {
        internal static void BuildMenu()
        {
            MainMenu menu = new MainMenu("Interface - Main Menu");
            MenuItem firstMenu = new MenuItem("Show Date/Time");
            MenuItem showDate = new RunnableItem.ShowDate("Show Date");
            MenuItem showTime = new RunnableItem.ShowTime("Show Time");
            MenuItem secondMenu = new MenuItem("Version and Spaces");
            MenuItem countSpaces = new RunnableItem.CountSpaces("Count Spaces");
            MenuItem showVersion = new RunnableItem.ShowVersion("Show Version");

            firstMenu.SetAsSubMenu();
            secondMenu.SetAsSubMenu();
            firstMenu.PriviosMenu = menu.SubMenu;
            secondMenu.PriviosMenu = menu.SubMenu;
            showDate.PriviosMenu = firstMenu;
            showTime.PriviosMenu = firstMenu;
            countSpaces.PriviosMenu = secondMenu;
            showVersion.PriviosMenu = secondMenu;
            menu.SubMenu.ListOfMenuItem.Add(firstMenu);
            menu.SubMenu.ListOfMenuItem.Add(secondMenu);
            firstMenu.ListOfMenuItem.Add(showDate);
            firstMenu.ListOfMenuItem.Add(showTime);
            secondMenu.ListOfMenuItem.Add(countSpaces);
            secondMenu.ListOfMenuItem.Add(showVersion);
            menu.Show();
        }
    }
}
