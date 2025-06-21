using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Splines;
using UnityEngine;
using Unity.Collections;

namespace BSK.Traffic
{
    [Serializable]
    public class TrafficAIManagedComponents : IComponentData
    {
        public Transform mTransform;
        public float maxSpeed;
        public float maxSpeedAtFullSteering;
    }

    [Serializable]
    public struct TrafficAIPositionComponent : IComponentData
    {
        public float3 currentPos;
        public float4x4 worldToLocal;
    }

    [Serializable]
    public struct TrafficAISteeringComponent : IComponentData
    {
        public float maxSteering;
        public float maxSpeed;
        public float maxSpeedAtFullSteering;
        
        public float remainingDistance;
        public float coverdDistance;

        public float currentSteering;
        public float targetSpeed;
    }

    [Serializable]
    public struct TrafficAIPathComponent : IComponentData
    {
        public float pathSpeed;
        public bool isAssigned;
        [NonSerialized] public NativeArray<float3> currentPath;
    }
    public struct TrafficAISencorSpeedComponent : IComponentData
    {
        public float maxSpeed;
        public float sudenBrakeDistance;
        public float speedAtBrakeDistance;
        public float targetSpeed;
    }

    [Serializable]
    public class TrafficAIPathManagedComponent : IComponentData
    {
        public TrafficPath trafficPath;
    }

    [Serializable]
    public class TrafficAITurnDecisionComponent : IComponentData
    {
        public bool decisioPending = true;
        public bool scheduleForIndicatorOff = false;
        public IndicatorModes indicatorModes = IndicatorModes.OFF;
        public TrafficPath nextPath;
    }
    [Serializable]
    public class TrafficAISencorManagedComponent : IComponentData
    {
        public LayerMask hitLayerMask;
        public float sudenBrakeDistance = 5;
        public float speedAtBrakeDistance = 15;
        public Transform[] frontSencors;
    }
    [Serializable]
    public struct TrafficAISpeedLimitedByAreaComponent : IComponentData
    {
        public float maxSpeed;
    }
}