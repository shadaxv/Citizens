using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizens
{
    class Program
    {
        static void Main(string[] args)
        {
            string horizontalLine = new string('═', 60);
            Console.WriteLine("{0}{1}", Environment.NewLine, horizontalLine);
            Console.WriteLine("══════════════════════  Citizens.exe  ══════════════════════");
            Console.WriteLine("{1}{0}", Environment.NewLine, horizontalLine);
            Citizens.ShowCitizens(0);
        }
    }

    class Citizens
    {
        /// <summary>
        /// New citizens list
        /// </summary>
        private static List<Tuple<string, string>> CitizensList = new List<Tuple<string, string>>();
        /// <summary>
        /// String with 60 '=' signs
        /// </summary>
        private static string horizontalLine = new string('═', 60);

        /// <summary>
        /// Shows a list of citizens
        /// </summary>
        public static void ShowCitizens(int param)
        {
            /// <summary>
            /// If citizens list is empty
            /// </summary>
            bool isEmpty = !CitizensList.Any();
            if (isEmpty)
            {
                Console.WriteLine("{0}{1}{0}", Environment.NewLine, horizontalLine);
                Console.WriteLine("No citizens in the list...");
                Console.WriteLine("{0}{1}{0}{0}", Environment.NewLine, horizontalLine);
            }

            else
            {
                Console.WriteLine("{0}{0}{1}{0}", Environment.NewLine, horizontalLine);
                int currentCitizenCount = 0;
                foreach (var currentCitizen in CitizensList)
                {
                    currentCitizenCount++;
                    Console.WriteLine("{3}No. {2} | Name: {0} | Last name: {1}", currentCitizen.Item1, currentCitizen.Item2, currentCitizenCount, Environment.NewLine);
                }
                Console.WriteLine("{0}All citizens: {1}{0}", Environment.NewLine, currentCitizenCount);
                Console.WriteLine("{0}{1}{0}{0}", Environment.NewLine, horizontalLine);
            }

            if (param == 1)
            {
                /// <summary>
                /// Calling a method to exit application
                /// </summary>
                ExitProgram();
            }
            else
            {
                /// <summary>
                /// Calling a method to add a citizen to the list
                /// </summary>
                AddCitizen();
            }
        }

        /// <summary>
        /// Method adding citizen to the list
        /// </summary>
        private static void AddCitizen()
        {
            Console.Write("Would you like to add a citizen to the list? (Y/N): ");
            string wantToAdd = Console.ReadLine().ToLower();

            /// <summary>
            /// Adding a citizen to the list
            /// </summary>
            if (wantToAdd == "yes" || wantToAdd == "y")
            {
                Console.Write("{0}Provide the name of the citizen: ", Environment.NewLine);
                string citizenName = Console.ReadLine();
                Console.Write("{0}Provide the last name of the citizen: ", Environment.NewLine);
                string citizenLastname = Console.ReadLine();

                CitizensList.Add(new Tuple<string, string>(citizenName, citizenLastname));
                /// <summary>
                /// Shows a list of citizens and adding new citizen
                /// </summary>
                ShowCitizens(0);
            }

            /// <summary>
            /// Shows a list of citizens and exit application
            /// </summary>
            ShowCitizens(1);
        }

        private static void ExitProgram()
        {
            Console.Write("Are you sure you want to exit the application? (Y/N): ");
            string wantToExit = Console.ReadLine().ToLower();
            if (wantToExit == "yes" || wantToExit == "y")
            {
                Console.WriteLine("{0}{1}{0}", Environment.NewLine, horizontalLine);
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                Environment.Exit(0);
            }

            else
            {
                ShowCitizens(0);
            }
        }
    }
}