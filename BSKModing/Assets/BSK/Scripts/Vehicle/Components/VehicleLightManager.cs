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


        private void Start()
        {
            VehicleLightMesh[] lights = GetComponentsInChildren<VehicleLightMesh>();

            vehicleLightComponent.parkLight.lightMaterials = AssignNewMaterial(parkLightMaterials, parkLightMeshes);
            vehicleLightComponent.parkLight.lightMaterials =
            CreateLegacyList(vehicleLightComponent.parkLight.lightMaterials, lights, VehicleLightType.Park);
            vehicleLightComponent.parkLight.OnEvent = OnParkLightOn;
            vehicleLightComponent.parkLight.OffEvent = OnParkLightOff;

            vehicleLightComponent.dimLight.lightMaterials = AssignNewMaterial(dimLightMaterials, dimLightMeshes);
            vehicleLightComponent.dimLight.lightMaterials =
            CreateLegacyList(vehicleLightComponent.dimLight.lightMaterials, lights, VehicleLightType.Dim);
            vehicleLightComponent.dimLight.OnEvent = OnDimLightOn;
            vehicleLightComponent.dimLight.OffEvent = OnDimLightOff;

            vehicleLightComponent.brightLight.lightMaterials = AssignNewMaterial(brightLightMaterials, brightLightMeshes);
            vehicleLightComponent.brightLight.lightMaterials =
            CreateLegacyList(vehicleLightComponent.brightLight.lightMaterials, lights, VehicleLightType.Bright);
            vehicleLightComponent.brightLight.OnEvent = OnBrightLightOn;
            vehicleLightComponent.brightLight.OffEvent = OnBrightLightOff;

            vehicleLightComponent.leftIndicator.lightMaterials = AssignNewMaterial(leftIndicatorMaterials, leftIndicatorMeshes);
            vehicleLightComponent.leftIndicator.lightMaterials =
            CreateLegacyList(vehicleLightComponent.leftIndicator.lightMaterials, lights, VehicleLightType.Left_Indicator);
            vehicleLightComponent.leftIndicator.OnEvent = OnLeftIndicatorOn;
            vehicleLightComponent.leftIndicator.OffEvent = OnLeftIndicatorOff;

            vehicleLightComponent.rightIndicator.lightMaterials = AssignNewMaterial(rightIndicatorMaterials, rightIndicatorMeshes);
            vehicleLightComponent.rightIndicator.lightMaterials =
            CreateLegacyList(vehicleLightComponent.rightIndicator.lightMaterials, lights, VehicleLightType.Right_Indicator);
            vehicleLightComponent.rightIndicator.OnEvent = OnRightIndicatorOn;
            vehicleLightComponent.rightIndicator.OffEvent = OnRightIndicatorOff;

            vehicleLightComponent.hazardIndicator.lightMaterials = AssignNewMaterial(hazardIndicatorMaterials, hazardIndicatorMeshes);
            vehicleLightComponent.hazardIndicator.lightMaterials =
            CreateLegacyList(vehicleLightComponent.hazardIndicator.lightMaterials, lights, VehicleLightType.Hazard_Indictor);
            vehicleLightComponent.hazardIndicator.OnEvent = OnHazardLightOn;
            vehicleLightComponent.hazardIndicator.OffEvent = OnHazardLightOff;

            vehicleLightComponent.brakeLight.lightMaterials = AssignNewMaterial(brakeLightMaterials, brakeLightMeshes);
            vehicleLightComponent.brakeLight.lightMaterials =
            CreateLegacyList(vehicleLightComponent.brakeLight.lightMaterials, lights, VehicleLightType.Brake);
            vehicleLightComponent.brakeLight.OnEvent = OnBrakeLightOn;
            vehicleLightComponent.brakeLight.OffEvent = OnBrakeLightOff;

            vehicleLightComponent.reverceLight.lightMaterials = AssignNewMaterial(reverceLightMaterials, reverceLightMeshes);
            vehicleLightComponent.reverceLight.lightMaterials =
            CreateLegacyList(vehicleLightComponent.reverceLight.lightMaterials, lights, VehicleLightType.Reverce);
            vehicleLightComponent.reverceLight.OnEvent = OnReveceLightOn;
            vehicleLightComponent.reverceLight.OffEvent = OnReveceLightOff;


            vehicleLightComponent.additionalLight1.lightMaterials =
            CreateLegacyList(vehicleLightComponent.additionalLight1.lightMaterials, lights, VehicleLightType.Additional_Light1);
            isAdditionalLight1Avaialable = vehicleLightComponent.additionalLight1.lightMaterials.Count > 0;
            vehicleLightComponent.additionalLight1.OnEvent = OnAdditionalLight1On;
            vehicleLightComponent.additionalLight1.OffEvent = OnAdditionalLight1Off;

            vehicleLightComponent.additionalLight2.lightMaterials =
            CreateLegacyList(vehicleLightComponent.additionalLight2.lightMaterials, lights, VehicleLightType.Additional_Light2);
            isAdditionalLight2Avaialable = vehicleLightComponent.additionalLight2.lightMaterials.Count > 0;
            vehicleLightComponent.additionalLight2.OnEvent = OnAdditionalLight2On;
            vehicleLightComponent.additionalLight2.OffEvent = OnAdditionalLight2Off;

            vehicleLightComponent.additionalLight3.lightMaterials =
            CreateLegacyList(vehicleLightComponent.additionalLight3.lightMaterials, lights, VehicleLightType.Additional_Light3);
            isAdditionalLight3Avaialable = vehicleLightComponent.additionalLight3.lightMaterials.Count > 0;
            vehicleLightComponent.additionalLight3.OnEvent = OnAdditionalLight3On;
            vehicleLightComponent.additionalLight3.OffEvent = OnAdditionalLight3Off;

            var gameObjectEntity = gameObject.GetComponent<GameObjectEntity>();
            gameObjectEntity.entityManager.AddComponentData<VehicleLightInputComponent>(gameObjectEntity.entity, driverLightInput);
            gameObjectEntity.entityManager.AddComponentData<VehicleLightComponent>(gameObjectEntity.entity, vehicleLightComponent);
            isInitializationCompleted = true;
        }

        private static List<Material> AssignNewMaterial(Material[] materials, MeshRenderer[] meshRenderers)
        {
            List<Material> result = new List<Material>(1);

            if (meshRenderers == null || meshRenderers.Length == 0)
                return new(0);

            if (materials == null || materials.Length == 0)
                return new(0);

            List<Material> sharedMaterials = new List<Material>();
            Material material = null;

            for (int i = 0; i < materials.Length; i++)
            {
                material = materials[i];

                if (material == null)
                    continue;

                Material newMaterial = new Material(material);
                result.Add(newMaterial);

                foreach (var renderer in meshRenderers)
                {
                    sharedMaterials.Clear();
                    renderer.GetSharedMaterials(sharedMaterials);
                    for (int j = 0; j < sharedMaterials.Count; j++)
                    {
                        if (sharedMaterials[j] == material)
                            sharedMaterials[j] = newMaterial;
                    }
                    renderer.SetSharedMaterials(sharedMaterials);
                }
            }
            return result;
        }
        private static List<Material> CreateLegacyList(List<Material> existingMaterials, VehicleLightMesh[] lights, VehicleLightType targetLightType)
        {
            HashSet<Material> materialSet = new();
            HashSet<MeshRenderer> renderersSet = new();

            foreach (var light in lights)
            {
                if (light.lightType != targetLightType)
                    continue;

                materialSet.Add(light.meshRenderer.sharedMaterial);
                renderersSet.Add(light.meshRenderer);
            }

            var materials = materialSet.ToArray();
            var renderers = renderersSet.ToArray();

            var newList = AssignNewMaterial(materials, renderers);

            if (existingMaterials == null)
                existingMaterials = new();

            foreach (var material in newList)
                existingMaterials.Add(material);

            return existingMaterials;
        }
    }
}