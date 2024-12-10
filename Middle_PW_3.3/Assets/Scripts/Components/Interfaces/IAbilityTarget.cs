using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Components.Interfaces
{

    public interface IAbilityTarget : IAbility
    {
        List<GameObject> Targets { get; set; }
    }
}
