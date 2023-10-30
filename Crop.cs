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

        public Crop(string name, int quantity, int id, string cropType)
            : base(id, name)
        {
            CropType = cropType;
            Quantity = quantity;
            Id = id;
        }

        public override string GetDescription() //Ger croptype, quantity och id om en specifik gröda.
        {
            return ("Crop: " + CropType + ". With quantity: " + Quantity + " Id: " + Id);
        }

        public void AddCrop(int addCropAmount) // Användaren kan lägga till grödor istället för att använda oss av workers.
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
        public bool TakeCrop(int takeCropAmount) // användaren kan ta en gröda och ge till ett djur. 
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
