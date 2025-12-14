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


        EntityManager m_EntityManager;
        Entity m_Entity;
        private void OnEnable()
        {
            m_WheelRenderss.enabled = true;
        }
        private void OnDisable()
        {
            m_WheelRenderss.enabled = false;
        }
        private void Start()
        {
            // Create an entity for this
            GameObjectEntity gEntity = GetComponent<GameObjectEntity>();
            m_EntityManager = gEntity.entityManager;
            m_Entity = gEntity.entity;

            m_EntityManager.AddComponentData(m_Entity, m_InputComponent);
            m_EntityManager.AddComponentData(m_Entity, m_ConfigurationComponent);
            m_EntityManager.AddComponentData(m_Entity, m_WheelRenderss);
            m_EntityManager.AddComponentData(m_Entity, m_Axles);
            m_EntityManager.AddComponentData(m_Entity, m_EngineConfigComponent);
            m_EntityManager.AddComponentData(m_Entity, m_GearboxComponent);
            m_EntityManager.AddComponentData(m_Entity, m_AMTGearbox);
            m_EntityManager.AddComponentData(m_Entity, m_BalancingRad);

            // Center Of mass

            if (rigidBody.automaticCenterOfMass)
                rigidBody.automaticCenterOfMass = false;
            rigidBody.centerOfMass = rigidBody.transform.InverseTransformPoint(centerOfMassPos.position);

            // 8 is optimal increase for stability
            if (subStepingWheelCollider != null)
                subStepingWheelCollider.ConfigureVehicleSubsteps(15, subSteping, subSteping);
        }

        // for testing better stability
        [ContextMenu("SubSteping")]
        private void UdpateVehicleSubSteping()
        {
            m_Axles.axles[0].wheelColliders[0].ConfigureVehicleSubsteps(15, subSteping, subSteping);
        }
    }

    
}