using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen_Inlämningsuppgift
{
    internal class CropManager
    {
        public List<Crop> cropList = new List<Crop>();
        Crop cropCarrot = new Crop("Carrot", 53, 20);
        Crop cropApple = new Crop("Apple", 25, 21);
        Crop cropWheat = new Crop("Wheat", 76, 22);
        Crop cropPotato = new Crop("Potato", 128, 23);
        Crop cropCorn = new Crop("Corn", 98, 24);
        Crop cropHay = new Crop("Hay", 44, 25);
        Crop cropBeet = new Crop("Beet", 37, 26);
        Crop cropBean = new Crop("Bean", 234, 27);
        Crop cropCabbage = new Crop("Cabbage", 89, 28);
        Crop cropPepper = new Crop("Pepper", 77, 29);

        public CropManager()
        {
            cropList.Add(cropCarrot);
            cropList.Add(cropApple);
            cropList.Add(cropWheat);
            cropList.Add(cropPotato);
            cropList.Add(cropCorn);
            cropList.Add(cropHay);
            cropList.Add(cropBeet);
            cropList.Add(cropBean);
            cropList.Add(cropCabbage);
            cropList.Add(cropPepper);
        }
        
        public void CropMenu()
        {
            Console.Clear();
            Console.WriteLine("Hello, I'm the animal manager!");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("\nPress \"1\" to view the crops");
            Console.WriteLine("Press \"2\" to add a crop");
            Console.WriteLine("Press \"3\" to remove a crop");
            Console.WriteLine("Press \"0\" to quit");

            try
            {
                int inputCropMenu = int.Parse(Console.ReadLine());

                switch (inputCropMenu)
                {
                    case 1:
                        ViewCrops();
                        break;
                    case 2:
                        AddCrop();
                        break;
                    case 3:
                        RemoveCrop();
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

       private void ViewCrops()
        {
            foreach (var crop in cropList)
            {
                Console.WriteLine(crop.GetDescription());
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
        private void AddCrop()
        {
            while (true)
            {
                Console.WriteLine("Enter the name of the crop you want to add");
                string cropName = Console.ReadLine().ToLower();

                if (cropList.Exists(crop => crop.CropType == cropName))                                     // Någonting stämmer inte här 
                {
                    Console.WriteLine("We don't grow that crop here! Please choose one of the available crops.");
                }
                else
                {
                    Console.WriteLine("Enter the amount of the crop you want to add.");
                    try
                    {
                        int cropQuantity = int.Parse(Console.ReadLine());

                        Crop selectedCrop = cropList.Find(crop => crop.CropType.ToLower() == cropName);      // Någonting stämmer inte här 
                        selectedCrop.AddCrop(cropQuantity);

                        Console.WriteLine($"Added {cropQuantity} of {selectedCrop.CropType}. You now have {selectedCrop.Quantity} of this crop");
                        break;
                    }
                    catch (Exception ex)                                                                    // Någonting stämmer inte här 
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
            }
        }
        private void RemoveCrop()
        {
            while (true)
            {
                Console.WriteLine("Enter the name of the crop you want to remove");
                string cropName = Console.ReadLine().ToLower();

                if (!cropList.Exists(crop => crop.CropType == cropName))
                {
                    Console.WriteLine("We don't grow that crop here! Please choose one of the available crops.");
                }
                else
                {
                    Console.WriteLine("Enter the amount of how much you want to remove.");
                    try
                    {
                        int cropQuantity = int.Parse(Console.ReadLine());
                        
                        
                        Crop selectedCrop = cropList.Find(crop => crop.CropType.ToLower() == cropName);
                        selectedCrop.TakeCrop(cropQuantity);

                        Console.WriteLine($"Removed {cropQuantity} of {selectedCrop.CropType}. You now have {selectedCrop.Quantity} of this crop");
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
            }
        }
        public Crop GetCrops()
        {
            for (int i = 0; i < cropList.Count; i++)
            {
                Console.WriteLine(cropList[i]);
            }
            return null;
        }
    }
}
