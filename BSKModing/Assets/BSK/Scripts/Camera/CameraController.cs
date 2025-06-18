using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : InputAxisControllerBase<CameraController.CameraAxisReader>
{
    [SerializeField] CinemachineOrbitalFollow orbitalFlowView;
    [SerializeField] CinemachinePanTilt panTiltView;

    public bool invertX;
    public bool invertY;
    public bool invertZ;
    public float3 sencitivity = new float3(1000, 1000, 1);

    

    [Serializable]
    public class CameraAxisReader : IInputAxisReader
    {
        public float GetValue(UnityEngine.Object context, IInputAxisOwner.AxisDescriptor.Hints hint)
        {
            return 0;
        }
    }
}