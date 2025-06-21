using Unity.Entities;
using UnityEngine;

namespace BSK.Vehicles
{
    [RequireComponent(typeof(GameObjectEntity))]
    [DefaultExecutionOrder(-1)]
    public class Vehicle : MonoBehaviour
    {
        [Header("Inputs")]
        [SerializeField] public VehicleInputComponent m_InputComponent;

        [Header("Configuration")]
        [SerializeField] public VehicleComponent m_ConfigurationComponent;
        [SerializeField] public VehicleEngineComponent m_EngineConfigComponent;
        [SerializeField] public VehicleGearboxComponent m_GearboxComponent;
        [SerializeField] public VehicleAMTGearbox m_AMTGearbox;

        [Header("Wheels")]
        [SerializeField] WheelRenderComponent m_WheelRenderss;
        [SerializeField] VehicleAxleComponent m_Axles;

        [Header("BalancingRad")]
        public VehicleBalancingRadComponent m_BalancingRad;

        [Header("Center Of Mass")]
        [SerializeField] public Rigidbody rigidBody;
        [SerializeField] Transform centerOfMassPos;
        [Header("Vehicle physics subSteping")]
        [SerializeField] WheelCollider subStepingWheelCollider;
        [SerializeField] int subSteping = 10;
        
    }

    
}