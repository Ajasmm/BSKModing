using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Mirror : MonoBehaviour
{
    [Serializable]
    public class MirrorData
    {
        public Camera cam;
        public Material mirrorMaterial;
        public RenderTexture mirrorTexture;
    }

    [SerializeField] MirrorData[] mirrorDatas;
}
