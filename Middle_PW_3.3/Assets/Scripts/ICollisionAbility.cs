using System.Collections.Generic;
using UnityEngine;

namespace Components.Interface
{
    internal interface ICollisionAbility: IAbility
    {
        List<Collider> Collisions { get; set; } 
    }
}