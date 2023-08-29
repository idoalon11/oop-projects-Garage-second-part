using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        public MenuItem SubMenu { get; set; }

        public MainMenu(string i_Title)
        {
            SubMenu = new MenuItem(i_Title);
            SubMenu.ListOfMenuItem.Add(new MenuItem("Exit"));
        }

        public void Show()
        {
            SubMenu.Show();
        }
    }
}
