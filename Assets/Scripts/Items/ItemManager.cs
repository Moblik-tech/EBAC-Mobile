using Moblik.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    private int coins;

    public void AddCoins(int amount)
    {
        coins += amount;
    }
}