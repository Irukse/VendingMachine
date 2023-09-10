using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models.Dto;
using VendingMachine.Models.Entity;
using VendingMachine.Services;

namespace VendingMachine.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpPost("BuyDrink")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<(string, decimal)> BuyDrink([FromQuery] UserDto userDto)
    {
        var result = await _service.BuyDrink(userDto);
        return (result.Item1, result.Item2);
    }
}