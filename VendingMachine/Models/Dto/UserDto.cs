using System.Runtime.InteropServices.JavaScript;
using VendingMachine.Enums;
using VendingMachine.Services;

namespace VendingMachine.Models.Dto;

public class UserDto 
{
    /// <summary>
    /// Deposited coins
    /// </summary>
    public List<int> Deposit { get; set; }
    
    /// <summary>
    /// Chuse drink
    /// </summary>
    public string Drink { get; set; }
}