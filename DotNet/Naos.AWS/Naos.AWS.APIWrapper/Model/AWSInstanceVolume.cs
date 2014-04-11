namespace Naos.AWS.APIWrapper.Model
{
    public class AWSInstanceVolume
    {
        public string DeviceName { get; set; }
        public string EbsVolumeId { get; set; }
        public string EbsStatus { get; set; }
        public double VolumeSizeInGB { get; set; }
        public string VolumeType { get; set; }
    }
}
