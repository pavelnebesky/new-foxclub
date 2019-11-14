using System;
using System.Collections.Generic;

namespace foxClub.Models
{
    public class Fox
    {

        public string Name { get; set; }
        public List<string> tricks;
        public string food;
        public string drink;
        
        public Fox(string name)
        {
            Name = name;
            tricks = new List<string>();
            food = "";
            drink = "";
        }

        public Fox()
        {
        }
    }
}
