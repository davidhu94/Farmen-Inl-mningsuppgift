﻿using System;
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
            bool continuing = true;
            while (continuing)
            {
                Console.Clear();
                Console.WriteLine("Hello, I'm the Crop Manager!");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("\nPress \"1\" to view the crops");
                Console.WriteLine("Press \"2\" to add a crop");
                Console.WriteLine("Press \"3\" to remove a crop");
                Console.WriteLine("Press \"0\" to go back");

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
                            return;
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

       private void ViewCrops(bool returnToMenu = false)
        {
            Console.WriteLine("This is the crops we grow on the farm: ");
            foreach (var crop in cropList)
            {
                Console.WriteLine(crop.GetDescription());
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            

            if (returnToMenu == false)
            {
                CropMenu();
                
            }
        }
        private void AddCrop()
        {
            ViewCrops(true);
            while (true)
            {
                Console.WriteLine("\nEnter the name of the crop you want to add:");
                string cropName = Console.ReadLine();

                if (!cropList.Exists(crop => string.Equals(crop.CropType, cropName, StringComparison.OrdinalIgnoreCase)))
            
                {
                    Console.WriteLine("We don't grow that crop here! Please choose one of the available crops.");
                    
                }
                
                else if (cropList.Exists(crop => string.Equals(crop.CropType, cropName, StringComparison.OrdinalIgnoreCase)))
             
                {
                    Console.WriteLine("Enter the amount of the crop you want to add:");
                    while (true)
                    {
                        try
                        {
                            int cropQuantity = int.Parse(Console.ReadLine());

                            Crop selectedCrop = cropList.Find(crop => crop.CropType.ToLower() == cropName);      
                            selectedCrop.AddCrop(cropQuantity);
                            Console.Clear();
                            Console.WriteLine($"You've added {cropQuantity} {selectedCrop.CropType}. You now have {selectedCrop.Quantity} of this crop.");
                            Console.WriteLine("Press a key to go back to Crop Manager.");
                            Console.ReadKey();
                            CropMenu();


                        }
                        catch (Exception ex)                                                                
                        {
                            Console.WriteLine("Please enter a valid number.");
                        }
                    }
                }
            }
        }
        private void RemoveCrop()
        {
            ViewCrops(true);
            while (true)
            {
                Console.WriteLine("\nEnter the name of the crop you want to remove:");  // Man ska kunna gå bakåt. Vi har en sån funktion i feed animal.
                string cropName = Console.ReadLine();                                   // Även i flera menyer ska man kunna gå bakåt.

                if (!cropList.Exists(crop => string.Equals(crop.CropType, cropName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("We don't grow that crop here! Please choose one of the available crops.");
                }

                else if (cropList.Exists(crop => string.Equals(crop.CropType, cropName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Enter the amount of how much you want to remove:");
                    while (true)
                    {
                        
                        try
                        {
                            int cropQuantity = int.Parse(Console.ReadLine());

                            Crop selectedCrop = cropList.Find(crop => crop.CropType.ToLower() == cropName); // När man trycker enter här så går man till en ny rad
                                                                                                            // vilket vi inte vill göra.
                            selectedCrop.TakeCrop(cropQuantity);
                            Console.Clear();
                            Console.WriteLine($"Removed {cropQuantity} of {selectedCrop.CropType}. You now have {selectedCrop.Quantity} of this crop");
                            Console.WriteLine("Press a key to go back to Crop Manager.");
                            Console.ReadKey();
                            CropMenu();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a valid number.");
                        }
                    }
                }
            }
        }
        public Crop GetCrops()          // Var ska vi använda denna? Den används ingenstans. 
        {
            for (int i = 0; i < cropList.Count; i++)
            {
                Console.WriteLine(cropList[i]);
            }
            return null;
        }
    }
}
