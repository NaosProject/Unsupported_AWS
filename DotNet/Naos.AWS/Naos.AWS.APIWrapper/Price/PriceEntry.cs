namespace Naos.AWS.APIWrapper.Price
{
    using Newtonsoft.Json;

    public class PriceEntry
    {
        [JsonProperty("USD")]
        public string Dollars { get; set; }

        public double DollarsAsDouble
        {
            get
            {
                // this is because Amazon is kind of hacky and you will totally see things like "N/A" as the value of Dollars
                double ret;
                var success = double.TryParse(this.Dollars, out ret);
                return success ? ret : double.NaN;
            }
        }
    }
}