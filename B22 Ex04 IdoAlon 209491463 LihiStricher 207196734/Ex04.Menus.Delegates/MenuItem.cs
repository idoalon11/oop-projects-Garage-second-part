using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public event Action LeafClick;

        private readonly List<MenuItem> r_ListOfMenuItem;

        public List<MenuItem> ListOfMenuItem
        {
            get { return r_ListOfMenuItem; }
        }

        public MenuItem PriviosMenu { get; set; }

        private readonly string r_Title;

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
            r_ListOfMenuItem = new List<MenuItem>();
        }

        public bool IsSubMenu { get; set; }

        public void SetAsSubMenu()
        {
            IsSubMenu = true;
            ListOfMenuItem.Add(new MenuItem("Back"));
        }

        private void printSubMenu()
        {
            StringBuilder menuToPrint = new StringBuilder();

            menuToPrint.AppendLine("**" + r_Title + "**");
            menuToPrint.Append('-', 23);
            menuToPrint.AppendLine();
            for (int i = 1; i < ListOfMenuItem.Count; i++)
            {
                menuToPrint.AppendLine(i + " -> " + ListOfMenuItem[i].r_Title);
            }

            menuToPrint.AppendLine("0 -> " + ListOfMenuItem[0].r_Title);
            menuToPrint.Append('-', 23);
            Console.WriteLine(menuToPrint.ToString());
        }

        internal void Show()
        {
            string userInput;
            int indexOfMenuItem;
            MenuItem userChoise;

            printSubMenu();
            Console.Write("Enter your request: ");
            Console.WriteLine(string.Format("(1 to {0} or press '0' to Exit).", ListOfMenuItem.Count - 1));
            userInput = Console.ReadLine();
            while (!isValidOption(userInput, out indexOfMenuItem))
            {
                Console.WriteLine("Your input is invalid.");
                Console.Write("Enter your request: ");
                Console.WriteLine(string.Format("(1 to {0} or press '0' to Exit).", ListOfMenuItem.Count - 1));
                userInput = Console.ReadLine();
            }

            Console.Clear();
            if (indexOfMenuItem == 0)
            {
                if (this.PriviosMenu != null)
                {
                    this.PriviosMenu.Show();
                }
            }
            else
            {
                userChoise = ListOfMenuItem[indexOfMenuItem];
                if (userChoise.IsSubMenu)
                {
                    userChoise.Show();
                }
                else
                {
                    userChoise.OnLeafClick();
                    Console.WriteLine();
                    this.Show();
                }
            }
        }

        private bool isValidOption(string i_UserInput, out int o_IndexOfMenuItem)
        {
            bool isValid = false;

            if (int.TryParse(i_UserInput, out o_IndexOfMenuItem))
            {
                if(o_IndexOfMenuItem >= 0 && o_IndexOfMenuItem < ListOfMenuItem.Count)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        protected virtual void OnLeafClick()
        {
            if (LeafClick != null)
            {
                LeafClick.Invoke();
            }
        }
    }
}
