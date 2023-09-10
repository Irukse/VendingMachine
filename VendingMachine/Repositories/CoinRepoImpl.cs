using System.Security.Cryptography.Xml;
using VendingMachine.Enums;
using VendingMachine.Models.Entity;

namespace VendingMachine.Repositories;

public class CoinRepoImpl : ICoinRepo
{
    private readonly RepositoryContext _context;

    public CoinRepoImpl(RepositoryContext context)
    {
        _context = context;
    }
    
    public async Task<Coin> UpdateCoinAmount(int coinNominal, int amount)
    {
        var coin = _context.Coins.FirstOrDefault(x => x.Nominal == coinNominal) ?? throw new Exception($"");
        coin.Storage = amount;
        await _context.SaveChangesAsync();
        return coin;
    }

    public async Task<Coin> UpdateCoinAvailable(int coinNominal, bool isAvailable)
    {
        var coin = _context.Coins.FirstOrDefault(x => x.Nominal == coinNominal) ?? throw new Exception($"");
        coin.IsAvailable = isAvailable;
        await _context.SaveChangesAsync();
        return coin;
    }
    
    public List<Coin> GetCoinAvailable()
    {
        var coins = _context.Coins.Where(coins => coins.IsAvailable == true).ToList();
        return coins;
    }
    
    public int GetCoin(int coin)
    {
        var coins = _context.Coins.FirstOrDefault(x => x.Nominal == coin) ?? throw new Exception($"");
        var amount = coins.Storage;
        return amount;
    }
}