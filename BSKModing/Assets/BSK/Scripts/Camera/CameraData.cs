using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Vehicle/CameraData",fileName ="CameraData")]
public class CameraData : ScriptableObject
{
    public CameraPositionData[] CameraPositionData;
}
