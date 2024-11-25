using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;

    public MonoBehaviour ShootAction;

    public float burst;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new InputData());

        dstManager.AddComponentData(entity, new MoveData
        {
            Speed = speed / 100
        });

        if (ShootAction != null && ShootAction is IAbility) 
        {
            dstManager.AddComponentData(entity, new ShootData());
        }

        dstManager.AddComponentData(entity, new BurstData { Burst = burst });
    }
}

public struct InputData : IComponentData 
{
    public float2 Move;

    public float Shoot;

    public float2 BurstMove;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct ShootData : IComponentData 
{
    
}

public struct BurstData : IComponentData
{
    public float Burst;
}
