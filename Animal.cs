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
        public string Species { get; set; }

        private List<string>_acceptableCropTypes;

        public Animal(string species, string name, int id, string acceptableCropTypesString)
            : base(id, name)
        {
            Species = species;
            Name = name;
            Id = id;
            _acceptableCropTypes = acceptableCropTypesString.Split(',').Select(s => s.Trim().ToLower()).ToList();
        }

        public override string GetDescription()
        {
            return $"There is a {Species} named {Name} with Id {Id}, it eats: {string.Join(", ", acceptableCropTypes)}";

        }

        public List<string> acceptableCropTypes
        {
            get { return _acceptableCropTypes; }
        }

        public void Feed(Crop chosenCrop)
        {
            while (true)
            {
                if (acceptableCropTypes.Contains(chosenCrop.CropType.ToLower()))
                {
                    Console.WriteLine($"{Name} is eating the {chosenCrop.CropType}!");
                    chosenCrop.TakeCrop(1);
                    break;
                }
                else
                {
                    Console.WriteLine($"{Name} doesn't eat {chosenCrop.CropType}, try something else.");
                }
            }
        }
    }
}
