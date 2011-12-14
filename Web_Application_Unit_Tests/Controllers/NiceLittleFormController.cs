using System.Collections.Generic;
using System.Linq;
using AWS_MVC_Web_Application.Controllers;
using AWS_MVC_Web_Application.Data;
using AWS_MVC_Web_Application.Models;
using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Web_Application_Unit_Tests.Controllers
{
    [TestFixture]
    public class when_nice_little_form_controller_actions_are_executed
    {
        NiceLittleFormController controller;
        private const int totalRows = 10;
        IList<NiceLittleForm> resultsRows;
        IRepository<NiceLittleForm> repository;

        [TestFixtureSetUp]
        public void SetupController()
        {
            resultsRows = Builder<NiceLittleForm>.CreateListOfSize(totalRows).Build();
            repository = Substitute.For<IRepository<NiceLittleForm>>();
            repository.All().Returns(resultsRows.AsQueryable());

            RepositorySession.DefaultContainerType = typeof(FakeObjectContext);

            controller = new NiceLittleFormController(repository);
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
    }
}
