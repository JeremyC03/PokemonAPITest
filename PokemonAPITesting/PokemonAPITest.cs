using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PokemonAPITesting
{
    public class PokemonAPITest
    {
        public static void PokemonInfo()
        {
            //Create new instance of class
            HttpClient client = new HttpClient();

            //User pokemon name input
            Console.WriteLine("Please enter a pokemon name");
            var pokemonInput = Console.ReadLine();
            Console.WriteLine();

            //URL endpoint
            string pokemonURL = $"https://pokeapi.co/api/v2/pokemon/{pokemonInput.ToLower()}";
            //GET request
            string pokemonResponse = client.GetStringAsync(pokemonURL).Result;
            //Parse Object/Array
            var pokemonObject = JObject.Parse(pokemonResponse);

            //Write to console
            Console.WriteLine("Species:");
            Console.WriteLine($"{pokemonObject["species"]["name"]}");
            Console.WriteLine();

            Console.WriteLine($"ID:");
            Console.WriteLine($"{pokemonObject["id"]}");
            Console.WriteLine();

            //Foreach loop to write multiple answers if pokemon has more than 1 answer
            Console.WriteLine("Type:");
            foreach (var type in pokemonObject["types"])
            {
                Console.WriteLine($"{type["type"]["name"]}");
            }
            Console.WriteLine();

            Console.WriteLine("Height:");
            Console.WriteLine($"{pokemonObject["height"]} decimeters");
            Console.WriteLine();

            Console.WriteLine("Weight:");
            Console.WriteLine($"{pokemonObject["weight"]} hectograms");
            Console.WriteLine();

            //If statement if pokemon doesn't have answer
            Console.WriteLine("Possible held items:");

            JToken dataToken;

            if (pokemonObject.TryGetValue("held_items", out dataToken) && dataToken is JArray array && array.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var items in pokemonObject["held_items"])
                {
                    Console.WriteLine($"{items["item"]["name"]}");
                }

            }
            Console.WriteLine();

            Console.WriteLine("Possible Abilities:");
            foreach (var ability in pokemonObject["abilities"])
            {
                Console.WriteLine($"{ability["ability"]["name"]}");
            }
            Console.WriteLine();

            Console.WriteLine("Base Stats:");
            foreach (var stats in pokemonObject["stats"])
            {
                Console.WriteLine($"{stats["stat"]["name"]}: {stats["base_stat"]} ");
            }
            Console.WriteLine();

        }


    }
}
