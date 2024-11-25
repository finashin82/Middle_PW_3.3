using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;

    public float shootDelay = float.MinValue;

    private float _shootTime = 0;

    public void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;
        
        _shootTime = Time.time;

        if (bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position, t.rotation);
        }
        else
        {
            Debug.LogError("[SHOOT ABILITY] No bullet prefab link!");
        }
    }
}
