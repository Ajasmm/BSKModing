using Unity.Entities;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameObjectEntity : MonoBehaviour
{
    public EntityManager entityManager { get; private set; }
    public Entity entity { get; private set; }

    private void Awake()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        entity = entityManager.CreateEntity();
        entityManager.SetName(entity, new Unity.Collections.FixedString64Bytes(this.gameObject.name));

        GameObjectEntityComponent component = new GameObjectEntityComponent()
        {
            entity = entity,
            entityManager = entityManager
        };

        EntityEnabled entityEnabledComponetn = new EntityEnabled() { isEnabled = true };

        entityManager.AddComponentData<GameObjectEntityComponent>(entity, component);
        entityManager.AddComponentData<EntityEnabled>(entity, entityEnabledComponetn);
    }

    private void OnDestroy()
    {
        try
        {
            entityManager.DestroyEntity(entity);
        }
        catch (System.Exception e)
        {
            Debug.Log($"Exception while disposing Entity. {e.Message}");
        }
    }

    private void OnEnable()
    {
        var data = entityManager.GetComponentData<EntityEnabled>(entity);
        data.isEnabled = true;
        entityManager.SetComponentData<EntityEnabled>(entity, data);
    }
    private void OnDisable()
    {
        try
        {
            var data = entityManager.GetComponentData<EntityEnabled>(entity);
            data.isEnabled = false;
            entityManager.SetComponentData<EntityEnabled>(entity, data);
        }
        catch
        {

        }
    }
}


public class GameObjectEntityComponent : IComponentData
{
    public EntityManager entityManager;
    public Entity entity;
}

public struct EntityEnabled : IComponentData
{
    public bool isEnabled;
}