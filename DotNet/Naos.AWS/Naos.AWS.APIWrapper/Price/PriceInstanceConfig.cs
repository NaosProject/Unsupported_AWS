namespace Naos.AWS.APIWrapper.Price
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PriceInstanceConfig
    {
        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("valueColumns")]
        public string[] PriceInstanceSizeData { get; set; }

        [JsonProperty("currencies")]
        public string[] Currencies { get; set; }

        [JsonProperty("regions")]
        public List<PriceInstanceRegion> Regions { get; set; }
    }
}