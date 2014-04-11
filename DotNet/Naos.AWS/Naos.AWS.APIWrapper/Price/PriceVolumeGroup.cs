namespace Naos.AWS.APIWrapper.Price
{
    using Newtonsoft.Json;

    public class PriceVolumeGroup
    {
        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("prices")]
        public PriceEntry Prices { get; set; }
    }
}