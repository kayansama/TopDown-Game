using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : InteractionAbstract
{
    public override void Interact() { }

    public override void Interact2()
    {
        GameManager.Instance.ShootingSpeedBoost();
        Destroy(gameObject);
        //StartCoroutine(BoostShootingSpeed());
    }
    






}
