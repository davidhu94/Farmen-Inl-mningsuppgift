using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Farmen_Inlämningsuppgift
{
    internal class Animal : Entity
    {
        CropManager cropmanager = new CropManager();
        public string Species { get; set; }
        private string AcceptableCropTypes;

        public Animal(string name, string acceptableCropTypes, int id, string species)
            : base(id, name)
        {
            Species = species;
            AcceptableCropTypes = acceptableCropTypes;
            Name = name;
        }

        public override string GetDescription()
        {
            return ($"This is a: {Species} named {Name} with Id: {Id}, it eats:{AcceptableCropTypes}");

        }

        public string Feed(string Crop)
        {

            
            string selectedCrop;
            Crop selectedCrop = cropList.Find(crop => crop.CropType.ToLower() == cropName);
            {

            }
        {
            selectedCrop.Quantity -= 1;
        }

        }
    }
}
