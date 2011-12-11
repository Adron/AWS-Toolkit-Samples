﻿using System.Collections.Generic;
using System.Linq;
using AWS_MVC_Web_Applicaiton.Controllers;
using AWS_MVC_Web_Applicaiton.Data;
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
        int totalRows = 10;
        IList<AwsEc2Status> resultsRows;
        IRepository<AwsEc2Status> repository;

        [TestFixtureSetUp]
        public void SetupController()
        {
            resultsRows = Builder<AwsEc2Status>.CreateListOfSize(totalRows).Build();
            repository = Substitute.For<IRepository<AwsEc2Status>>();
            repository.All().Returns(resultsRows.AsQueryable());

            RepositorySession.DefaultContainerType = typeof(FakeObjectContext);

            controller = new QuartzController(repository);
        }

        [Test]
        public void should_be_mocked_out_correctly()
        {
            var result = repository.All();
            result.Count().ShouldBe(totalRows);
        }

        [Test]
        public void should_return_appropriate_index_view()
        {
            controller.ShouldNotBe(null);
        }

        [Test]
        public void should_return_view_with_model_results()
        {
            var result = controller.Index().Model;
            var list = (IEnumerable<AwsEc2Status>)result;
            list.ToList().Count.ShouldBe(10);
        }
    }
}