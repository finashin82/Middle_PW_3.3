using Components.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAbility : CollisionAbility, ICollisionAbility
{
    public int Damage = 10;

    public void Execute()
    {
        foreach (var target in Collisions)
        {
            var targetHealth = target?.gameObject?.GetComponent<CharacterHealth>();

            if (targetHealth != null) 
            {
                targetHealth.Health -= Damage;
            }
        }
    }
}
