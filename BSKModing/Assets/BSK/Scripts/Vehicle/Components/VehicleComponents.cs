using JetBrains.Annotations;
using System;
using Unity.Entities;
using UnityEngine;

namespace BSK.Vehicles
{
    [Serializable]
    public class VehicleInputComponent : IComponentData
    {
        
    }

    [Serializable]
    public class VehicleComponent : IComponentData
    {
        public Transform vehicleRoot;
        public Rigidbody rigidBody;
        public VehicleConfig config;
        [HideInInspector] public EngineSoundComponent sound;
    }

    [Serializable]
    public class WheelRenderComponent : IComponentData
    {
        public WheelCollider[] wheelColliders;
        public Transform[] wheelMeshTransforms;
    }

    [Serializable]
    public class VehicleAxleComponent : IComponentData
    {
        public Axle[] axles;
    }
    [Serializable]
    public class Axle
    {
        public WheelCollider[] wheelColliders;

        public bool steering;
        public bool engine;
        public bool handBrake;
        public bool brake;
    }

    [Serializable]
    public class VehicleEngineComponent : IComponentData
    {
        public EngineConfig config;
    }

    [Serializable]
    public class VehicleGearboxComponent : IComponentData 
    {
        public GearboxConfig config;
    }

    [Serializable]
    public class VehicleAMTGearbox : IComponentData
    {

    }

    [Serializable]
    public class VehicleBalancingRadComponent : IComponentData
    {
        public Rigidbody rb;
        public BalancingRad[] balancingRads;

        [Serializable]
        public class BalancingRad
        {
            public float forceMultiplier = 1;
            public WheelCollider leftWheel;
            public WheelCollider rightWheel;
            public Transform leftWheelTransform;
            public Transform rightWheelTransform;
        }
    }
    public enum GearboxMode
    {
        Automatic,
        Manual
    }
}