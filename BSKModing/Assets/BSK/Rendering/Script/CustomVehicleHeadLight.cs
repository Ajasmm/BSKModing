using System.Collections.Generic;
using System;
using UnityEngine;

[ExecuteAlways]
public class CustomVehicleHeadLight : MonoBehaviour
{
    

    [Header("Dim Data")]
    public float xRotDim = 11;
    public VehicleHeadLightData dimData;
    [Header("Bright Data")]
    public float xRotBright = 11;
    public VehicleHeadLightData brightData;
    [Header("Gizmos")]
    public bool drawDim = false;


    public bool isBright;
    

    void OnDrawGizmos()
    {
        var data = drawDim ? dimData : brightData;

        Vector3 pos;
        Quaternion rot;
        transform.GetPositionAndRotation(out pos, out rot);
        Gizmos.matrix = transform.localToWorldMatrix;

        // Draw the frustum as Unity does for cameras
        float halfFov = data.fov * 0.5f * Mathf.Deg2Rad;
        float nearHeight = Mathf.Tan(halfFov) * data.nearClip;
        float nearWidth = nearHeight * data.aspect;

        float farHeight = Mathf.Tan(halfFov) * data.farClip;
        float farWidth = farHeight * data.aspect;

        // 8 points
        Vector3[] pts = new Vector3[8];

        // Near plane
        pts[0] = new Vector3(-nearWidth, -nearHeight, data.nearClip);
        pts[1] = new Vector3(nearWidth, -nearHeight, data.nearClip);
        pts[2] = new Vector3(nearWidth, nearHeight, data.nearClip);
        pts[3] = new Vector3(-nearWidth, nearHeight, data.nearClip);

        // Far plane
        pts[4] = new Vector3(-farWidth, -farHeight, data.farClip);
        pts[5] = new Vector3(farWidth, -farHeight, data.farClip);
        pts[6] = new Vector3(farWidth, farHeight, data.farClip);
        pts[7] = new Vector3(-farWidth, farHeight, data.farClip);

        Gizmos.color = Color.yellow;

        // Draw near
        Gizmos.DrawLine(pts[0], pts[1]);
        Gizmos.DrawLine(pts[1], pts[2]);
        Gizmos.DrawLine(pts[2], pts[3]);
        Gizmos.DrawLine(pts[3], pts[0]);

        // Draw far
        Gizmos.DrawLine(pts[4], pts[5]);
        Gizmos.DrawLine(pts[5], pts[6]);
        Gizmos.DrawLine(pts[6], pts[7]);
        Gizmos.DrawLine(pts[7], pts[4]);

        // Connect edges
        Gizmos.DrawLine(pts[0], pts[4]);
        Gizmos.DrawLine(pts[1], pts[5]);
        Gizmos.DrawLine(pts[2], pts[6]);
        Gizmos.DrawLine(pts[3], pts[7]);

        Gizmos.matrix = Matrix4x4.identity;
    }

    [Serializable]
    public struct VehicleHeadLightData
    {
        public float fov;
        public float aspect;
        public float nearClip;
        public float farClip;
        public Color color;
        public float intencity;
        public VehicleHeadLightData(float ignoreValue = 0)
        {
            fov = 45; // or custom
            aspect = 1.0f;
            nearClip = 0.1f;
            farClip = 50;
            color = Color.white;
            intencity = 1;
        }
    }
}
