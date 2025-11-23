using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swapi.Model
{
    public class Starship
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<string> Pilots { get; set; } = new();
    }
}
