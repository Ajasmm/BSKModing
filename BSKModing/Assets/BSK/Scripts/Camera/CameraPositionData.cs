using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct CameraPositionData
{
    public CameraPosition camPosition;
    public Vector3 cameraOffset;
    public float sencitivity;

    [Header("InsideCameraData")]
    public Vector3 defalultRotation;
    public Vector3 maxAngle;

    [Header("OutSideCameraData")]
    public Vector3 lookOffset;
    public float distanceCap;
    public bool rotationEnabled;
}

[Serializable]
public enum CameraPosition
{
    InSide,
    OutSide
}
