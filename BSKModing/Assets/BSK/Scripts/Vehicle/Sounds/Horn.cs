using UnityEngine;

namespace BSK.Vehicles
{
    public class Horn : MonoBehaviour
    {
        [SerializeField] AudioSource emitter;
        [SerializeField] ToggleModes toggleMode = ToggleModes.OFF;

    }
}