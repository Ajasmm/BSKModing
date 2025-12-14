using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace BSK.Vehicles
{

    [Serializable]
    public class VehicleLightInputComponent : IComponentData
    {
        public HeadLightModes headLightModes;
        public IndicatorModes indicatroModes;
        public ToggleModes passLightModes;
        
        public ToggleModes additionalLight1;
        public ToggleModes additionalLight2;
        public ToggleModes additionalLight3;
    }

    [Serializable]
    public class VehicleLightComponent : IComponentData
    {

        public VehicleHeadLight headLight;
        public VehicleLight parkLight;
        public VehicleLight brightLight;
        public VehicleLight dimLight;


        public VehicleLight leftIndicator;
        public VehicleLight rightIndicator;
        public VehicleLight hazardIndicator;

        public VehicleLight brakeLight;
        public VehicleLight reverceLight;

        public VehicleLight additionalLight1;
        public VehicleLight additionalLight2;
        public VehicleLight additionalLight3;
    }

    [Serializable]
    public class VehicleLight
    {
        public bool isOn = false;
        public List<Material> lightMaterials;
        public UnityEvent OnEvent;
        public UnityEvent OffEvent;
    }
    [Serializable]
    public class VehicleHeadLight
    {
        public CustomVehicleHeadLight headLight;
    }
}