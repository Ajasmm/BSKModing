using UnityEngine;

namespace BSK.Vehicles
{
    [CreateAssetMenu(menuName ="Vehicle/EngineConfig", fileName ="_EngineConfig")]
    public class EngineConfig : ScriptableObject
    {
        public AnimationCurve engineTorqueCurve;
        public AnimationCurve engineFrictionCurve;

        public float maxRPM = 5000;
        public float idleRPM = 700;
        public float accelerationRPM = 300;
        public float accelerationMaxRPM = 1500;
        public float gearDownRPM = 1000;
        public float gearUpRPM = 1650;
        public float deltaEngineRPM = 1000;
    }
}