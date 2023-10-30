using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Farmen_Inlämningsuppgift
{
    internal class AnimalManager

    {
        CropManager cropmanager = new CropManager();
        //Animal animal = new Animal(0, "");

        List<Animal> animalList = new List<Animal>();

        Animal animalPig = new Animal("", "Carrot, Apple, Wheat, Potato, Corn, Hay, Beet, Bean, Cabbage, Pepper ", 1, "Pig");
        Animal animalHorse = new Animal("", "Carrot, Apple, Hay", 2, "Horse");
        Animal animalCow = new Animal("Cow", "Wheat, Hay", 3, "" );
        Animal animalGoat = new Animal("Goat", "Corn, Bean, Pepper", 4, "" );
        Animal animalChicken = new Animal("Chicken", "Wheat, Bean, Potato, Cabbage", 5, "");
        Animal animalSheep = new Animal("Sheep", "Beet, Hay, Wheat, Apple", 6, "");


        public AnimalManager()
        {
            //animalList.Add(animalPig);
            //animalList.Add(animalHorse);
            //animalList.Add(animalCow);
            //animalList.Add(animalGoat);
            //animalList.Add(animalChicken);
            //animalList.Add(animalSheep);
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
                
                Console.WriteLine(animal.GetDescription());

            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();

            
        }
        private bool AddAnimal()
        {
            Console.WriteLine("This is all the animals on the farm: ");

            ViewAnimals();

            while (true)
            {
                string inputSpecies;
                Console.WriteLine("What kind of animal do you want to add? Press 1-6");
                Console.WriteLine("1. Pig");
                Console.WriteLine("2. Horse");
                Console.WriteLine("3. Cow");
                Console.WriteLine("4. Goat");
                Console.WriteLine("5. Chicken");
                Console.WriteLine("6. Sheep");
                int inputId = int.Parse(Console.ReadLine());

                List<string> acceptableCropTypes = new List<string>();
                switch (inputId)
                {
                    case 1:
                        //acceptableCropTypes = new List<string> { "Carrot", "Apple", "Wheat", "Potato", "Corn", "Hay", "Beet", "Bean", "Cabbage", "Pepper" };
                        animalList.Add(animalPig);

                        break;
                    case 2: 
                        animalList.Add(animalHorse); 
                        break;
                    case 3: 
                        animalList.Add(animalCow);
                        break;
                    case 4:
                        animalList.Add(animalGoat);
                        break;
                    case 5:
                        animalList.Add(animalChicken);
                        break;
                    case 6:
                        animalList.Add(animalSheep);
                        break;
                        default:
                        Console.WriteLine("Write an animal!");
                        break;

                }

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

                    
                    Console.ReadKey();

                    //string inputCrop = Console.ReadLine();
                    //string choosenCrop;

                    //if (!cropmanager.cropList.Exists(crop => crop.CropType == inputCrop))
                    //{
                    //    choosenCrop = inputCrop;
                    //}
                    //else
                    //{
                    //    Console.WriteLine("You need to choose a crop from the list.");
                    //    continue;
                    //}

                    animalList.Add(new Animal(inputName, "", inputId, "" ));
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
