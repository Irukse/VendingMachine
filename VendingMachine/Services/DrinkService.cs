using VendingMachine.Models.Dto;
using VendingMachine.Models.Entity;
using VendingMachine.Repositories;

namespace VendingMachine.Services;

public class DrinkService
{
    private readonly IDrinkRepo _repository;

    public DrinkService(IDrinkRepo repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddDrink(DrinkDto drinkDto)
    {
        var imageBase64 = ImageConvertor.ConvertImageToBase(drinkDto.ImageUrl);
        var drinkEntity = new Drink
        {
            Title = drinkDto.Title,
            Amount = drinkDto.Amount,
            Price = drinkDto.Price,
            IsAvailable = drinkDto.IsAvailable,
            Image = imageBase64,
        };
        
        await _repository.AddDrink(drinkEntity);
        return true;
    }
    
    public async Task<bool> UpdateDrinkPrice(string title, decimal price)
    {
        await _repository.UpdateDrinkPrice(title, price);
        return true;
    }
    
    public async Task<bool> UpdateDrinkAmount(string title, int amount)
    {
        await _repository.UpdateDrinkAmount(title, amount);
        return true;
    }
    
    public async Task<bool> UpdateDrinkImage(string title, string imageUrl)
    {
        var imageBase64 = ImageConvertor.ConvertImageToBase(imageUrl);
        await _repository.UpdateDrinkImage(title, imageBase64);
        return true;
    }
    
    public async Task<bool> DeleteDrink(string title)
    {
        await _repository.DeleteDrink(title);
        return true;
    }
}