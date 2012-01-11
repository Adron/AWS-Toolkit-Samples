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
        private const int TotalRows = 10;
        IList<NiceLittleForm> resultsRows;
        IRepository<NiceLittleForm> repository;
        private NiceLittleForm _addDeleteNewLittleForm;
        private readonly Guid guid = Guid.NewGuid();
        private IRepositorySession session;

        [TestFixtureSetUp]
        public void SetupController()
        {
            resultsRows = Builder<NiceLittleForm>.CreateListOfSize(TotalRows).Build();

            repository = Substitute.For<IRepository<NiceLittleForm>>();
            session = Substitute.For<IRepositorySession>();
            repository.All().Returns(resultsRows.AsQueryable());

            RepositorySession.DefaultContainerType = typeof(FakeObjectContext);

            controller = new NiceLittleFormController(repository, session);
        }

        [Test]
        public void should_be_mocked_out_correctly()
        {
            var result = repository.All();
            result.Count().ShouldBe(TotalRows);
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
            list.ToList().Count.ShouldBe(TotalRows);
        }

        [Test]
        public void should_show_empty_create_view_result()
        {
            controller.Create().ShouldNotBe(null);
        }

        [Test]
        public void should_create_the_NiceLittleForm_to_the_repository()
        {
            _addDeleteNewLittleForm = new NiceLittleForm {Id = guid};

            controller.Create(_addDeleteNewLittleForm);

            repository.Received().Add(_addDeleteNewLittleForm);
        }

        [Test]
        public void should_show_NiceLittleForm_delete_confirmation_page()
        {
            _addDeleteNewLittleForm = new NiceLittleForm() { Id = guid };
            resultsRows.Add(_addDeleteNewLittleForm);

            controller.Delete(guid).ShouldNotBe(null);

            resultsRows.Remove(_addDeleteNewLittleForm);
        }

        [Test]
        public void should_remove_the_NiceLittleForm_with_the_repository()
        {
            _addDeleteNewLittleForm = new NiceLittleForm() { Id = guid };
            resultsRows.Add(_addDeleteNewLittleForm);

            controller.DeleteConfirmed(guid);
            repository.Received().Delete(_addDeleteNewLittleForm);

            resultsRows.Remove(_addDeleteNewLittleForm);
        }

        [Test]
        public void should_show_NiceLittleForm_details()
        {
            _addDeleteNewLittleForm = new NiceLittleForm() { Id = guid };
            resultsRows.Add(_addDeleteNewLittleForm);

            controller.Details(guid).ShouldNotBe(null);

            resultsRows.Remove(_addDeleteNewLittleForm);
        }
    }
}
