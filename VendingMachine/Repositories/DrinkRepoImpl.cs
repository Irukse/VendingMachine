using Microsoft.EntityFrameworkCore;
using VendingMachine.Models.Entity;

namespace VendingMachine.Repositories;

public class DrinkRepoImpl : IDrinkRepo
{
    private readonly RepositoryContext _context;

    public DrinkRepoImpl(RepositoryContext context)
    {
        _context = context;
    }
    
    public async Task AddDrink(Drink drinkRequest)
    {
        var movie = new Drink()
        {
            Id = Guid.NewGuid(),
            Title = drinkRequest.Title,
            Amount = drinkRequest.Amount,
            Price = drinkRequest.Price,
            IsAvailable = drinkRequest.IsAvailable,
            ImageUrl = drinkRequest.ImageUrl,
            ImageNotAvailableUrl = drinkRequest.ImageNotAvailableUrl
        };

        await _context.Drinks.AddAsync(movie);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Drink> GetDrink(string title)
    {
        var drink = _context.Drinks.FirstOrDefault(x => x.Title == title) ?? throw new Exception($"drink : {title} is not exist");

        return drink;
    }

    public async Task<Drink> UpdateDrinkPrice(string title, decimal price)
    {
        var drink = _context.Drinks.FirstOrDefault(x => x.Title == title) ?? throw new Exception($"drink : {title} is not exist");

        drink.Price = price;
        
        await _context.SaveChangesAsync();
        return drink;
    }

    public async Task<Drink> UpdateDrinkAmount(string title, int amount)
    {
        var drink = _context.Drinks.FirstOrDefault(x => x.Title == title) ?? throw new Exception($"drink : {title} is not exist");

        drink.Amount = amount;
        
        await _context.SaveChangesAsync();
        return drink;
    }

    public async Task<Drink> UpdateDrinkImage(string title, string imageUrl)
    {
        var drink = _context.Drinks.FirstOrDefault(x => x.Title == title) ?? throw new Exception($"drink : {title} is not exist");
        drink.ImageUrl = imageUrl;
        await _context.SaveChangesAsync();
        return drink;
    }

    public async Task DeleteDrink(string title)
    {
        var drink = _context.Drinks.FirstOrDefault(x => x.Title == title) ?? throw new Exception($"drink : {title} is not exist");
        _context.Remove(drink);
        await _context.SaveChangesAsync();
    }
}