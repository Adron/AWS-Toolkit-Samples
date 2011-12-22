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
            simpleDb = CreateAmazonSimpleDBClient();
        }

        public AmazonEC2 CreateAmazonEc2Client()
        {
            return AWSClientFactory.CreateAmazonEC2Client();
        }

        public AmazonS3 CreateAmazonS3Client()
        {
            return AWSClientFactory.CreateAmazonS3Client();
        }

        public AmazonSimpleDB CreateAmazonSimpleDBClient()
        {
            return AWSClientFactory.CreateAmazonSimpleDBClient();
        }
    }

    public enum CloudFunctionality
    {
        Ec2,
        S3,
        SimpleDb
    }
}
