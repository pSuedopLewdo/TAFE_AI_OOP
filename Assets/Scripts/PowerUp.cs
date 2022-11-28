using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : Zone
{
    protected abstract void PowerUpActive(GameObject marble);
    protected override void ZoneTrigger(GameObject marble)
    {
        if (isDeactivating == 0)
        {
            StartCoroutine(DisableWithDelay(gameObject, 0.2f, 2f, true));
        }
        PowerUpActive(marble);
    }
}
