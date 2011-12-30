using AWS_MVC_Web_Application.Controllers;
using Amazon.EC2;
using NSubstitute;
using NUnit.Framework;
using Noctilucent;
using Shouldly;

namespace Web_Application_Unit_Tests.Controllers
{
    [TestFixture]
    public class AmazonWebServicesTests
    {
        AmazonWebServicesController controller;

        [TestFixtureSetUp]
        public void SetupController()
        {
            var pyrocumulus = Substitute.For<IPyrocumulus>();

            IAmazonEC2 amazonEc2 = new AmazonEC2Client();

            pyrocumulus.CreateAmazonEc2Client().Returns(amazonEc2);

            controller = new AmazonWebServicesController();
        }

        [Test]
        public void should_return_index_view()
        {
            controller.Index().ShouldNotBe(null);
        }

        [Test]
        public void should_return_index_with_appropriate_amazon_web_services()
        {

        }
    }

    public interface IAmazonEC2 : AmazonEC2
    {
    }
}
