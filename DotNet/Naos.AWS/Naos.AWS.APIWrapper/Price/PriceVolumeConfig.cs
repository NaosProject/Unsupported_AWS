namespace Naos.AWS.APIWrapper.Price
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PriceVolumeConfig
    {
        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("currencies")]
        public string[] Currencies { get; set; }

        [JsonProperty("regions")]
        public List<PriceVolumeRegion> Regions { get; set; }
    }
}
