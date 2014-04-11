namespace Naos.AWS.APIWrapper.Price
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Amazon.Runtime;

    using Naos.AWS.APIWrapper.Model;

    using Newtonsoft.Json;

    public class EBSPriceList
    {
        [JsonProperty("vers")]
        public double Verison { get; set; }

        [JsonProperty("config")]
        public PriceVolumeConfig Config { get; set; }

        public double GetPrice(string region, List<AWSInstanceVolume> volumes)
        {
            var ret = double.NaN;

            var translatedRegion = Constants.GetRegionFromAvailabilityZone(region);
            foreach (var regionObj in this.Config.Regions)
            {
                if (regionObj.Region.Equals(translatedRegion))
                {
                    foreach (var volume in volumes)
                    {
                        if (!double.IsNaN(volume.VolumeSizeInGB))
                        {
                            var volumeType = Constants.GetTranslatedVolumeType(volume.VolumeType);

                            var typePrice = regionObj.Types.SingleOrDefault(_ =>
                                {
                                    return _.Name == volumeType;
                                });
                            if (typePrice != null)
                            {
                                var priceGroup =
                                    typePrice.PriceGroup.SingleOrDefault(
                                        _ => _.Rate.Equals(Constants.PER_GB_PER_MONTH_PROVISIONED_STORAGE));
                                if (priceGroup != null)
                                {
                                    if (Double.IsNaN(ret))
                                    {
                                        ret = 0; //need to set to do math
                                    }

                                    var pricePerGb = priceGroup.Prices.DollarsAsDouble; // these are by month

                                    ret += (pricePerGb * volume.VolumeSizeInGB);
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }
    }
}