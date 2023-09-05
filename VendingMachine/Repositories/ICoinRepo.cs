using VendingMachine.Enums;
using VendingMachine.Models.Entity;

namespace VendingMachine.Repositories;

public interface ICoinRepo
{
    /// <summary>
    ///     Update coin amount
    /// </summary>
    /// <param name="coinNominal"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public Task<Coin> UpdateCoinAmount(int coinNominal, int amount);

    /// <summary>
    ///     Update coin available
    /// </summary>
    /// <param name="coinNominal"></param>
    /// <param name="isAvailable"></param>
    /// <returns></returns>
    public Task<Coin> UpdateCoinAvailable(int coinNominal, bool isAvailable);
}