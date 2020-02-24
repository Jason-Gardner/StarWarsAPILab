using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWarsAPILab.Models
{
    public class Person
    {
        public string name { get; set; }
        public string[] species { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }

        public Person()
        {

        }

        public Person (string APIText)
        {
            Person Jedi = new Person();
            Jedi = JsonSerializer.Deserialize<Person>(APIText);
            this.name = Jedi.name;
            this.gender = Jedi.gender;
            this.homeworld = Jedi.homeworld;
            this.species = Jedi.species;
        }
    }
}
