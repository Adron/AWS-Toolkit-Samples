using AWS_MVC_Web_Application.Controllers;
using Amazon.EC2;
using NSubstitute;
using NUnit.Framework;
using Noctilucent;
using Shouldly;

namespace Web_Application_Unit_Tests.Controllers
{
    [TestFixture]
   public class when_amazon_web_services_controller_actions_are_executed
    {
        private AmazonWebServicesController controller;

        [TestFixtureSetUp]
        public void when_utilizing_cloudy_services()
        {
            var pyrocumulus = Substitute.For<IPyrocumulus>();

            var ec2Fake = Substitute.For<AmazonEC2>();
           
            pyrocumulus.CreateAmazonEc2Client().Returns(ec2Fake);

            controller = new AmazonWebServicesController(pyrocumulus);
        }

        [Test]
        public void should_have_the_cloudy_bits()
        {
            controller.Index().ShouldNotBe(null);
        }

        [Test]
        public void should_have_ec2_information_regions_zones_data()
        {
            controller.Regions().ShouldNotBe(null);
        }

        [Test]
        public void should_have_ec2_information_instance_name_data()
        {
            const string region = "SomewhereRegion";
            controller.Instances(region).ShouldNotBe(null);
        }
    }
}
