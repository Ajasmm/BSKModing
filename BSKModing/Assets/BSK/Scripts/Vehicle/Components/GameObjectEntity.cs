using Unity.Entities;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameObjectEntity : MonoBehaviour
{
    
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