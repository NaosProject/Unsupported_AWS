namespace Naos.AWS.APIWrapper.Model
{
    public class AWSInstance
    {
        public static AWSInstanceState GetStateFromString(string state)
        {
            if ("running".Equals(state))
            {
                return AWSInstanceState.Running;
            }
            else if ("stopped".Equals(state))
            {
                return AWSInstanceState.Stopped;
            }
            else
            {
                return AWSInstanceState.Unknown;
            }
        }

        public static AWSPlatformType GetPlatformFromString(string platform)
        {
            if ("Windows".Equals(platform))
            {
                return AWSPlatformType.Windows;
            }
            else
            {
                return AWSPlatformType.Unknown;
            }
        }

        public string InstanceId { get; set; }

        public string ImageId { get; set; }

        public string AvailabilityZone { get; set; }

        public AWSPlatformType Platform { get; set; }

        public string Name { get; set; }

        public string IpAddress { get; set; }

        public AWSInstanceState InstanceState { get; set; }

        public string PrivateIpAddress { get; set; }

        public AWSTag[] Tags { get; set; }

        public AWSInstanceVolume[] Volumes { get; set; }

        public string InstanceType { get; set; }

        public double PricePerHourRunning { get; set; }

        public double PricePerMonthStorage { get; set; }

        public string Region { get; set; }

        public string OSType { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "INSTANCE--Instance Id: {0}; Name: {1}; Ip Address: {2}; Private Ip Address: {3}; State: {4}; $/hr(running): {5}; $/month(storage): {6}; ImageId: {7}; Platform: {8}; OSType: {9}; Tag Count: {10}",
                    this.InstanceId,
                    this.Name,
                    this.IpAddress,
                    this.PrivateIpAddress,
                    this.InstanceState,
                    this.PricePerHourRunning,
                    this.PricePerMonthStorage,
                    this.ImageId,
                    this.Platform,
                    this.OSType,
                    Tags.Length);
        }
    }
}