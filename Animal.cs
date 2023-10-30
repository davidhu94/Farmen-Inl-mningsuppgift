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
        
        public Animal(int id, string name)
            : base(id, name)
        {
           
        }

        public Animal(string name, string acceptableCropTypes, int id, string species)
            : base(id, name)
        {
            Species = species;
            AcceptableCropTypes = acceptableCropTypes;
            Name = name;
            Id = id;
        }

        public override string GetDescription()
        {
            return ($"This is a: {Species} named {Name} with Id: {Id}, it eats:{AcceptableCropTypes}");

        }

        public void Feed(Crop chosenCrop)
        {
            if (AcceptableCropTypes.ToLower().Contains(chosenCrop.CropType.ToLower()))
            {
                Console.WriteLine($"{Name} is happily eating the {chosenCrop.CropType}!");
                chosenCrop.TakeCrop(1); // You might want to determine the quantity based on animal type.
            }
            else
            {
                Console.WriteLine($"{Name} doesn't eat {chosenCrop.CropType}.");
            }
        }
    }
}
