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
            bool continuing = true;

            while (continuing)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Farm!");
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
                            continuing = false;
                            break;
                        default:
                            Console.WriteLine("That is not a valid choice, choose from the menu and try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException) 
                {
                    Console.WriteLine($"You can only use numbers, choose from the menu and try again.");
                    Console.ReadKey();
                }
            }
        }
    }
}
