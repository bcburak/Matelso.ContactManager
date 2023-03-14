using Matelso.ContactManager.API.Controllers;
using Matelso.ContactManager.Application.Interfaces.Services;
using Matelso.ContactManager.Application.Responses;
using Matelso.ContactManager.Domain.Contracts;
using Matelso.ContactManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Matelso.ContactManager.UnitTests
{
    public class ContactManagerControllerTests
    {
        private readonly Mock<IContactManagerService> _contactServiceMock;
        private readonly ContactManagerController _contactController;

        public ContactManagerControllerTests()
        {
            _contactServiceMock = new Mock<IContactManagerService>();
            _contactController = new ContactManagerController(_contactServiceMock.Object);
        }

        [Fact]
        public async void CreateContact_ReturnsCreatedContact()
        {
            // Arrange
            var newContact = new ContactDto { FirstName = "John Doe", Email = "john.doe@example.com" };
            var createdContact = new ContactDto { FirstName = "John Doe", Email = "john.doe@example.com" };


            var serviceResponse = new ServiceResponse<ContactDto>(createdContact)
            {
                IsSuccess = true
            };
            _contactServiceMock.Setup(x => x.CreateContact(newContact)).ReturnsAsync(serviceResponse);

            // Act
            var result = await _contactController.CreateContact(newContact);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ContactDto>>(result);
            var createdResult = Assert.IsType<CreatedResult>(actionResult.Result);
            Assert.Equal(createdContact, createdResult.Value);
        }

        [Fact]
        public async void UpdateContact_ReturnsNoContentResult()
        {
            // Arrange
            var contactId = 1;
            var contactToUpdate = new ContactDto { FirstName = "Jane Doe", Email = "jane.doe@example.com" };

            var serviceResponse = new ServiceResponse<ContactDto>(contactToUpdate)
            {
                IsSuccess = true
            };
            _contactServiceMock.Setup(x => x.UpdateContact(contactId, contactToUpdate)).ReturnsAsync(serviceResponse);

            // Act
            var result = await _contactController.UpdateContact(contactId, contactToUpdate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void DeleteContact_ReturnsNoContentResult()
        {
            // Arrange
            var contactId = 1;

            var serviceResponse = new ServiceResponse<int>(contactId)
            {
                IsSuccess = true
            };
            _contactServiceMock.Setup(x => x.DeleteContactById(contactId)).ReturnsAsync(serviceResponse);

            // Act
            var result = await _contactController.DeleteContact(contactId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void GetContactById_ReturnsContact()
        {
            // Arrange
            var contactId = 1;
            var contact = new Contact { Id = 1, FirstName = "John Doe", Email = "john.doe@example.com" };

            var serviceResponse = new ServiceResponse<Contact>(contact)
            {
                IsSuccess = true
            };
            _contactServiceMock.Setup(x => x.GetContactById(contactId)).ReturnsAsync(serviceResponse);

            // Act
            var result = await _contactController.GetContactById(contactId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<ContactDto>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(contact, okObjectResult.Value);
        }
    }
}