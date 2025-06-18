using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;
using UnityEngine.Audio;

namespace BSK.Vehicles
{
    [RequireComponent(typeof(GameObjectEntity))]
    public class EngineSound : MonoBehaviour
    {
        public string playerVehicleName;
        public bool isPlayer = false;
        [SerializeField] AudioMixer currentMixer;
        public EngineSoundComponent soundComponent;


    }
}