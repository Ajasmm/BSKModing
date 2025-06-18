using UnityEngine;
using System;
using Unity.Entities;

namespace BSK.Vehicles
{
    [Serializable]
    public class EngineSoundComponent : IComponentData
    {
        [Header("Debugging variables")]
        public bool isDebugging = false;
        public float debuggingEngineRPM;
        public float debuggingEngineAcceleration;

        [Header("Engine Sound parameter")]
        public bool isPlayerVehicle = true;
        public float minRPM = 500, maxRPM = 2500;
        public EngineSoundClip[] engineSoundClips;

        public float engineRPM = 500, engineAcceleration = 0;
    }
}