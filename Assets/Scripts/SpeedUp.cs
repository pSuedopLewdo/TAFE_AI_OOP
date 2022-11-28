using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    [SerializeField] protected float speed;
    protected override void PowerUpActive(GameObject marble)
    {
        Rigidbody rb = marble.GetComponent<Rigidbody>();
        if (!rb) return;
        rb.AddForce(rb.velocity.normalized * speed, ForceMode.VelocityChange);
    }
}
