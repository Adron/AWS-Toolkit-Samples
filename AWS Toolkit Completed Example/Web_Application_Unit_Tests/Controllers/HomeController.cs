using AWS_MVC_Web_Application.Controllers;
using NUnit.Framework;
using Shouldly;

namespace Web_Application_Unit_Tests.Controllers
{
    [TestFixture]
    public class when_home_controller_actions_are_executed
    {
        HomeController controller;

        [TestFixtureSetUp]
        public void SetupController()
        {
            controller = new HomeController();
        }

        [Test]
        public void should_return_index_view()
        {
            controller.Index().ShouldNotBe(null);
        }

      
    }
}
