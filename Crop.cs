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
            if (addCropAmount > 0)
            {
                Quantity += addCropAmount;
            }
            else
            {
                Console.WriteLine("You need to add something!");
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
                return true;
            }
        }
    }
}
