namespace Naos.AWS.APIWrapper.Price
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PriceInstanceRegion
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("instanceTypes")]
        public List<PriceInstanceType> Types { get; set; }
    }
}