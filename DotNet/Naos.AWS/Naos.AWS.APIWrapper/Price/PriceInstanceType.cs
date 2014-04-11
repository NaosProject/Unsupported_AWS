namespace Naos.AWS.APIWrapper.Price
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PriceInstanceType
    {
        [JsonProperty("type")]
        public string InstanceGenerationType { get; set; }

        [JsonProperty("sizes")]
        public List<PriceInstanceSize> Sizes { get; set; } 
    }
}