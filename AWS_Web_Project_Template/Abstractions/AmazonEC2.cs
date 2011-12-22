namespace AWS_Web_Project_Template.Abstractions
{
    public class AwsCentralCommand
    {
        private readonly IAmazonS3Wrapper _amazonS3;
        private readonly IAmazonEc2Wrapper _amazonEc2;

        public AwsCentralCommand(IAmazonEc2Wrapper amazonEc2)
        {
            _amazonEc2 = amazonEc2;
        }

        public AwsCentralCommand(IAmazonS3Wrapper amazonS3)
        {
            _amazonS3 = amazonS3;
        }

        public AwsCentralCommand(IAmazonEc2Wrapper amazonEc2, IAmazonS3Wrapper  amazonS3)
        {
            _amazonEc2 = amazonEc2;
            _amazonS3 = amazonS3;
        }

        public IAmazonEc2Wrapper Ec2 { get; set; }
    }

}