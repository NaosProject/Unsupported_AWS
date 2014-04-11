namespace Naos.AWS.APIWrapper.Model
{
    public class AWSImage
    {
        public string ImageId { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("IMAGE--Image Id: {0}; Name: {1}", this.ImageId, this.Name);
        }
    }
}
