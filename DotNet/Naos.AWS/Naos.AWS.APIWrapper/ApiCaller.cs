namespace Naos.AWS.APIWrapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Amazon;
    using Amazon.EC2;
    using Amazon.EC2.Model;

    using Naos.AWS.APIWrapper.Model;
    using Naos.AWS.APIWrapper.Price;

    using Newtonsoft.Json;

    public class ApiCaller
    {
        /// <summary>The access key.</summary>
        private readonly string m_accessKey;

        /// <summary>The secret key.</summary>
        private readonly string m_secretKey;

        /// <summary>Initializes a new instance of the <see cref="ApiCaller"/> class.</summary>
        /// <param name="accessKey">The access access key.</param>
        /// <param name="secretKey">The secrect key.</param>
        public ApiCaller(string accessKey, string secretKey)
        {
            this.m_accessKey = accessKey;
            this.m_secretKey = secretKey;
        }

        public AWSInstance GetInstanceById(string instanceId, bool includePricing = false)
        {

            var ec2 = GetEC2Client();
            var request = new DescribeInstancesRequest();
            request.InstanceIds = new List<string>(new[] { instanceId });

            Reservation reservation = null;

            try
            {
                var response = ec2.DescribeInstances(request);
                reservation = response.Reservations.SingleOrDefault();
            }
            catch (AmazonEC2Exception ex)
            {
                if (ex.Message.StartsWith("Invalid id:")) // suppress failure to find by id and just return null
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            if (reservation == null)
            {
                return null;
            }

            var instance = reservation.Instances.FirstOrDefault();
            if (instance == null)
            {
                return null;
            }

            var priceList = includePricing ? this.GetPricing() : null;
            var zones = this.GetAvailabilityZones(ec2);
            var volumes = this.GetVolumes(ec2, instance.BlockDeviceMappings.Select(_ => _.Ebs.VolumeId).ToArray());

            var ret = this.GetAWSInstanceFromInstance(instance, volumes, zones, priceList);

            return ret;
        }

        public AWSInstance[] GetInstances(bool includePricing = false)
        {
            var ret = new List<AWSInstance>();

            var ec2 = GetEC2Client();
            var request = new DescribeInstancesRequest();
            var response = ec2.DescribeInstances(request);

            var priceList = includePricing ? this.GetPricing() : null;
            var zones = this.GetAvailabilityZones(ec2);

            foreach (var reservation in response.Reservations)
            {
                var allVolumeIds = (from instance in reservation.Instances from mapping in instance.BlockDeviceMappings select mapping.Ebs.VolumeId).ToArray();
                var allVolumes = this.GetVolumes(ec2, allVolumeIds);

                var instances = reservation.Instances;
                foreach (var instance in instances)
                {
                    var instanceVolumesIds = instance.BlockDeviceMappings.Select(_ => _.Ebs.VolumeId);
                    var instanceVolumes = allVolumes.Where(_ => instanceVolumesIds.Contains(_.VolumeId)).ToArray();
                    var awsInstance = this.GetAWSInstanceFromInstance(instance, instanceVolumes, zones, priceList);
                    ret.Add(awsInstance);
                }
            }

            return ret.ToArray();
        }

        public AWSAvailabilityZone[] GetAvailabilityZones(IAmazonEC2 ec2Client = null)
        {
            var ret = new List<AWSAvailabilityZone>();

            var ec2 = ec2Client ?? GetEC2Client(); // might be passed in by instances calls...
            var request = new DescribeAvailabilityZonesRequest();
            var response = ec2.DescribeAvailabilityZones(request);

            foreach (var zone in response.AvailabilityZones)
            {
                var awsZone = new AWSAvailabilityZone() { Region = zone.RegionName, Name = zone.ZoneName, };
                ret.Add(awsZone);
            }

            return ret.ToArray();
        }

        public AWSVolume[] GetVolumes(IAmazonEC2 ec2Client = null, string[] volumeIds = null)
        {
            var ret = new List<AWSVolume>();

            var ec2 = ec2Client ?? GetEC2Client(); // might be passed in by instances calls...
            var request = new DescribeVolumesRequest();
            if (volumeIds != null && volumeIds.Length > 0)
            {
                request.VolumeIds = volumeIds.ToList();
            }

            var response = ec2.DescribeVolumes(request);

            foreach (var volume in response.Volumes)
            {
                var awsAttachments = new List<AWSAttachment>();
                foreach (var attachment in volume.Attachments)
                {
                    awsAttachments.Add(new AWSAttachment()
                        {
                            VolumeId = attachment.VolumeId,
                            InstanceId = attachment.InstanceId,
                            Device = attachment.Device,
                            Status = attachment.State.Value,
                            DeleteOnTermination = attachment.DeleteOnTermination,
                        });
                }

                var awsTags = new List<AWSTag>();
                foreach (var tag in volume.Tags)
                {
                    awsTags.Add(new AWSTag()
                        {
                            Key = tag.Key,
                            Value = tag.Value,
                        });
                }

                ret.Add(new AWSVolume()
                    {
                        VolumeId = volume.VolumeId,
                        VolumeType = volume.VolumeType,
                        SnapshotId = volume.SnapshotId,
                        Size = volume.Size,
                        Status = volume.State.Value,
                        IOPS = volume.Iops.ToString(),
                        Attachemnts = awsAttachments.ToArray(),
                        Tags = awsTags.ToArray(),
                    });
            }

            return ret.ToArray();
        }

        public AWSImage GetImageById(string imageId)
        {
            var ec2 = GetEC2Client();

            var req = new DescribeImageAttributeRequest()
                          {
                              ImageId = imageId,
                              Attribute = new ImageAttributeName("description")
                          };
            var resp = ec2.DescribeImageAttribute(req);


            var request = new DescribeImagesRequest();
            //request.ImageIds = new List<string>(new[] { imageId });
            //request.ExecutableUsers = new List<string>(new[] { "all" });
            request.Filters =
                new List<Filter>(
                    new[] { new Filter() { Name = "image-id", Values = new List<string>(new[] { imageId }) } });

            var response = ec2.DescribeImages(request);

            var image = response.Images.SingleOrDefault();
            if (image == null)
            {
                return null;
            }

            var awsImage = GetAwsImageFromImage(image);
            return awsImage;
        }

        public AWSImage[] GetImages()
        {
            var ret = new List<AWSImage>();

            var ec2 = GetEC2Client();
            var request = new DescribeImagesRequest();
            var response = ec2.DescribeImages(request);

            foreach (var image in response.Images)
            {
                var awsImage = GetAwsImageFromImage(image);
                ret.Add(awsImage);
            }

            return ret.ToArray();
        }

        public void StopInstance(string instanceId)
        {
            var ec2 = GetEC2Client();
            var req = new StopInstancesRequest() { Force = true, InstanceIds = new List<string>(new[] { instanceId }) };
            ec2.StopInstances(req);
        }

        public void StartInstance(string instanceId)
        {
            var ec2 = GetEC2Client();
            var req = new StartInstancesRequest() { InstanceIds = new List<string>(new[] { instanceId }) };
            ec2.StartInstances(req);
        }

        private AWSInstance GetAWSInstanceFromInstance(Instance instance, AWSVolume[] volumes, AWSAvailabilityZone[] zones, Pricing pricing)
        {
            var tags = new List<AWSTag>();
            string name = null;
            if (instance.Tags != null)
            {
                foreach (var tag in instance.Tags)
                {
                    if (tag.Key == "Name" && tag.Value != null)
                    {
                        name = tag.Value;
                    }
                    else
                    {
                        tags.Add(new AWSTag { Key = tag.Key, Value = tag.Value });
                    }
                }
            }

            var awsInstanceVolumes = new List<AWSInstanceVolume>();
            foreach (var mapping in instance.BlockDeviceMappings)
            {
                var volume = volumes.SingleOrDefault(_ => _.VolumeId == mapping.Ebs.VolumeId);
                var awsInstanceVolume = new AWSInstanceVolume()
                                    {
                                        DeviceName = mapping.DeviceName,
                                        EbsVolumeId = mapping.Ebs.VolumeId,
                                        EbsStatus = mapping.Ebs.Status.Value,
                                        VolumeSizeInGB = volume != null ? volume.Size : double.NaN,
                                        VolumeType = volume != null ? volume.VolumeType : null,
                                    };
                awsInstanceVolumes.Add(awsInstanceVolume);
            }

            var instanceType = instance.InstanceType.Value;
            var availabilityZone = instance.Placement.AvailabilityZone;
            var region = zones.Single(_ => _.Name.Equals(availabilityZone)).Region;
            var osTypeTag = tags.SingleOrDefault(_ => _.Key == Constants.OSTypes.TAG_NAME);
            var osType = osTypeTag != null ? osTypeTag.Value : Constants.OSTypes.WINDOWS_BASE; // defaulting to windows base b/c that's the common case

            var pricePerHour = pricing != null ? pricing.EC2Pricing.GetPrice(instanceType, osType, region) : double.NaN;
            var pricePerMonth = pricing != null ? pricing.EBSPricing.GetPrice(region, awsInstanceVolumes) : double.NaN;

            var ret = new AWSInstance()
                          {
                              InstanceId = instance.InstanceId,
                              ImageId = instance.ImageId,
                              AvailabilityZone = availabilityZone,
                              Region = region,
                              Platform = AWSInstance.GetPlatformFromString(instance.Platform == null ? null : instance.Platform.Value),
                              OSType = osTypeTag != null ? osTypeTag.Value : "Unknown - costed as Windows Base",
                              Volumes = awsInstanceVolumes.ToArray(),
                              Name = name,
                              IpAddress = instance.PublicIpAddress,
                              PrivateIpAddress = instance.PrivateIpAddress,
                              InstanceState = AWSInstance.GetStateFromString(instance.State.Name),
                              InstanceType = instanceType,
                              PricePerHourRunning = pricePerHour,
                              PricePerMonthStorage = pricePerMonth,
                              Tags = tags.ToArray(),
                          };

            return ret;
        }

        private static AWSImage GetAwsImageFromImage(Image image)
        {
            var awsImage = new AWSImage() { ImageId = image.ImageId, Name = image.Name, };
            return awsImage;
        }

        private IAmazonEC2 GetEC2Client()
        {
            var ec2 = AWSClientFactory.CreateAmazonEC2Client(this.m_accessKey, this.m_secretKey, RegionEndpoint.USEast1);
            return ec2;
        }

        private Pricing GetPricing()
        {
            var rawEbs = WebTools.ExecuteGet(Constants.Urls.V2.EBS_URL);
            rawEbs = rawEbs.Substring(9, rawEbs.Length - 10); // wrapped by callback()...
            var ebs = JsonConvert.DeserializeObject<EBSPriceList>(rawEbs);

            EC2PriceList ec2 = null;
            var allOnDemand = new[]
                {
                    Constants.Urls.V2.INSTANCES_ON_DEMAND_LINUX_URL,
                    Constants.Urls.V2.INSTANCES_ON_DEMAND_RHEL_URL,
                    Constants.Urls.V2.INSTANCES_ON_DEMAND_SLES_URL,
                    Constants.Urls.V2.INSTANCES_ON_DEMAND_WINDOWS_URL,
                    Constants.Urls.V2.INSTANCES_ON_DEMAND_WINSQL_URL,
                    Constants.Urls.V2.INSTANCES_ON_DEMAND_WINSQLWEB_URL
                };

            foreach (var odUrl in allOnDemand)
            {
                var rawEc2 = WebTools.ExecuteGet(odUrl);
                rawEc2 = rawEc2.Substring(9, rawEc2.Length - 10); // wrapped by callback()...
                if (ec2 == null)
                {
                    ec2 = JsonConvert.DeserializeObject<EC2PriceList>(rawEc2);
                }
                else
                {
                    var addToEc2 = JsonConvert.DeserializeObject<EC2PriceList>(rawEc2);
                    ec2.MergeIn(addToEc2);
                }
            }

            return new Pricing { EC2Pricing = ec2, EBSPricing = ebs, };
        }
    }
}
