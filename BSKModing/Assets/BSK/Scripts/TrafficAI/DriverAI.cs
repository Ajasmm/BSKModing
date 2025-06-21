using Unity.Entities;
using UnityEngine;

using BSK.Vehicles;
using Unity.Collections;
using Unity.Mathematics;
using System;

namespace BSK.Traffic
{
    [RequireComponent(typeof(GameObjectEntity), typeof(Vehicle))]
    public class DriverAI : MonoBehaviour
    {
        [SerializeField] private TrafficAIManagedComponents trafficAIDataManagedComponents;
        [SerializeField] private TrafficAIPathManagedComponent trafficAIPathManagedComponent;
        [SerializeField] private TrafficAITurnDecisionComponent trafficAITurnDecisionComponent;
        [SerializeField] private TrafficAISencorManagedComponent trafficAISencorManagedComponent;
    }
}