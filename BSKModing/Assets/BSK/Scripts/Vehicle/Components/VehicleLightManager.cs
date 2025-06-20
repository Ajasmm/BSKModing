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

        [Header("Head Lights", order = 0)]
        [Header("Park Lights", order = 1)]
        [SerializeField] public MeshRenderer[] parkLights;
        [SerializeField] public Material[] parkLightMaterial;
        [SerializeField] public MonoBehaviour[] parkLightsComponent;
        [Header("Dim Lighst", order = 1)]
        [SerializeField] public MeshRenderer[] dimLights;
        [SerializeField] public Material[] dimLightMaterial;
        [SerializeField] public MonoBehaviour[] dimLightsComponent;
        [Header("Bright Lights", order = 1)]
        [SerializeField] public MeshRenderer[] brightLights;
        [SerializeField] public Material[] brightLightMaterial;
        [SerializeField] public MonoBehaviour[] brightLightsComponent;

        [Header("Indicators", order = 0)]
        [Header("Left Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] leftIndicators;
        [SerializeField] public Material[] leftIndicatorMaterial;
        [SerializeField] public MonoBehaviour[] leftIndicatorsComponent;
        [Header("Right Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] rightIndicators;
        [SerializeField] public Material[] rightIndicatorMaterial;
        [SerializeField] public MonoBehaviour[] rightIndicatorsComponent;
        [Header("Hazard Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] hazardIndicators;
        [SerializeField] public Material[] hazardIndicatorMaterial;
        [SerializeField] public MonoBehaviour[] hazardIndicatorsComponent;

        [Header("Brake Lights")]
        [SerializeField] public MeshRenderer[] brakeLights;
        [SerializeField] public Material[] brakeLightMaterial;
        [SerializeField] public MonoBehaviour[] brakeLightsComponent;

        [Header("Reverce Lights")]
        [SerializeField] public MeshRenderer[] reverceLights;
        [SerializeField] public Material[] reverceLightMaterial;
        [SerializeField] public MonoBehaviour[] reverceLightsComponent;


    }
}