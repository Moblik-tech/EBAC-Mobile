using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    [Header("Coin Properties")]
    public Collider objectCollider;
    public int coinValue = 1;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;

    protected override void Collect()
    {
        OnCollect();
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        //ItemManager.Instance.AddCoins(coinValue);
        objectCollider.enabled = false;
        collect = true;
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}