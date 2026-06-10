using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    [Header("Coin Properties")]
    public Collider objectCollider;
    public int coinValue;

    protected override void OnCollect()
    {
        base.OnCollect();
        //ItemManager.Instance.AddCoins(coinValue);
        objectCollider.enabled = false;
    }
}