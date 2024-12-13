using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BulletPrefabData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {        
        dstManager.AddComponentData(entity, new BulletData
        {
            Speed = speed / 100
        });  
    }
}

public struct BulletData : IComponentData
{
    public float Speed;
}
