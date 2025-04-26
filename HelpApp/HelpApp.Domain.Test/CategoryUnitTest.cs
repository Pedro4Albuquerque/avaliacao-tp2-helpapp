using FluentAssertions;
using HelpApp.Domain.Entities;
using HelpApp.Domain.Validation;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Should create a valid category with id and name")]
        public void CreateCategory_WithValidParameters_ShouldCreateObject()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Should throw excerption when creating category with negative Id")]
        public void CreateCategory_WithNegativeId_ShouldThrowException()
        {
            Action action = () => new Category(-1, "categiria de nome");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Theory(DisplayName = "Should throw excerption when creating category with null or empty name")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateCategory_WithNameEmptyorNull_ShouldThrowException(string? name)
        {
            Action action = () => new Category(1, name!);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Theory(DisplayName = "Should throw excerption when creating category with name shoter 3 caracters")]
        [InlineData("n")]
        [InlineData("am")]
        public void CreateCategory_WithShortName_ShouldThrowException(string name)
        {
            Action action = () => new Category(1, name!);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }
        #endregion
    }
}
