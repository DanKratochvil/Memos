using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Model
{
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; } = string.Empty;

        [JsonProperty("starships")]
        public List<string> Starships { get; set; } = new();
    }
}
