namespace Naos.AWS.APIWrapper.Price
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PriceInstanceSize
    {
        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("vCPU")]
        public string VirtualCPUs { get; set; }

        public string ECU { get; set; }

        [JsonProperty("memoryGiB")]
        public string MemoryGiB { get; set; }

        [JsonProperty("storageGB")]
        public string StorageGB { get; set; }

        [JsonProperty("valueColumns")]
        public List<PriceInstanceGroup> PriceGroup  { get; set; }
    }
}
