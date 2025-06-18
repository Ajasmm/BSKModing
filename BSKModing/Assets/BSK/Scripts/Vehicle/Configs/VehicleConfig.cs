using UnityEngine;

namespace BSK.Vehicles
{
    [CreateAssetMenu(menuName = "Vehicle/VehicleConfig", fileName = "_VehicleConfig")]
    public class VehicleConfig : ScriptableObject
    {
        public float maxSteerAngle;
        public float maxBrakeTorque;
    }
}