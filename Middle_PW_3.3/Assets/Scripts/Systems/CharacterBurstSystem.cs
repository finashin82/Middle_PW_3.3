using Unity.Entities;
using UnityEngine;

public class CharacterBurstSystem : ComponentSystem
{
    private EntityQuery _burstQuery;

    protected override void OnCreate()
    {
        _burstQuery = GetEntityQuery(ComponentType.ReadOnly<BurstData>(), ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<Transform>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_burstQuery).ForEach(
            (Entity entity, Transform transform, ref InputData inputData, ref BurstData burstData) =>
            {
                var pos = transform.position;

                pos += new Vector3(0, 0, inputData.BurstMove.y * burstData.Burst);

                transform.position = pos;            
            });
    }
}
