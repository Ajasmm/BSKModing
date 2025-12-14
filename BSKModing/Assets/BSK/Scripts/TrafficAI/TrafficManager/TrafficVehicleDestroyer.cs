using BSK.Traffic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(DriverAI))]
public class TrafficVehicleDestroyer : MonoBehaviour
{
    Transform m_Transform;

    // Used to count the frames
    // some times this scripts LateUpdate is called even before other monobehaviours Start
    // So this game object is disabled and other entity initializations on the start is not happening properly
    private int frameCount = 0;

}
