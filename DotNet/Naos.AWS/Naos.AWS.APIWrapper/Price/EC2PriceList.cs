namespace Naos.AWS.APIWrapper.Price
{
    using System.Linq;

    using Newtonsoft.Json;

    public class EC2PriceList
    {
        [JsonProperty("vers")]
        public double Verison { get; set; }

        [JsonProperty("config")]
        public PriceInstanceConfig Config { get; set; }

        public double GetPrice(string instanceType, string osType, string region)
        {
            var ret = double.NaN;

            var translatedRegion = Constants.GetRegionFromAvailabilityZone(region);
            foreach (var regionObj in this.Config.Regions)
            {
                if (regionObj.Region.Equals(translatedRegion))
                {
                    foreach (var type in regionObj.Types)
                    {
                        foreach (var size in type.Sizes)
                        {
                            if (size.Size.Equals(instanceType))
                            {
                                var priceGroup =
                                    size.PriceGroup.SingleOrDefault(_ => _.Name.Equals(osType));

                                if (priceGroup != null)
                                {
                                    ret = priceGroup.Prices.DollarsAsDouble; // these are by hours ON
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }

        public void MergeIn(EC2PriceList ec2PriceListToMergeIn)
        {
            foreach (var region in ec2PriceListToMergeIn.Config.Regions)
            {
                var localRegion = region;
                var matchingRegion = this.Config.Regions.Single(_ => _.Region == localRegion.Region);
                foreach (var type in localRegion.Types)
                {
                    var localType = type;
                    var matchingType = matchingRegion.Types.Single(_ => _.InstanceGenerationType == localType.InstanceGenerationType);
                    foreach (var size in localType.Sizes)
                    {
                        var localSize = size;
                        var matchingSize = matchingType.Sizes.Single(_ => _.Size == localSize.Size);
                        matchingSize.PriceGroup.AddRange(size.PriceGroup);
                    }
                }
            }
        }
    }
}
