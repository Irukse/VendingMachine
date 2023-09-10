namespace VendingMachine.Models.Dto;

public class DrinkDto
{
    /// <summary>
    ///     Title
    /// </summary>
    public string Title { get; set; }
    
    ///<summary>
    ///     Amount in machine
    /// </summary>
    public int Amount { get; set; }
    
    /// <summary>
    ///     Price
    /// </summary>
    public decimal Price { get; set; }
    
    ///<summary>
    ///     Is a drink available
    /// </summary>
    public bool IsAvailable { get; set; }
    
    /// <summary>
    ///     ImageUrl
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    ///     ImageUrl
    /// </summary>
    public string ImageNotAvailableUrl { get; set; }
}