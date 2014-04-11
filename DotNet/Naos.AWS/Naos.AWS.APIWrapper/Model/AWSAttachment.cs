namespace Naos.AWS.APIWrapper.Model
{
    public class AWSAttachment
    {
        public override string ToString()
        {
            return
                string.Format(
                    "VOLUME-ATTACHMENT--Volume Id: {0}; Instance Id: {1}; Device: {2}; Status: {3}; DeleteOnTermination: {4}",
                    this.VolumeId,
                    this.InstanceId,
                    Device,
                    Status,
                    DeleteOnTermination);
        }

        public string VolumeId { get; set; }

        public string InstanceId { get; set; }

        public string Device { get; set; }

        public string Status { get; set; }

        public bool DeleteOnTermination { get; set; }
    }
}