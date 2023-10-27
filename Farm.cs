using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen_Inlämningsuppgift
{
    internal class Farm
    {
        AnimalManager animalManager = new AnimalManager();

        CropManager cropManager = new CropManager();

        public void MainMenu()
        {
            Console.WriteLine("Welcome to the Farm!");

            while (true)
            {
                Console.WriteLine("Choose below who you would like to contact:");
                Console.WriteLine("\nPress \"1\" for the animal manager");
                Console.WriteLine("Press \"2\" for the crop manager");
                Console.WriteLine("Press \"0\" to quit");

                try
                {
                    int inputMainMenu = int.Parse(Console.ReadLine());

                    switch (inputMainMenu)
                    {
                        case 1:

                            animalManager.AnimalMenu();
                            break;
                        case 2:
                            cropManager.CropMenu();
                            break;
                        case 0:
                            Console.WriteLine("Closing the program...");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("That is not a valid choice, choose from the menu and try again.");
                            break;
                    }
                }
                catch (FormatException) 
                {
                    Console.WriteLine($"You can only use numbers, choose from the menu and try again.");
                }
            }
        }
    }
}
