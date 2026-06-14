using UnityEngine;

public class PowerUpInvincible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Invincible");
        PlayerController.Instance.SetInvincible(true);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetPowerUpText("");
        PlayerController.Instance.SetInvincible(false);
    }
}