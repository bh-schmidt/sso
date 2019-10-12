using FluentValidation;
using NUnit.Framework;
using SSO.Domain;
using SSO.Tests.Shared.ExtensionMethods;
using SSO.Tests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Tests.Domain.BaseModelRulesTests
{
    public class ValidateIdToInsertTests
    {
        AbstractValidator<BaseModel> idValidator;
        BaseModelRules baseModelRules = new BaseModelRules();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            idValidator = new InlineValidator<BaseModel>();

            baseModelRules.ValidateIdToInsert(idValidator.RuleFor(x => x.Id));
        }

        [Test]
        public void WillReturnSuccess()
        {
            var testModel = new TestModel() { Id = null };

            var result = idValidator.Validate(testModel);

            Assert.True(result.IsValid);
            Assert.True(result.HasNoError());
        }

        [Test]
        public void WillReturnIdMustBeEmptyBecauseIdIsEmptyString()
        {
            var testModel = new TestModel() { Id = "" };

            var result = idValidator.Validate(testModel);

            Assert.True(!result.IsValid);
            Assert.True(result.HasError("'Id' must be empty."));
        }

        [Test]
        public void WillReturnIdMustBeEmptyBecauseIdIsNotEmptyString()
        {
            var testModel = new TestModel() { Id = "123" };

            var result = idValidator.Validate(testModel);

            Assert.True(!result.IsValid);
            Assert.True(result.HasError("'Id' must be empty."));
        }
    }
}
