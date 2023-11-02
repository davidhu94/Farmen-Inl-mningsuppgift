using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen_Inlämningsuppgift
{
    internal class Crop : Entity
    {
        
        public string CropType { get; set; }
        public int Quantity { get; set; }

        public Crop(string cropType, int quantity, int id)
            : base(id, cropType)
        {
            CropType = cropType;
            Quantity = quantity;
            Id = id;

            
        }

        public override string GetDescription() 
        {
            return ($"Crop: {CropType}. Quantity: {Quantity}. Id: {Id}");
        }

        public void AddCrop(int addCropAmount) 
        {
            while (true)
            {
                if (addCropAmount > 0)
                {
                    Quantity += addCropAmount;
                    Console.WriteLine("Nu är vi i IF");
                    Console.ReadKey();
                    break;

                }
                else if(addCropAmount < 0)
                {
                    Console.WriteLine("Negative number!");
                }
                else
                {
                    Console.WriteLine("You need to add something!");
                    Console.WriteLine("Nu är vi i ELSE g");
                    Console.ReadKey();
                }
            }
        }

        public bool TakeCrop(int takeCropAmount)  
        {
            
            if (Quantity < takeCropAmount)
            {
                Console.WriteLine("You don't have enough crops.");
                return false;
            }
            else
            {
                
                Quantity -= takeCropAmount;
           
                Console.ReadKey();
                return true;
            }
        }
    }
}
