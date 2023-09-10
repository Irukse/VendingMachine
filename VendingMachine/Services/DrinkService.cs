using Microsoft.Extensions.Options;
using VendingMachine.Configurations;
using VendingMachine.Models.Dto;
using VendingMachine.Models.Entity;
using VendingMachine.Repositories;

namespace VendingMachine.Services;

public class DrinkService
{
    private readonly IDrinkRepo _repository;
    private readonly StorageConfigurations _storage;
    
    public DrinkService(IDrinkRepo repository, IOptions<StorageConfigurations> storage)
    {
        _repository = repository;
        _storage = storage.Value;
    }

    public async Task AddDrink(DrinkDto drinkDto)
    {
        var image = ReadImage(drinkDto.ImageUrl, drinkDto.Title, true);
        ImageConvertor.WriteImage(_storage.Path, image.Item1, image.Item2);
        
        var imageNotActive = ReadImage(drinkDto.ImageNotAvailableUrl, drinkDto.Title, false);
        ImageConvertor.WriteImage(_storage.Path, imageNotActive.Item1, imageNotActive.Item2);

        var drinkEntity = new Drink
        {
            Title = drinkDto.Title,
            Amount = drinkDto.Amount,
            Price = drinkDto.Price,
            IsAvailable = drinkDto.IsAvailable,
            ImageUrl = image.Item1,
            ImageNotAvailableUrl = imageNotActive.Item1,
        };
        
        await _repository.AddDrink(drinkEntity);
    }

    public async Task<Drink> GetDrink(string title)
    {
        var drink = await _repository.GetDrink(title);
        return drink;

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
    
    public async Task<bool> UpdateDrinkImage(string title, string imageUrl, bool isActive)
    {
        var drink = await _repository.GetDrink(title);
        DeleteImage(isActive ? drink.ImageUrl : drink.ImageNotAvailableUrl);

        var image = ReadImage(imageUrl, title, isActive);
        ImageConvertor.WriteImage(_storage.Path, image.Item1, image.Item2);
        return true;
    }
    
    public async Task<bool> DeleteDrink(string title)
    {
        await _repository.DeleteDrink(title);
        return true;
    }
    
    private (string, byte[]) ReadImage(string imageUrl, string title, bool isActive)
    {
        string nameImage;
        var image = ImageConvertor.ReadImage(imageUrl);
        var extension = Path.GetExtension(imageUrl); //get extension file
       
        if (isActive)  
        {
            nameImage = title+"Active"+extension; //create image name
        }
        else
        {
            nameImage = title+"NotActive"+extension;
        }
        
        return (nameImage, image);
    }

    private void DeleteImage(string nameImage)
    {
        var path = _storage.Path +"\\"+ nameImage;
        File.Delete(path);
    }
}