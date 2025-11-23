using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Model
{
    public class Planets
    {
            [JsonProperty("count")]
            public int Count { get; set; }

            [JsonProperty("results")]
            public List<Planet> Results { get; set; } = new();
    }
}
