namespace Naos.AWS.APIWrapper.Price
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PriceVolumeRegion
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("types")]
        public List<PriceVolumeType> Types { get; set; }
    }
}