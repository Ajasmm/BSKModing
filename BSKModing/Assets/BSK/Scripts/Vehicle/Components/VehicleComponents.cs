using JetBrains.Annotations;
using System;
using Unity.Entities;
using UnityEngine;

namespace BSK.Vehicles
{
    [Serializable]
    public class VehicleInputComponent : IComponentData
    {
        [Header("Not Editable")]
        public bool gearlock;
        public bool engineOnOffState;

        public float steering;
        public float acceleration;
        public float braking;
        public bool handbrake;

        public float clutch;
        public float speed;

        public float gearboxAcceleration;
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

        [Header("Not Editable")]
        public bool enabled = true;
    }

    [Serializable]
    public class VehicleAxleComponent : IComponentData
    {
        public Axle[] axles;

        [Header("Not Editable")]
        public float gearboxTorque;
        public float wheelRPM;
    }
    [Serializable]
    public class Axle
    {
        public WheelCollider[] wheelColliders;

        public bool steering;
        public bool engine;
        public bool handBrake;
        public bool brake;
        public float steeringFactor = 1;
    }

    [Serializable]
    public class VehicleEngineComponent : IComponentData
    {
        public EngineConfig config;

        [Header("Not Editable")]
        // Inputs
        public float gearBoxRPM;
        
        // outputs
        public float engineRPM;
        public float engineTorque;
    }

    [Serializable]
    public class VehicleGearboxComponent : IComponentData 
    {
        public GearboxConfig config;

        [Header("Not Editable")]
        public int currentGear;
        public DriveModes currentDriveMode;


        // inputs
        public float engineTorque;
        public float wheelRPM;
        // outputs
        public float gearboxRPM;
        public float gearboxTorque;
    }

    [Serializable]
    public class VehicleAMTGearbox : IComponentData
    {
        [Header("Not Editable")]
        public DriveModes targetDriveMode;
        public GearboxMode gearboxMode;
        public int targetGear = 0;
        public int maxTargetGear = 0;
        public float clutch = 0;
        public float accelerationLimiter = 1;
        public float gearChangeDelay = 0.5f;
        public float gearChangeWaitingTime = 0.5f;
        public float gearChangeWaitingTimer = 0;
        public float gearChangeCoolOfTime = 1f;
        public float gearChangeCoolOfTimer = 0;
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