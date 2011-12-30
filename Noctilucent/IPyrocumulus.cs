using Amazon.EC2;
using Amazon.S3;
using Amazon.SimpleDB;

namespace Noctilucent
{
    public interface IPyrocumulus
    {
        AmazonEC2 CreateAmazonEc2Client();
        AmazonS3 CreateAmazonS3Client();
        AmazonSimpleDB CreateAmazonSimpleDbClient();
    }
}