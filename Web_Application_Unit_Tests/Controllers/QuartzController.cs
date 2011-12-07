using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AWS_MVC_Web_Applicaiton.Controllers;
using AWS_MVC_Web_Applicaiton.Data;
using AWS_MVC_Web_Applicaiton.Data.Repositories;
using AWS_MVC_Web_Applicaiton.Models;
using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Web_Application_Unit_Tests.Controllers
{
    [TestFixture]
    public class when_quartz_controller_actions_are_executed
    {
        QuartzController controller;
        IList<AwsEc2Status> allResults;

        [TestFixtureSetUp]
        public void SetupController()
        {
            controller = new QuartzController();
            allResults = Builder<AwsEc2Status>.CreateListOfSize(10).Build();

            var mockRepo = Substitute.For<IRepository<AwsEc2Status>>();
            
            mockRepo.All().ToList().ReturnsForAnyArgs(allResults);
        }

        [Test]
        public void should_return_index_view()
        {
            controller.Index().ShouldNotBe(null);
        }

        [Test]
        public void should_have_valid_report_data_for_view()
        {
            controller.Index();
            
        }
    }
}
