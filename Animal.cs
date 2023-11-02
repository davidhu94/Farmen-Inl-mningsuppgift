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

        public string Name { get; set; }
            
        public Animal(string species, string name, int id, List<string> acceptableCropTypes)
            : base(id, name)
        {
            Species = species;
            Name = name;
            Id = id;
            _acceptableCropTypes = acceptableCropTypes.Select(s => s.Trim().ToLower()).ToList();
        }

        public override string GetDescription()
        {
            return $"There is a {Species} named {Name} with Id {Id}, it eats: {string.Join(", ", AcceptableCropTypes)}";

        }

        public List<string> AcceptableCropTypes
        {
            get { return _acceptableCropTypes; }
        }

        //Function to feed an animal, which calls for the math in the function takeCrop()
        public void Feed(Crop chosenCrop, ref bool failedFeed)
        {
            if (AcceptableCropTypes.Contains(chosenCrop.CropType.ToLower()))
            {
                Console.WriteLine($"\n{Name} is eating the {chosenCrop.CropType}! Press a key to continue.");
                Console.ReadKey();
                chosenCrop.TakeCrop(1);
                failedFeed = false;
            }
            else
            {
                Console.WriteLine($"\n{Name} doesn't eat {chosenCrop.CropType}, try something else.");
                failedFeed = true;
            }
        }
    }
}
