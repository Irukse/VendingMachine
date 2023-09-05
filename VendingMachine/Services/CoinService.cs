using VendingMachine.Enums;
using VendingMachine.Repositories;

namespace VendingMachine.Services;

public class CoinService
{
    private readonly ICoinRepo _repository;

    public CoinService(ICoinRepo repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> UpdateCoinAmount(int coinNominal, int amount)
    {
        if (Enum.IsDefined(typeof(CoinNominal), coinNominal))
        {
            await _repository.UpdateCoinAmount(coinNominal, amount);
            return true;
        }
        
        return false;
    }

    public async Task<bool> UpdateCoinAvailable(int coinNominal, bool isAvailable)
    {
        if (Enum.IsDefined(typeof(CoinNominal), coinNominal))
        {
            await _repository.UpdateCoinAvailable(coinNominal, isAvailable);
            return true;
        }

        return false;
    }
}