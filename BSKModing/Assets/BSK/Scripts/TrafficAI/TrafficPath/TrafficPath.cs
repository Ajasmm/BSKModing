using Unity.Collections;
using UnityEngine;
using UnityEngine.Splines;

using UnityEditor;
using Unity.Mathematics;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;


namespace BSK.Traffic
{
    [RequireComponent(typeof(SplineContainer))]
    public class TrafficPath : MonoBehaviour
    {
        [SerializeField] private SplineContainer splineContainer;

    }
}
