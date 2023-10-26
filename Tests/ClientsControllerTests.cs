using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using XP_Rest_API;
using XP_Rest_API.Controllers;
using XP_Rest_API.Models.DTO;
using XP_Rest_API.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Tests.ClientsControllerTests;
public class ClientsControllerTests
{
    private IList<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var ctx = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, ctx, validationResults, true);
        return validationResults;
    }
    [Fact]
    public void CreateClient_InvalidEmail_ShouldReturnBadRequest()
    {
        // Arrange
        var createClientDTO = new CreateClientDTO
        {
            Name = "John Doe",
            Phone = "(43)91234-3943",
            Emails = new List<string> { "invalid-email" },
            Addresses = new List<NewAddressDTO>
            { new NewAddressDTO { City = "City", State = "State", Street = "Street" } }
        };

        // Act
        var result = ValidateModel(createClientDTO);
        // Assert
        Assert.True(result.Count == 1);
        Assert.Contains("Invalid email address format", result.FirstOrDefault()!.ErrorMessage);
    }

    [Fact]
    public void CreateClient_InvalidPhone_ShouldReturnBadRequest()
    {
        // Arrange
        var createClientDTO = new CreateClientDTO
        {
            Name = "John Doe",
            Phone = "invalid-phone",
            Emails = new List<string> { "john@doe.com" },
            Addresses = new List<NewAddressDTO>
            { new NewAddressDTO { City = "City", State = "State", Street = "Street" } }
        };

        // Act
        var result = ValidateModel(createClientDTO);
        // Assert
        Assert.True(result.Count == 1);
        Assert.Contains("Invalid phone number format", result.FirstOrDefault()!.ErrorMessage);
    }

    [Fact]
    public void CreateClient_ValidModel_ShouldReturnOk()
    {
        // Arrange
        var createClientDTO = new CreateClientDTO
        {
            Name = "John Doe",
            Phone = "(43)91234-3943",
            Emails = new List<string> { "john@doe.com" },
            Addresses = new List<NewAddressDTO>
            { new NewAddressDTO { City = "City", State = "State", Street = "Street" } }
        };

        // Act
        var result = ValidateModel(createClientDTO);
        // Assert
        Assert.True(result.Count == 0);
    }
}
