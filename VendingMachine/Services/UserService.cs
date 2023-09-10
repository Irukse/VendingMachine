using VendingMachine.Enums;
using VendingMachine.Models.Dto;
using VendingMachine.Models.Entity;

namespace VendingMachine.Services;

public class UserService
{
    private readonly CoinService _service;
    private readonly DrinkService _drinkService;

    public UserService(CoinService service, DrinkService drinkService)
    {
        _service = service;
        _drinkService = drinkService;
    }

    public async Task<(string, decimal)> BuyDrink(UserDto userData)
    {
        var depositSum = userData.Deposit.Sum(deposit => (decimal)deposit);
        var drink = await _drinkService.GetDrink(userData.Drink);

        if (depositSum >= drink.Price && drink.Amount > 0)
        {
            var change = depositSum - drink.Price;
            await _drinkService.UpdateDrinkAmount(userData.Drink, drink.Amount - 1);
            var depositNominals = DepositedNominals(userData.Deposit);

            foreach (var deposit in depositNominals)
            {
                
                var amount = _service.GetCoin(deposit.Key);
                await _service.UpdateCoinAmount(deposit.Key, amount + deposit.Value);
            }

            return (drink.Title, change);
        }

        return ("", depositSum);
    }

    private Dictionary<int, int> DepositedNominals(List<int> deposit)
    {
        var amountNominals =
            deposit.GroupBy(nominal => nominal, (nominal, amount)
                    => new { Key = nominal, Cnt = amount.Count() })
                .ToDictionary(amountNominal
                    => (int)amountNominal.Key, amountNominal => (int)amountNominal.Cnt);

        return amountNominals;
    }
    
    private List<CoinNominal> ShowAvailableCoins()
    {
        var coins = _service.GetCoinAvailable();
        return 
            (from coin in coins where Enum.IsDefined(typeof(CoinNominal), coin) 
                select (CoinNominal)coin.Nominal).ToList();
    }
}