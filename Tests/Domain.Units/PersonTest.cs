using System;
using core.Domain.People.Entities;
using Xunit;

namespace Tests.Domain.Units
{
    public class PersonTest
    {
        const string VALID_NAME = "Nome";
        const string VALID_EMAIL = "email@prov.com";
        DateTime VALID_DATE_OF_BIRTH = new DateTime(1980 ,09 , 20);

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            var pessoa = new Person(string.Empty, VALID_EMAIL, VALID_DATE_OF_BIRTH);
            var result = pessoa.IsValid;

            Assert.False(result);
        }

        [Theory]
        [InlineData("abc@def.")]
        [InlineData("abc@")]
        [InlineData("abc.defghi.gov.br")]
        [InlineData("@ghi.org.br")]
        public void Email_ShouldNotBeEInvalid(string email)
        {
            var pessoa = new Person(VALID_NAME, email, VALID_DATE_OF_BIRTH);
            var result = pessoa.IsValid;

            Assert.False(result);
            Assert.NotNull(pessoa.ValidationResult.Errors);
            Assert.NotEmpty(pessoa.ValidationResult.Errors);
        }
    }
}