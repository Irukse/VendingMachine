using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Models.Entity;

public class Drink
{
    /// <summary>
    ///     Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Title
    /// </summary>
    [Required]
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
    ///     Image
    /// </summary>
    public string Image { get; set; }
}