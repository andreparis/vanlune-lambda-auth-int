
using Auth.Int.Domain.Entities.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth.Int.Domain.Entities
{
    public class PolicyDocument
    {
        [JsonProperty(PropertyName = "Version")]
        public string Version { get; set; }
        [JsonProperty(PropertyName = "Statement")]
        public IEnumerable<Statement> Statement { get; set; }

    }
}
