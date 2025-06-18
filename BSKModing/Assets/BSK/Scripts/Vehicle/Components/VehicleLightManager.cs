using System.Collections.Generic;
using System.Collections;
using Unity.Entities;
using UnityEngine;

namespace BSK.Vehicles
{
    [RequireComponent(typeof(GameObjectEntity))]
    [RequireComponent(typeof(Vehicle))]
    public class VehicleLightManager : MonoBehaviour
    {
        [Header("Components")]
        public VehicleLightInputComponent driverLightInput;
        public VehicleLightComponent vehicleLightComponent;

        [Header("Head Lights",order = 0)]
        [Header("Park Lights", order = 1)]
        [SerializeField] public MeshRenderer[] parkLights;
        [SerializeField] public Material parkLightMaterial;
        [Header("Dim Lighst", order = 1)]
        [SerializeField] public MeshRenderer[] dimLights;
        [SerializeField] public Material dimLightMaterial;
        [Header("Bright Lights", order = 1)]
        [SerializeField] public MeshRenderer[] brightLights;
        [SerializeField] public Material brightLightMaterial;

        [Header("Indicators", order = 0)]
        [Header("Left Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] leftIndicators;
        [SerializeField] public Material leftIndicatorMaterial;
        [Header("Right Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] rightIndicators;
        [SerializeField] public Material rightIndicatorMaterial;
        [Header("Hazard Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] hazardIndicators;
        [SerializeField] public Material hazardIndicatorMaterial;

        [Header("Brake Lights")]
        [SerializeField] public MeshRenderer[] brakeLights;
        [SerializeField] public Material brakeLightMaterial;

        [Header("Reverce Lights")]
        [SerializeField] public MeshRenderer[] reverceLights;
        [SerializeField] public Material reverceLightMaterial;
    }
}