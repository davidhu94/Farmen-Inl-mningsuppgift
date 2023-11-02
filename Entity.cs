using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen_Inlämningsuppgift
{
    //Abstract class where Crop and Animal inherit from
    internal abstract class Entity
    {
        public int Id { get; set; }
        protected string Name { get; set; }

        public Entity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual string GetDescription()
        {
            return ($"Id: {Id}, Name: {Name}");
        }
    }
}
