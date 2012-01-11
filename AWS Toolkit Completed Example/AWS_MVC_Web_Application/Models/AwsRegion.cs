using System.Collections.Generic;

namespace AWS_MVC_Web_Application.Models
{
    public class AwsRegion
    {
        public List<Ec2Instance> Instances { get; set; }
    }
}