using NUnit.Framework;
using ThisIsOurAwesomeApplication.Controllers;
using Shouldly;


namespace TDD_Testing
{
    [TestFixture]
    public class when_testing_web_application
    {
        private HomeController controller;

        [TestFixtureSetUp]
        public void with_these_characteristics()
        {
            controller = new HomeController();
        }

        [Test]
        public void should_have_a_home_controller()
        {
            controller.ShouldNotBe(null);
        }

        [Test]
        public void should_have_a_home_page()
        {
            controller.Index().ShouldNotBe(null);
        }

    }
}
