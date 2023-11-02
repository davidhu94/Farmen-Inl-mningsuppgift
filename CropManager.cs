using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen_Inlämningsuppgift
{
    internal class CropManager
    {
        //Premade list of existing crops where the user can change the quantity of the crops
        public List<Crop> cropList = new List<Crop>();
        Crop cropCarrot = new Crop("Carrot", 53, 1);
        Crop cropApple = new Crop("Apple", 25, 2);
        Crop cropWheat = new Crop("Wheat", 76, 3);
        Crop cropPotato = new Crop("Potato", 128, 4);
        Crop cropCorn = new Crop("Corn", 98, 5);
        Crop cropHay = new Crop("Hay", 44, 6);
        Crop cropBeet = new Crop("Beet", 37, 7);
        Crop cropBean = new Crop("Bean", 234, 8);
        Crop cropCabbage = new Crop("Cabbage", 89, 9);
        Crop cropPepper = new Crop("Pepper", 77, 10);

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
        
        //Main menu for the crop manager where the user choose what to do
        public void CropMenu()
        {
            while (true)
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

        //Function to view all the crops from the list of crops
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
                return;
                
            }
        }

        //Here the user can add quantity of a chosen crop 
        private void AddCrop()
        {
            Console.Clear();
            GetCrops();

            while (true)
            {
                Console.WriteLine("\nEnter the ID of the crop you want to add:");
                Console.WriteLine("Press \"0\" to go back:");
                int cropId;

                if (!int.TryParse(Console.ReadLine(), out cropId))
                {
                    Console.WriteLine("Please enter a valid ID.");
                    continue;
                }

                if (cropId == 0)
                {

                    break;
                }

                if (!cropList.Exists(crop => crop.Id == cropId))

                {
                    Console.WriteLine("We don't grow that crop here! Please choose one of the available crops.");

                }
                else if (cropList.Exists(crop => crop.Id == cropId))
                {
                    Console.WriteLine("Enter the amount of the crop you want to add:");

                    while (true)
                    {
                        try
                        {
                            int cropQuantity = int.Parse(Console.ReadLine());

                            Crop selectedCrop = cropList.Find(crop => crop.Id == cropId);
                            selectedCrop.AddCrop(cropQuantity);
                            Console.Clear();
                            if (cropQuantity > 0)
                            {
                                Console.WriteLine($"You've added {cropQuantity} {selectedCrop.CropType}. You now have {selectedCrop.Quantity} of this crop.");
                                Console.WriteLine("Press a key to go back to Crop Manager.");
                                Console.ReadKey();
                                return;
                            }
                            Console.WriteLine("You didn't add any crops.");
                            Console.WriteLine("Press a key to go back to Crop Manager.");
                            Console.ReadKey();
                            return;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please enter a valid number.");
                        }
                    }
                }
            }
        }

        //Here the user can remove quantity of a crop
        private void RemoveCrop()
        {
            Console.Clear();
            GetCrops();

            while (true)
            {
                Console.WriteLine("\nEnter the ID of the crop you want to remove:");
                Console.WriteLine("Press \"0\" to go back:");
                int cropId;

                if (!int.TryParse(Console.ReadLine(), out cropId))
                {
                    Console.WriteLine("Please enter a valid ID.");
                    continue;
                }

                if (cropId == 0)
                {

                    break;
                }

                if (!cropList.Exists(crop => crop.Id == cropId))

                {
                    Console.WriteLine("We don't grow that crop here! Please choose one of the available crops.");

                }
                else if (cropList.Exists(crop => crop.Id == cropId))
                {
                    Console.WriteLine("Enter the amount of the crop you want to remove:");

                    while (true)
                    {
                        try
                        {
                            int cropQuantity = int.Parse(Console.ReadLine());

                            Crop selectedCrop = cropList.Find(crop => crop.Id == cropId);
                            selectedCrop.TakeCrop(cropQuantity);
                            Console.Clear();
                            if (cropQuantity <= selectedCrop.Quantity && cropQuantity >= 0)
                            {
                                Console.WriteLine($"You've removed {cropQuantity} {selectedCrop.CropType}. You now have {selectedCrop.Quantity} of this crop.");
                                Console.WriteLine("Press a key to go back to Crop Manager.");
                                Console.ReadKey();
                                return;

                            }
                            else if (cropQuantity > selectedCrop.Quantity)
                            {
                                Console.WriteLine("You dont't have that many crops.");
                            }
                            else if (cropQuantity <= 0)
                            {
                                Console.WriteLine("You didn't remove any crops!");
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Please enter a valid number.");
                            continue;
                        }
                        Console.WriteLine("Press a key to go back to Crop Manager.");
                        Console.ReadKey();
                        return;
                    }
                }
            }
        }

        //Get the crop list
        public Crop GetCrops()          
        {
            Console.WriteLine("This is the crops we grow on the farm: ");
            foreach (var crop in cropList)
            {
                Console.WriteLine(crop.GetDescription());
            }
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            return null;
        }
    }
}
