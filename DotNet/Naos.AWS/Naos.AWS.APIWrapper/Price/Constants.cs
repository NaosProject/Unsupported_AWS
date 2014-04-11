namespace Naos.AWS.APIWrapper.Price
{
    using System;

    public static class Constants
    {
        public const string PER_GB_PER_MONTH_PROVISIONED_STORAGE = "perGBmoProvStorage";

        public static class OSTypes
        {
            public const string TAG_NAME = "OSType";

            public const string LINUX_FREE = "linux";

            public const string LINUX_RED_HAT = "rhel";

            public const string LINUX_SUSE = "sles";

            public const string WINDOWS_BASE = "mswin";

            public const string WINDOWS_SQL = "mswinSQL";

            public const string WINDOWS_SQL_WEB = "mswinSQLWeb";

        }

        public static class Urls
        {
            //http://stackoverflow.com/questions/7334035/get-ec2-pricing-programmatically

            public static class V1
            {
                public const string INSTANCES_ON_DEMAND_LINUX_URL =
                    "http://aws.amazon.com/ec2/pricing/json/linux-od.json";

                public const string INSTANCES_ON_DEMAND_RHEL_URL = "http://aws.amazon.com/ec2/pricing/json/rhel-od.json";

                public const string INSTANCES_ON_DEMAND_SLES_URL = "http://aws.amazon.com/ec2/pricing/json/sles-od.json";

                public const string INSTANCES_ON_DEMAND_WINDOWS_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswin-od.json";

                public const string INSTANCES_ON_DEMAND_WINSQL_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQL-od.json";

                public const string INSTANCES_ON_DEMAND_WINSQLWEB_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQLWeb-od.json";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_LINUX_URL =
                    "http://aws.amazon.com/ec2/pricing/json/linux-ri-light.json";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_RHEL_URL =
                    "http://aws.amazon.com/ec2/pricing/json/rhel-ri-light.json";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_SLES_URL =
                    "http://aws.amazon.com/ec2/pricing/json/sles-ri-light.json";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_WINDOWS_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswin-ri-light.json";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_WINSQL_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQL-ri-light.json";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_WINSQLWEB_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQLWeb-ri-light.json";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_LINUX_URL =
                    "http://aws.amazon.com/ec2/pricing/json/linux-ri-medium.json";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_RHEL_URL =
                    "http://aws.amazon.com/ec2/pricing/json/rhel-ri-medium.json";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_SLES_URL =
                    "http://aws.amazon.com/ec2/pricing/json/sles-ri-medium.json";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_WINDOWS_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswin-ri-medium.json";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_WINSQL_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQL-ri-medium.json";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_WINSQLWEB_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQLWeb-ri-medium.json";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_LINUX_URL =
                    "http://aws.amazon.com/ec2/pricing/json/linux-ri-heavy.json";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_RHEL_URL =
                    "http://aws.amazon.com/ec2/pricing/json/rhel-ri-heavy.json";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_SLES_URL =
                    "http://aws.amazon.com/ec2/pricing/json/sles-ri-heavy.json";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_WINDOWS_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswin-ri-heavy.json";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_WINSQL_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQL-ri-heavy.json";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_WINSQLWEB_URL =
                    "http://aws.amazon.com/ec2/pricing/json/mswinSQLWeb-ri-heavy.json";

                public const string EBS_URL = 
                    "http://a0.awsstatic.com/pricing/1/ebs/pricing-ebs.min.js";
            }

            public static class V2
            {
                public const string INSTANCES_ON_DEMAND_LINUX_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/linux-od.js";

                public const string INSTANCES_ON_DEMAND_RHEL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/rhel-od.js";

                public const string INSTANCES_ON_DEMAND_SLES_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/sles-od.js";

                public const string INSTANCES_ON_DEMAND_WINDOWS_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswin-od.js";

                public const string INSTANCES_ON_DEMAND_WINSQL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQL-od.js";

                public const string INSTANCES_ON_DEMAND_WINSQLWEB_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQLWeb-od.js";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_LINUX_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/linux-ri-light.js";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_RHEL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/rhel-ri-light.js";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_SLES_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/sles-ri-light.js";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_WINDOWS_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswin-ri-light.js";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_WINSQL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQL-ri-light.js";

                public const string INSTANCES_RESERVED_LIGHT_UTILIZATION_WINSQLWEB_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQLWeb-ri-light.js";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_LINUX_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/linux-ri-medium.js";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_RHEL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/rhel-ri-medium.js";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_SLES_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/sles-ri-medium.js";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_WINDOWS_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswin-ri-medium.js";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_WINSQL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQL-ri-medium.js";

                public const string INSTANCES_RESERVED_MEDIUM_UTILIZATION_WINSQLWEB_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQLWeb-ri-medium.js";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_LINUX_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/linux-ri-heavy.js";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_RHEL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/rhel-ri-heavy.js";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_SLES_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/sles-ri-heavy.js";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_WINDOWS_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswin-ri-heavy.js";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_WINSQL_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQL-ri-heavy.js";

                public const string INSTANCES_RESERVED_HEAVY_UTILIZATION_WINSQLWEB_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/mswinSQLWeb-ri-heavy.js";

                public const string EBS_URL = "http://aws-assets-pricing-prod.s3.amazonaws.com/pricing/ec2/pricing-ebs.js";
            }
        }

        public static string GetRegionFromAvailabilityZone(string availabilityZone)
        {
            // necessary b/c prices have seemingly old regions...
            switch (availabilityZone)
            {
                case "us-east-1":
                    return "us-east";
                case "us-west-2":
                    return "us-west-2";
                case "us-west-1":
                    return "us-west";
                case "eu-west-1":
                    return "eu-ireland";
                case "ap-southeast-1":
                    return "apac-sin";
                case "ap-northeast-1":
                    return "apac-tokyo";
                case "sa-east-1":
                    return "sa-east-1";
                default:
                    throw new ArgumentException("Unrecognized Availability Zone: " + availabilityZone);
            }
        }

        public static string GetTranslatedVolumeType(string volumeType)
        {
            switch (volumeType)
            {
                case "standard":
                    return "ebsVols";
                case "io1":
                    return "perMMIOreq";
                default:
                    throw new ArgumentException("Unrecognized Volume Type: " + volumeType);
            }
        }
    }
}

