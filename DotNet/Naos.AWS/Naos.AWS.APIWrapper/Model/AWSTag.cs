namespace Naos.AWS.APIWrapper.Model
{
    public class AWSTag
    {
        public override string ToString()
        {
            return
                string.Format(
                    "TAG--Key: {0}; Value: {1}",
                    Key,
                    Value);
        }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}