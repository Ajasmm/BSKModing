using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : InputAxisControllerBase<CameraController.CameraAxisReader>
{
    [SerializeField] CinemachineOrbitalFollow orbitalFlowView;
    [SerializeField] CinemachinePanTilt panTiltView;
    [SerializeField] CinemachineFollow follow;

    [Header("Pan Tilt Cam Z offset")]
    [SerializeField] private bool enableMovement = false;
    [SerializeField] private float minZOffset = 0;
    [SerializeField] private float maxZOffset = 0;
    [SerializeField] private float zCenter = 0;

    public bool invertX;
    public bool invertY;
    public bool invertZ;
    public float3 sencitivity = new float3(1000, 1000, 1);

    public CameraTouchPad touchPad;

    [Serializable]
    public class CameraAxisReader : IInputAxisReader
    {
        CameraController controller;
        CameraTouchPad touchPad;

        public float GetValue(UnityEngine.Object context, IInputAxisOwner.AxisDescriptor.Hints hint)
        {
            
            return 0;
        }
    }
}