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

        //Here's the math to add quantity to a crop
        public void AddCrop(int addCropAmount)
        {
            if (addCropAmount > 0)
            {
                Quantity += addCropAmount;
            }
            else
            {
                Console.WriteLine("You need to add something!");
            }
        }

        //Here's the math to remove quantity from a crop
        public bool TakeCrop(int takeCropAmount)
        {
            if (Quantity < takeCropAmount)
            {
                Console.WriteLine("You don't have enough crops.");
                return false;
            }
            else if (takeCropAmount > 0) 
            {
                Quantity -= takeCropAmount;
                return true;
            }
            return false;
        }
        
    }
}
