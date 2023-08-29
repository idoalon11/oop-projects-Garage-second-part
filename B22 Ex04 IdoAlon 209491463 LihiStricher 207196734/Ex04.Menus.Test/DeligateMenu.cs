using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    internal class DeligateMenu
    {
        internal static void BuildMenu()
        {
            MainMenu menu = new MainMenu("Delegate - Main Menu");
            MenuItem firstMenu = new MenuItem("Show Date/Time");
            MenuItem showDate = new MenuItem("Show Date");
            MenuItem showTime = new MenuItem("Show Time");
            MenuItem secondMenu = new MenuItem("Version and Spaces");
            MenuItem countSpaces = new MenuItem("Count Spaces");
            MenuItem showVersion = new MenuItem("Show Version");

            firstMenu.SetAsSubMenu();
            secondMenu.SetAsSubMenu();
            firstMenu.PriviosMenu = menu.SubMenu;
            secondMenu.PriviosMenu = menu.SubMenu;
            showDate.PriviosMenu = firstMenu;
            showTime.PriviosMenu = firstMenu;
            countSpaces.PriviosMenu = secondMenu;
            showVersion.PriviosMenu = secondMenu;
            showDate.LeafClick += showDate_OnLeafClick;
            showTime.LeafClick += showTime_OnLeafClick;
            countSpaces.LeafClick += countSpaces_OnLeafClick;
            showVersion.LeafClick += showVersion_OnLeafClick;
            menu.SubMenu.ListOfMenuItem.Add(firstMenu);
            menu.SubMenu.ListOfMenuItem.Add(secondMenu);
            firstMenu.ListOfMenuItem.Add(showDate);
            firstMenu.ListOfMenuItem.Add(showTime);
            secondMenu.ListOfMenuItem.Add(countSpaces);
            secondMenu.ListOfMenuItem.Add(showVersion);
            menu.Show();
        }

        private static void countSpaces_OnLeafClick()
        {
            string userInput;
            int spaces = 0;

            Console.WriteLine("Please enter your sentence:");
            userInput = Console.ReadLine();
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] == ' ')
                {
                    spaces++;
                }
            }

            Console.WriteLine(string.Format("There are {0} spaces in your sentence.", spaces));
        }

        private static void showVersion_OnLeafClick()
        {
            Console.WriteLine("Version: 22.2.4.8950");
        }

        private static void showTime_OnLeafClick()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        private static void showDate_OnLeafClick()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
    }
}
