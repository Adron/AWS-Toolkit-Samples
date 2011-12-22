namespace Noctilucent
{
    public class Pyrocumulus
    {
        private readonly IAmazonEc2 _ec2;
        private readonly IAmazonS3 _s3;

        public Pyrocumulus(IAmazonEc2 ec2)
        {
            _ec2 = ec2;
        }

        public Pyrocumulus(IAmazonS3 s3)
        {
            _s3 = s3;
        }

        public Pyrocumulus(IAmazonEc2 ec2, IAmazonS3 s3)
        {
            _ec2 = ec2;
            _s3 = s3;
        }
    }
}
