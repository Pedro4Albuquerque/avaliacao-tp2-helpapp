using FluentAssertions;
using HelpApp.Domain.Entities;
using HelpApp.Domain.Validation;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Should create a valid product with name, description,price,stock and image")]
        public void CreateProduct_WithValidParameters_SholdCreateObject()
        {
            Action action = () => new Product("product Name", "Description", 99.90m, 10, "/img/productImagem.jpg");

            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Should create a valid product with id and fields")]
        public void CreateProduct_WithIdandValidParameters_SholdCreateObject()
        {
            Action action = () => new Product("product Name", "Description", 100.00m, 9, "/img/productImagem.jpg");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion
        #region Testes Negativos
        [Fact(DisplayName = "Create Product With ID Negative")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "product Name", "Description", 100.00m, 9, "/img/productImagem.jpg");


            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Update Invalid Id value");
        }

        [Theory(DisplayName = "Shold throw exception when product has null or empty name")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateProduvt_withNullorEmptyName_ShouldThrowException(string? name)
        {
            Action action = () => new Product(name!, "Description", 100.00m, 9, "/img/productImagem.jpg");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99,
                "product image");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Theory(DisplayName = "Create Product With Null or Empty URL Image")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateProduvt_withNullorEmptyDescription_ShouldThrowException(string? description)
        {
            Action action = () => new Product("Product", description!, 100.00m, 9, "/img/productImagem.jpg");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, name is required.");
        }


        [Fact(DisplayName = "Should throw exception when description is too short")]
        public void CreateProduct_WithShortDescription_NoDomainException()
        {
            Action action = () => new Product("Product", "desc", 100.00m, 9, "/img/productImagem.jpg");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }
        [Fact(DisplayName = "Should throw exception when price is negative")]
        public void CreateProduct_WithNegativePrice_sholdThrowException()
        {
            Action action = () => new Product("product Name", "Description", -100.00m, 9, "/img/productImagem.jpg");


            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Shold throw expection when stock is negative")]
        public void CreateProduct_WithNegativeStock_ShouldThrowException()
        {
            Action action = () => new Product("product Name", "Description", 100.00m, -9, "/img/productImagem.jpg");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        [Theory(DisplayName = "Should throw exception when image is null or empty")]
        [InlineData("")]
        public void CreateProduvt_withNullorEmptyImage_ShouldThrowException(string? image)
        {
            Action action = () => new Product("Product", "description", 100.00m, 9, image!);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image address, image is required.");
        }
        [Fact(DisplayName = "Shuld throw exception when image length exceedes 250 characters")]
        public void CreateProduct_WithTooLongImageName_SholdThrowException()
        {
            string longImageName = new string('o', 251);

            Action action = () => new Product("Product", "description", 100.00m, 9, longImageName);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
        #endregion
    }
}
