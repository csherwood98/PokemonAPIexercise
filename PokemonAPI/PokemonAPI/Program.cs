using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace PokemonAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string pokemonBaseURL = "https://pokeapi.co/api/v2/pokemon/";
            var client = new HttpClient();
            for (int i = 1; i < 152; i++)
            {
                string pokemonURL = pokemonBaseURL + i;

                var pokemonResponse = client.GetStringAsync(pokemonURL).Result;

                var pokemonJObject = JObject.Parse(pokemonResponse);
                var pokemonName = (string)pokemonJObject["name"];

                IList<string> allMoves = pokemonJObject["moves"].Select(i => (string)i["move"]["name"]).ToList();

                Console.WriteLine("Pokemon {0} is named {1}", i, pokemonName);
                foreach(string move in allMoves)
                {
                    Console.WriteLine($"{pokemonName} can learn {move}");
                }
                Console.ReadKey();
            }
        }
    }
}
