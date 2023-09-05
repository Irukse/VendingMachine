using VendingMachine.Models.Entity;

namespace VendingMachine.Repositories;

public interface IDrinkRepo
{
    /// <summary>
    ///     Add drink
    /// </summary>
    /// <param name="drinkRequest"></param>
    /// <returns></returns>
    public Task AddDrink(Drink drinkRequest);

    /// <summary>
    ///     Update drink price
    /// </summary>
    /// <param name="title"></param>
    /// <param name="price"></param>
    /// <returns></returns>
    public Task<Drink> UpdateDrinkPrice(string title, decimal price);
    
    /// <summary>
    ///     Update drink amount
    /// </summary>
    /// <param name="title"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public Task<Drink> UpdateDrinkAmount(string title, int amount);
    
    /// <summary>
    ///     Update drink iImage
    /// </summary>
    /// <param name="title"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    public Task<Drink> UpdateDrinkImage(string title, string image);
    
    /// <summary>
    ///     Delete drink
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public Task DeleteDrink(string title);
}