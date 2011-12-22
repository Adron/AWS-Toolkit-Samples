using System;
using System.Collections.Generic;
using System.Linq;
using AWS_MVC_Web_Application.Controllers;
using AWS_MVC_Web_Application.Data;
using AWS_MVC_Web_Application.Models;
using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Web_Application_Unit_Tests.Fakes;

namespace Web_Application_Unit_Tests.Controllers
{
    [TestFixture]
    public class when_nice_little_form_controller_actions_are_executed
    {
        NiceLittleFormController controller;
        private const int totalRows = 10;
        IList<NiceLittleForm> resultsRows;
        IRepository<NiceLittleForm> repository;
        private NiceLittleForm addDeleteNewLittleForm;
        private Guid guid = Guid.NewGuid();

        [TestFixtureSetUp]
        public void SetupController()
        {
            resultsRows = Builder<NiceLittleForm>.CreateListOfSize(totalRows).Build();

            repository = Substitute.For<IRepository<NiceLittleForm>>();
            repository.All().Returns(resultsRows.AsQueryable());

            RepositorySession.DefaultContainerType = typeof(ObjectContextFake);

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

        [Test]
        public void should_return_view_with_NiceLittleForm_model_entries()
        {
            var result = controller.Index().Model;
            var list = (IEnumerable<NiceLittleForm>)result;
            list.ToList().Count.ShouldBe(totalRows);
        }

        [Test]
        public void should_show_empty_create_view_result()
        {
            controller.Create().ShouldNotBe(null);
        }

        [Test]
        public void should_add_the_NiceLittleForm_to_the_repository()
        {
            var addDeleteNewLittleForm = new NiceLittleForm() {Id = guid};

            controller.Create(addDeleteNewLittleForm);
           
            repository.Received().Add(addDeleteNewLittleForm);
        }

        [Test]
        public void should_show_NiceLittleForm_delete_confirmation_page()
        {
            addDeleteNewLittleForm = new NiceLittleForm() { Id = guid };
            resultsRows.Add(addDeleteNewLittleForm);

            controller.Delete(guid).ShouldNotBe(null);

            resultsRows.Remove(addDeleteNewLittleForm);
        }

        [Test]
        public void should_remove_the_NiceLittleForm_with_the_repository()
        {
            addDeleteNewLittleForm = new NiceLittleForm() { Id = guid };
            resultsRows.Add(addDeleteNewLittleForm);

            controller.DeleteConfirmed(guid);
            repository.Received().Delete(addDeleteNewLittleForm);

            resultsRows.Remove(addDeleteNewLittleForm);
        }
    }
}
