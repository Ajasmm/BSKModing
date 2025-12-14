using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleCameraSwitcher : MonoBehaviour
{
    public static event Action On360Cam;

    [SerializeField] CinemachineCamera[] cameras;
    [SerializeField] CameraController[] cameraControllers;
    [SerializeField] int index360Cam = 3;
}
