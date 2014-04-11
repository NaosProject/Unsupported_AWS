namespace Naos.AWS.APIWrapper.Model
{
    public class AWSVolume
    {
        public override string ToString()
        {
            var attachmentsString = string.Empty;
            foreach (var attachment in Attachemnts)
            {
                attachmentsString += attachment + ", ";
            }

            if (attachmentsString.Length > 2)
            {
                attachmentsString = attachmentsString.Substring(0, attachmentsString.Length - 2);
            }

            var tagsString = string.Empty;
            foreach (var tag in Tags)
            {
                tagsString += tag + ", ";
            }

            if (tagsString.Length > 2)
            {
                tagsString = tagsString.Substring(0, tagsString.Length - 2);
            }
            
            return
                string.Format(
                    "EBS-VOLUME--Volume Id: {0}; Volume Type: {1}; Snapshot Id: {2}; Size: {3}; Status: {4}; IOPS: {5}; Attachment: [{6}]; Tag: [{7}]",
                    this.VolumeId,
                    VolumeType,
                    this.SnapshotId,
                    Size,
                    Status,
                    IOPS,
                    attachmentsString,
                    tagsString);
        }

        public string VolumeId { get; set; }

        public string VolumeType { get; set; }

        public string SnapshotId { get; set; }

        public double Size { get; set; }

        public string Status { get; set; }

        public string IOPS { get; set; }

        public AWSAttachment[] Attachemnts { get; set; }

        public AWSTag[] Tags { get; set; }
    }
}