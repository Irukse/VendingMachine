using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models.Dto;
using VendingMachine.Models.Entity;
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
    
    [HttpPut("UpdateDrinkPrice")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task UpdateDrinkPrice([FromQuery] string title, decimal price)
    {
        await _drinkService.UpdateDrinkPrice( title, price);
    }
    
    [HttpPut("UpdateDrinkAmount")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task UpdateDrinkAmount([FromQuery] string title, int amount)
    {
        await _drinkService.UpdateDrinkAmount(title, amount);
    }
    
    [HttpPut("UpdateDrinkImage")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task UpdateDrinkImage([FromQuery] string title, string imageUrl, bool isActive)
    {
        await _drinkService.UpdateDrinkImage(title, imageUrl, isActive);
    }
    
    [HttpPut("DeleteDrink")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task DeleteDrink([FromQuery] string title)
    {
        await _drinkService.DeleteDrink(title);
    }
    
    [HttpPut("UpdateCoinAmount")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task UpdateCoinAmount([FromQuery] int coinNominal, int amount)
    {
        await _coinService.UpdateCoinAmount(coinNominal, amount);
    }
    
    [HttpPut("UpdateCoinAvailable")]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task UpdateCoinAvailable([FromQuery]int coinNominal, bool isAvailable)
    {
        await _coinService.UpdateCoinAvailable(coinNominal, isAvailable);
    }
}