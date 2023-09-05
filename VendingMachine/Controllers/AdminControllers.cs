using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models.Dto;
using VendingMachine.Services;

namespace VendingMachine.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminControllers : ControllerBase
{
    private readonly DrinkService _drinkService;
    private readonly CoinService _coinService;

    public AdminControllers(DrinkService drinkService, CoinService coinService)
    {
        _drinkService = drinkService;
        _coinService = coinService;
    }
    
    [HttpPost("AddDrink")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task AddNewDrink([FromQuery] DrinkDto drinkDto)
    {
      await _drinkService.AddDrink(drinkDto);
    }
}