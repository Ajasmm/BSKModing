using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace BSK.Vehicles
{
    public class Horn : MonoBehaviour
    {
        [SerializeField] public HornType hornType;
        [SerializeField] AudioSource emitter;
        [SerializeField] ToggleModes toggleMode = ToggleModes.OFF;


        [Header("Horn events")]
        [SerializeField] UnityEvent OnHornOn;
        [SerializeField] UnityEvent OnHornOff;

        

        public enum HornType
        {
            Horn_1,
            Horn_2
        }
    }
}