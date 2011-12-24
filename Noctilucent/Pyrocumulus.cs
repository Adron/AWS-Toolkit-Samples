using System;
using Amazon;
using Amazon.EC2;
using Amazon.S3;
using Amazon.SimpleDB;

namespace Noctilucent
{
    public class Pyrocumulus : IPyrocumulus
    {
        private AmazonEC2 ec2;
        private AmazonS3 s3;
        private AmazonSimpleDB simpleDb;

        public Pyrocumulus()
        {
            ec2 = CreateAmazonEc2Client();
            s3 = CreateAmazonS3Client();
            simpleDb = CreateAmazonSimpleDbClient();
        }

        public Pyrocumulus(CloudService service)
        {
            switch (service)
            {
                case CloudService.Ec2:
                    ec2 = CreateAmazonEc2Client(); 
                    break;
                case CloudService.S3:
                    s3 = CreateAmazonS3Client();
                    break;
                case CloudService.SimpleDb:
                    simpleDb = CreateAmazonSimpleDbClient();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("service");
            }
        }

        public AmazonEC2 CreateAmazonEc2Client()
        {
            return AWSClientFactory.CreateAmazonEC2Client();
        }

        public AmazonS3 CreateAmazonS3Client()
        {
            return AWSClientFactory.CreateAmazonS3Client();
        }

        public AmazonSimpleDB CreateAmazonSimpleDbClient()
        {
            return AWSClientFactory.CreateAmazonSimpleDBClient();
        }
    }

    public enum CloudService
    {
        Ec2,
        S3,
        SimpleDb
    }
}
