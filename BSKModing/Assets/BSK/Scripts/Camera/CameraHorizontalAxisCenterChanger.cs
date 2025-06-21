using BSK.Vehicles;
using Unity.Cinemachine;
using UnityEngine;

public class CameraHorizontalAxisCenterChanger : MonoBehaviour
{
    [SerializeField] Vehicle m_Vehicle;
    [SerializeField] CinemachineOrbitalFollow m_OrbitalFlow;
    [SerializeField] float forwardCenter;
    [SerializeField] float reverceCenter;
}
