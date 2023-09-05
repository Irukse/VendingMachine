using System.ComponentModel.DataAnnotations;
using VendingMachine.Enums;

namespace VendingMachine.Models.Entity;

public class Coin
{
    /// <summary>
    ///     Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    ///     Nominal
    /// </summary>
    [Required]
    public int Nominal { get; set; }

    /// <summary>
    ///     Number of coins
    /// </summary>
    public int Storage { get; set; }
    
    /// <summary>
    ///     Is the coin available
    /// </summary>
    public bool IsAvailable { get; set; }
}