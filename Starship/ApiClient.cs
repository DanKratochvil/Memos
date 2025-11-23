using Newtonsoft.Json;
using Swapi.Model;

namespace Swapi
{
    public class ApiClient
    {
        static readonly HttpClient client = new();

        public async Task<List<String>> GetShipNames()
        {
            var shipNames = new List<string>();

            Planet? kashyyk = await GetPlanet("Kashyyyk");

            if (kashyyk == null)
            {
                throw new Exception("Planet Kashyyyk not found.");
            }
            if (kashyyk.Residents.Count == 0)
            {
                throw new Exception("No residents found for planet Kashyyyk.");
            }


            foreach (var residentUrl in kashyyk.Residents)
            {
                var person = await GetObjectAsync<Person>(residentUrl);
                if (person != null)
                {
                    foreach (var starshipUrl in person.Starships)
                    {
                        var starship = await GetObjectAsync<Starship>(starshipUrl);
                        if (starship != null)
                        {
                            shipNames.Add(starship.Name);
                        }
                    }
                }
            }

            return shipNames;
        }

        public async Task<T?> GetObjectAsync<T>(string objectUrl)
        {
            using var result = await client.GetAsync(objectUrl);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(response);
            }

            throw new HttpRequestException($"{result.StatusCode} {result.RequestMessage}");
        }

        private async Task<Planet?> GetPlanet(string planetName)
        {
            using var result = await client.GetAsync($"https://swapi.dev/api/planets/?search={planetName}");
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                var planets = JsonConvert.DeserializeObject<Planets>(response);
                var planet = planets?.Results.FirstOrDefault(p => p.Name == planetName);
                return planet;
            }

            throw new HttpRequestException($"{result.StatusCode} {result.RequestMessage}");
        }
    }
}
