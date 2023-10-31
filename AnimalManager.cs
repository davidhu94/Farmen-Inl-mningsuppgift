using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Farmen_Inlämningsuppgift
{
    internal class AnimalManager

    {
        CropManager cropmanager = new CropManager();

        List<Animal> animalList = new List<Animal>();
                                                                         //BYT NAMN PÅ DJUREN
        Animal animalPig = new Animal("Pig","Joe",1, "Carrot, Apple, Wheat, Potato, Corn, Hay, Beet, Bean, Cabbage, Pepper ");
        Animal animalHorse = new Animal("Horse", "Joe", 2, "Carrot, Apple, Hay");
        Animal animalCow = new Animal("Cow", "Joe", 3, "Wheat, Hay");
        Animal animalGoat = new Animal("Goat", "Joe", 4, "Corn, Bean, Pepper");
        Animal animalChicken = new Animal("Chicken", "Joe", 5, "Wheat, Bean, Potato, Cabbage");
        Animal animalSheep = new Animal("Sheep", "Joe", 6, "Beet, Hay, Wheat, Apple");

        public AnimalManager()
        {
            animalList.Add(animalPig);
            animalList.Add(animalHorse);
            animalList.Add(animalCow);
            animalList.Add(animalGoat);
            animalList.Add(animalChicken);
            animalList.Add(animalSheep);
        }

        public void AnimalMenu()
        {
            
                Console.Clear();
                Console.WriteLine("Hello, I'm the animal manager!");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("\nPress \"1\" to view the animals");
                Console.WriteLine("Press \"2\" to add an animal");
                Console.WriteLine("Press \"3\" to remove an animal");
                Console.WriteLine("Press \"4\" to feed the animals");
                Console.WriteLine("Press \"0\" to quit");

                try
                {
                    int inputAnimalMenu = int.Parse(Console.ReadLine());

                    switch (inputAnimalMenu)
                    {
                        case 1:
                            ViewAnimals();
                            break;
                        case 2:
                            AddAnimal();
                            break;
                        case 3:
                            RemoveAnimal();
                            break;
                        case 4:
                            FeedAnimals();
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

        private void ViewAnimals()
        {
            Console.Clear();
            Console.WriteLine("This is all the animals on the farm: ");

            if (animalList.Count <= 0)
            {
                Console.WriteLine("The farm is empty, go and add some animals!");
                Console.ReadKey();
                AnimalMenu();
            }
            foreach (var animal in animalList)
            {
                Console.WriteLine(animal.GetDescription());
            }
            Console.WriteLine("\nPress a key to continue...");
            Console.ReadKey();

            
        }

        private bool AddAnimal()
        {
            ViewAnimals();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("What kind of animal do you want to add? Press 1-6");
                Console.WriteLine("1. Pig");
                Console.WriteLine("2. Horse");
                Console.WriteLine("3. Cow");
                Console.WriteLine("4. Goat");
                Console.WriteLine("5. Chicken");
                Console.WriteLine("6. Sheep");
                Console.WriteLine("0. Go back.");

                try
                {
                    
                    int inputSpecies = int.Parse(Console.ReadLine());
                    if (inputSpecies == 0)
                    {
                        return false;
                    }

                    if (inputSpecies >= 1 && inputSpecies <= 6)
                    {
                        Console.Clear();

                        Console.WriteLine("Write a unique Id of the animal you want to add: ");
                        Console.WriteLine("0. to go back.");
                        
                        
                        int uniqueId;
                        if (int.TryParse(Console.ReadLine(), out uniqueId) && !animalList.Exists(animal => animal.Id == uniqueId))
                        {
                            Console.Clear();

                            Console.WriteLine("What name?");
                            string inputName = Console.ReadLine();
                            switch (inputSpecies)
                            {                                      
                                case 1:
                                    animalList.Add(new Animal(animalPig.Species, inputName, uniqueId, string.Join(", ", animalPig.acceptableCropTypes)));
                                    break;
                                case 2:
                                    animalList.Add(new Animal(animalHorse.Species, inputName, uniqueId, string.Join(", ", animalHorse.acceptableCropTypes)));
                                    break;
                                case 3:
                                    animalList.Add(new Animal(animalCow.Species, inputName, uniqueId, string.Join(", ", animalCow.acceptableCropTypes)));
                                    break;
                                case 4:
                                    animalList.Add(new Animal(animalGoat.Species, inputName, uniqueId, string.Join(", ", animalGoat.acceptableCropTypes)));
                                    break;
                                case 5:
                                    animalList.Add(new Animal(animalChicken.Species, inputName, uniqueId, string.Join(", ", animalChicken.acceptableCropTypes)));
                                    break;
                                case 6:
                                    animalList.Add(new Animal(animalSheep.Species, inputName, uniqueId, string.Join(", ", animalSheep.acceptableCropTypes)));
                                    break;
                               
                            }
                            Console.Clear();

                            Console.WriteLine("\nThe animal was successfully created!");
                            Console.WriteLine("Press a key to continue...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nCreate an animal by pressing one of the numbers (1-6)");
                        Console.WriteLine("Press a key to try again...");
                        Console.ReadKey();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nYou can only use numbers (1-6)");
                    Console.WriteLine("Press a key to try again...");
                    Console.ReadKey();

                }
            }
        }

        private void RemoveAnimal()      //Ändra till int om vi hinner. Men då behöver vi ändra koden!!  private int RemoveAnimal(int)
        {
            ViewAnimals();

            while (true)
            {
                Console.WriteLine("\nWrite the id of the animal you want to slaughter: ");
                int removeId;

                try
                {
                    removeId = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("You can only use numbers.");
                    continue;
                }

                Animal animalToRemove = animalList.Find(animal => animal.Id == removeId);
                if (animalToRemove == null)
                {
                    Console.WriteLine("This ID doesnt't exists, choose another one");
                }
                else
                {
                    animalList.Remove(animalToRemove);
                    Console.WriteLine("\nAnimal was successfully slaughtered :) ");

                    Console.WriteLine("Press a key to continue...");

                    Console.ReadKey();
                    break;
                }
            }
        }

        private void FeedAnimals()
            {
                ViewAnimals();

                Console.WriteLine("\nWrite the ID of the animal you want to feed:");
                int chosenId;

                if (int.TryParse(Console.ReadLine(), out chosenId) && animalList.Exists(animal => animal.Id == chosenId))
                {
                    var selectedAnimal = animalList.Find(animal => animal.Id == chosenId);

                    Console.WriteLine($"You've selected the {selectedAnimal.Species} named {selectedAnimal.Name}");
                    Console.WriteLine("\nChoose a crop from the list to feed the animal:");

                    foreach (var crop in cropmanager.cropList)
                    {
                        Console.WriteLine(crop.CropType);
                    }

                    while (true)
                    {
                        string selectedCropName = Console.ReadLine();

                        Crop chosenCrop = cropmanager.cropList.Find(crop => crop.CropType.ToLower() == selectedCropName.ToLower());

                        if (chosenCrop != null)
                        {

                            Console.WriteLine($"You try to feed {selectedAnimal.Name} with {chosenCrop.CropType} ");
                            selectedAnimal.Feed(chosenCrop);

                        }
                        else
                        {
                            Console.WriteLine("The selected crop does not exist, choose from the list above.");
                        }

                        Console.ReadKey();
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("There's no animal with that ID, try again.");
                }
            
        }        
    }
}
