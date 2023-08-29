using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal abstract class RunnableItem
    {
        public class ShowTime : MenuItem, IRunnable
        {
            public ShowTime(string i_Title)
                : base(i_Title)
            {
            }

            public void Run()
            {
                Console.WriteLine(DateTime.Now.ToShortTimeString());
            }
        }

        public class ShowDate : MenuItem, IRunnable
        {
            public ShowDate(string i_Title)
                : base(i_Title)
            {
            }

            public void Run()
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
            }
        }

        public class ShowVersion : MenuItem, IRunnable
        {
            public ShowVersion(string i_Title)
                : base(i_Title)
            {
            }

            public void Run()
            {
                Console.WriteLine("Version: 22.2.4.8950");
            }
        }

        public class CountSpaces : MenuItem, IRunnable
        {
            public CountSpaces(string i_Title)
                : base(i_Title)
            {
            }

            public void Run()
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
        }
    }
}