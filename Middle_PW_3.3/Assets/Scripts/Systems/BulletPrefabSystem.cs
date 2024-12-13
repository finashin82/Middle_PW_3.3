using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BulletPrefabSystem : ComponentSystem
{
    private EntityQuery _moveQuery;    

    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<BulletData>(), ComponentType.ReadOnly<Transform>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
            (Entity entity, Transform transform, ref BulletData bulletData) =>
            {
                var pos = transform.position;

                pos += new Vector3(0, 0, bulletData.Speed);

                transform.position = pos;
            });
    }
}
