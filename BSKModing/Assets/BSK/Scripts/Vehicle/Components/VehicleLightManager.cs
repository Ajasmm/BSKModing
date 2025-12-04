using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using BSK.Veghicle;
using System.Linq;
using UnityEngine.Events;

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
        [SerializeField] public UnityEvent OnParkLightOn;
        [SerializeField] public UnityEvent OnParkLightOff;
        [Header("Dim Lighst", order = 1)]
        [SerializeField] public MeshRenderer[] dimLightMeshes;
        [SerializeField] public Material[] dimLightMaterials;
        [SerializeField] public UnityEvent OnDimLightOn;
        [SerializeField] public UnityEvent OnDimLightOff;
        [Header("Bright Lights", order = 1)]
        [SerializeField] public MeshRenderer[] brightLightMeshes;
        [SerializeField] public Material[] brightLightMaterials;
        [SerializeField] public UnityEvent OnBrightLightOn;
        [SerializeField] public UnityEvent OnBrightLightOff;

        [Header("Indicators", order = 0)]
        [Header("Left Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] leftIndicatorMeshes;
        [SerializeField] public Material[] leftIndicatorMaterials;
        [SerializeField] public UnityEvent OnLeftIndicatorOn;
        [SerializeField] public UnityEvent OnLeftIndicatorOff;
        [Header("Right Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] rightIndicatorMeshes;
        [SerializeField] public Material[] rightIndicatorMaterials;
        [SerializeField] public UnityEvent OnRightIndicatorOn;
        [SerializeField] public UnityEvent OnRightIndicatorOff;
        [Header("Hazard Indicators", order = 1)]
        [SerializeField] public MeshRenderer[] hazardIndicatorMeshes;
        [SerializeField] public Material[] hazardIndicatorMaterials;
        [SerializeField] public UnityEvent OnHazardLightOn;
        [SerializeField] public UnityEvent OnHazardLightOff;

        [Header("Brake Lights")]
        [SerializeField] public MeshRenderer[] brakeLightMeshes;
        [SerializeField] public Material[] brakeLightMaterials;
        [SerializeField] public UnityEvent OnBrakeLightOn;
        [SerializeField] public UnityEvent OnBrakeLightOff;

        [Header("Reverce Lights")]
        [SerializeField] public MeshRenderer[] reverceLightMeshes;
        [SerializeField] public Material[] reverceLightMaterials;
        [SerializeField] public UnityEvent OnReveceLightOn;
        [SerializeField] public UnityEvent OnReveceLightOff;

        [Header("Additional Lights1")]
        [SerializeField] public UnityEvent OnAdditionalLight1On;
        [SerializeField] public UnityEvent OnAdditionalLight1Off;
        [Header("Additional Lights2")]
        [SerializeField] public UnityEvent OnAdditionalLight2On;
        [SerializeField] public UnityEvent OnAdditionalLight2Off;

        [Header("Additional Lights3")]
        [SerializeField] public UnityEvent OnAdditionalLight3On;
        [SerializeField] public UnityEvent OnAdditionalLight3Off;

        public bool isInitializationCompleted { get; private set; } = false;
        public bool isAdditionalLight1Avaialable { get; private set; } = false;
        public bool isAdditionalLight2Avaialable { get; private set; } = false;
        public bool isAdditionalLight3Avaialable { get; private set; } = false;

    }
}