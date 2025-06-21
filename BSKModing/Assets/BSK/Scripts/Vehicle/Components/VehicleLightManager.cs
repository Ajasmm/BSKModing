using System.Collections.Generic;
using System.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] public MeshRenderer[] parkLightMeshes;
        [SerializeField] public Material[] parkLightMaterials;
        [SerializeField] public MonoBehaviour[] parkLightsComponent;
        [SerializeField] public GameObject[] parkLightObjects;
        [Header("Dim Lighst", order = 1)]
        [SerializeField] public MeshRenderer[] dimLightMeshes;
        [SerializeField] public Material[] dimLightMaterials;
        [SerializeField] public MonoBehaviour[] dimLightsComponent;
        [SerializeField] public GameObject[] dimLightObjects;
        [Header("Bright Lights", order = 1)]
        [SerializeField] public MeshRenderer[] brightLightMeshes;
        [SerializeField] public Material[] brightLightMaterials;
        [SerializeField] public MonoBehaviour[] brightLightsComponent;
        [SerializeField] public GameObject[] brightLightObjects;

        [Header("Indicators", order = 0)]
        [Header("Left Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] leftIndicatorMeshes;
        [SerializeField] public Material[] leftIndicatorMaterials;
        [SerializeField] public MonoBehaviour[] leftIndicatorsComponent;
        [SerializeField] public GameObject[] leftIndicatorLightObjects;
        [Header("Right Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] rightIndicatorMeshes;
        [SerializeField] public Material[] rightIndicatorMaterials;
        [SerializeField] public MonoBehaviour[] rightIndicatorsComponent;
        [SerializeField] public GameObject[] rightIndicatorLightObjects;
        [Header("Hazard Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] hazardIndicatorMeshes;
        [SerializeField] public Material[] hazardIndicatorMaterials;
        [SerializeField] public MonoBehaviour[] hazardIndicatorsComponent;
        [SerializeField] public GameObject[] hazardIndicatorLightObjects;

        [Header("Brake Lights")]
        [SerializeField] public MeshRenderer[] brakeLightMeshes;
        [SerializeField] public Material[] brakeLightMaterials;
        [SerializeField] public MonoBehaviour[] brakeLightsComponent;
        [SerializeField] public GameObject[] brakeLightObjects;

        [Header("Reverce Lights")]
        [SerializeField] public MeshRenderer[] reverceLightMeshes;
        [SerializeField] public Material[] reverceLightMaterials;
        [SerializeField] public MonoBehaviour[] reverceLightsComponent;
        [SerializeField] public GameObject[] reverceLightObjects;


    }
}