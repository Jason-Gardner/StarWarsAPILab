using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWarsAPILab.Models
{
    public class StarWarsDAL
    {
        public async Task<string> GetData(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{url}"))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<Person> GetPerson(int i)
        {
            var person = await GetData("https://swapi.co/api/people/" + i + "/");
            Person Jedi = new Person(person);
            Jedi.homeworld = await GetPlanet(Jedi.homeworld);
            return Jedi;
        }

        public async Task<string> GetPlanet(string url)
        {
            var planet = await GetData(url);
            Planet homePlanet = JsonSerializer.Deserialize<Planet>(planet);
            return homePlanet.name;
        }
    }
}
