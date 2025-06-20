using System;
using Unity.Entities;
using UnityEngine;

namespace BSK.Vehicles
{

    [Serializable]
    public class VehicleLightInputComponent : IComponentData
    {
        public HeadLightModes headLightModes;
        public IndicatorModes indicatroModes;
        public ToggleModes passLightModes;
    }

    [Serializable]
    public class  VehicleLightComponent : IComponentData
    {
        public VehicleLight parkLight;
        public VehicleLight brightLight;
        public VehicleLight dimLight;

        public VehicleLight leftIndicator;
        public VehicleLight rightIndicator;
        public VehicleLight hazardIndicator;

        public VehicleLight brakeLight;
        public VehicleLight reverceLight;
    }

    [Serializable]
    public class VehicleLight
    {
        public bool isOn = false;
        public Material[] lightMaterials;
        public MonoBehaviour[] lightMonos;
    }
}