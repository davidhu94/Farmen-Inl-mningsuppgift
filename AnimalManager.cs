using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen_Inlämningsuppgift
{
    internal class AnimalManager

    {
        CropManager cropmanager = new CropManager();
        Animal animal = new Animal(0, "");

        List<Animal> animalList = new List<Animal>();

        Animal animalPig = new Animal("Pig", "Carrot, Apple, Wheat, Potato, Corn, Hay, Beet, Bean, Cabbage, Pepper ", 1, "");
        Animal animalHorse = new Animal("Horse", "Carrot, Apple, Hay", 2, "" );
        Animal animalCow = new Animal("Cow", "Wheat, Hay", 3, "" );
        Animal animalGoat = new Animal("Goat", "Corn, Bean, Pepper", 4, "" );
        Animal animalChicken = new Animal("Chicken", "Wheat, Bean, Potato, Cabbage", 5, "");
        Animal animalSheep = new Animal("Sheep", "Beet, Hay, Wheat, Apple", 6, "");


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
            Console.WriteLine("Press \"4\" to feed the animals"); //välj crop att använda, (get crop)
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
            foreach (var animal in animalList)
            {
                animal.GetDescription();
            }
        }
        private bool AddAnimal()
        {
            Console.WriteLine("This is all the animals on the farm: ");

            ViewAnimals();

            while (true)
            {
                int inputId;

                Console.WriteLine("Write a unique Id of the animal you want to add: ");

                try
                {
                    inputId = int.Parse(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("You can only use numbers.");
                    continue;
                }

                if(animalList.Exists(animal => animal.Id == inputId))
                {
                    Console.WriteLine("This ID already exists, choose another one");
                    continue;
                }
                else
                {
                    Console.WriteLine("What name?");
                    string inputName = Console.ReadLine();

                    Console.WriteLine("What should it eat?");
                    Console.WriteLine("You can choose between the listed crops below: ");

                    foreach (Crop crop in cropmanager.cropList)
                    {
                        Console.WriteLine(crop);
                    }

                    string inputCrop = Console.ReadLine().ToLower();
                    string choosenCrop = "";

                    if (cropmanager.cropList.Exists(crop => crop.CropType == inputCrop))
                    {
                        choosenCrop = inputCrop;
                    }
                    else
                    {
                        Console.WriteLine("You need to choose a crop from the list.");
                        continue;
                    }

                    animalList.Add(new Animal(inputName, choosenCrop, inputId, ""));
                    Console.WriteLine("Your animal was successfully added!");
                    return true;
                }
            }
        }

        private void RemoveAnimal()      //Ändra till int om vi hinner. Men då behöver vi ändra koden!!  private int RemoveAnimal(int)
        {
            Console.WriteLine("This is all the animals on the farm: ");

            ViewAnimals();

            while (true)
            {
                Console.WriteLine("Write the id of the animal you want to slaughter: ");
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
                    Console.WriteLine("Animal was successfully slaughtered :) ");
                    break;
                }
            }
        }

        private void FeedAnimals()
        {
            Console.WriteLine("Write the ID of the animal you want to feed:");

            ViewAnimals();

            while (true)
            {
                int chosenId = int.Parse(Console.ReadLine());
                
                if (!animalList.Exists(animal => animal.Id == chosenId))
                {
                    Console.WriteLine("There's no animal with that ID, try again");
                }

                else
                {
                    Animal selectedAnimal = animalList.Find(animal => animal.Id == chosenId);

                    Console.WriteLine($"You selected {selectedAnimal.Id}. Now, choose a crop to feed the animal.");

                    while (true)
                    {
                        string selectedCropName = Console.ReadLine();

                        Crop chosenCrop = cropmanager.cropList.Find(crop => crop.CropType.ToLower() == selectedCropName.ToLower());

                        if (chosenCrop != null)
                        {
                            selectedAnimal.Feed(chosenCrop);
                            break;
                        }
                        Console.WriteLine("The crop does not exist, try again.");
                    }  
                }
            }
        }
    }
}
