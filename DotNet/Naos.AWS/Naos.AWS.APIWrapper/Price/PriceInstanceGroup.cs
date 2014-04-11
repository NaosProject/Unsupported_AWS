namespace Naos.AWS.APIWrapper.Price
{
    using Newtonsoft.Json;

    public class PriceInstanceGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prices")]
        public PriceEntry Prices { get; set; }
    }
}