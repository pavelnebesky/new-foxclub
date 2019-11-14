using System;
using System.Collections.Generic;
using foxClub.Models;

namespace foxClub.Services
{
    public class FoxServices
    {

        public List<Fox> foxes;
        public List<string> foodTypes;
        public List<string> drinks;
        public List<string> skills;

        public FoxServices()
        {
            foxes = new List<Fox>();
            foodTypes = new List<string>() { "pizza", "lasagne", "bread", "svickova", "burger", "chocolate", "sugar" };
            drinks = new List<string>() { "watter", "lemonade", "tea", "cofee", "juice", "beer", "milk" };
            skills = new List<string>() { "programming Java", "programming C Sharp", "write HTML", "make Tea", "make Cofee", "Sleep", "Sing" };
        }

        public Fox FindFoxByName (string name)
        {
            return foxes.Find(f => f.Name == name);
        }

    }
}
