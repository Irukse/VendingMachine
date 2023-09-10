using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VendingMachine.Models.Entity;

[Table("coin")]
[Index(nameof(Nominal), IsUnique = true)]
public class Coin
{
    /// <summary>
    ///     Id
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }
    
    /// <summary>
    ///     Nominal
    /// </summary>
    [Required]
    [Column("nominal")]
    public int Nominal { get; set; }

    /// <summary>
    ///     Number of coins
    /// </summary>
    [Column("storage")]
    public int Storage { get; set; }
    
    /// <summary>
    ///     Is the coin available
    /// </summary>
    [Column("isAvailable")]
    public bool IsAvailable { get; set; }
}