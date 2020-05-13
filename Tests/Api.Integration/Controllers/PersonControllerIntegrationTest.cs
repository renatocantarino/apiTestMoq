using core.Api.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tests.Api.Integration.Base;
using Xunit;

namespace Tests.Api.Integration.Controllers
{
    public class PersonControllerIntegrationTest : BaseIntegrationTest
    {
        public PersonControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task AddPerson_GetById_IntegrationTest()
        {
            var newPerson = await CreateNewPerson("João", "joao@test.com", new DateTime(1980, 09, 08));
            await CheckIfNewPersonWasAdded(newPerson);
        }

        private async Task CheckAllAddedPerson(int expectedCount)
        {
            var response = await Server
                .CreateRequest($"api/person")
                .GetAsync();

            Assert.Equal(200, (int)response.StatusCode);

            var responseDto = JsonConvert.DeserializeObject<List<PersonDto>>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(responseDto);
            Assert.NotEmpty(responseDto);
            Assert.Equal(expectedCount, responseDto.Count);
        }

        private async Task CheckIfNewPersonWasAdded(PersonDto addedPerson)
        {
            var response = await Server
                .CreateRequest($"api/person/{addedPerson.Id}")
                .GetAsync();

            Assert.Equal(200, (int)response.StatusCode);

            var responseDto = JsonConvert.DeserializeObject<PersonDto>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(responseDto);
            Assert.Equal(addedPerson.Id, responseDto.Id);
        }

        private async Task<PersonDto> CreateNewPerson(string name, string email, DateTime dateOfBirth)
        {
            var dto = new PersonDto
            {
                Name = name,
                DateOfBirth = dateOfBirth,
                Email = email
            };

            var response = await Server
                .CreateRequest("api/person")
                .And(req => req.Content = GenerateRequestContent(dto))
                .PostAsync();

            Assert.Equal(201, (int)response.StatusCode);

            var responseDto = JsonConvert.DeserializeObject<PersonDto>(await response.Content.ReadAsStringAsync());
            Assert.NotNull(responseDto);
            Assert.Equal(name, responseDto.Name);

            return responseDto;
        }
    }
}