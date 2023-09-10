using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VendingMachine.Models.Entity;

[Table("drink")]
[Index(nameof(Title), IsUnique = true)]
public class Drink
{
    /// <summary>
    ///     Id
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public Guid Id { get; set; }

    /// <summary>
    ///     Title
    /// </summary>
    [Required]
    [Column("title")]
    public string Title { get; set; }
    
    ///<summary>
    ///     Amount in machine
    /// </summary>
    [Column("amount")]
    public int Amount { get; set; }
    
    /// <summary>
    ///     Price
    /// </summary>
    [Column("price")]
    public decimal Price { get; set; }
    
    ///<summary>
    ///     Is a drink available
    /// </summary>
    [Column("isAvailable")]
    public bool IsAvailable { get; set; }
    
    /// <summary>
    ///     ImageUrl
    /// </summary>
    [Column("imageUrl")]
    public string ImageUrl { get; set; }
    
    /// <summary>
    ///     Image Url not available
    /// </summary>
    [Column("imageNotAvailable")]
    public string ImageNotAvailableUrl { get; set; }
}