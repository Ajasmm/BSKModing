using System;
using Unity.Entities.UniversalDelegates;
using UnityEditor;
using UnityEngine;

namespace BSK.Vehicles
{
    [CreateAssetMenu(menuName = "Vehicle/GearboxConfig", fileName = "_GearboxConfig")]
    public class GearboxConfig : ScriptableObject
    {
        public float finalRatio;
        public float reverceGear;
        public GearRatio[] ratios;

        [Header("Editor Only")]
        public float wheelRadius_Editor;
        public int gearUpRPM_Editor;
        public int gearDownRPM_Editor;
        public int targetRPMOnGearUP_Editor;
    }
    [Serializable]
    public struct GearRatio
    {
        public float ratio;
        public float gearDownSpeed;
        public float gearUpSpeed;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GearboxConfig))]
    public class GearboxConfigInspector : Editor
    {
        GearboxConfig config;
        private void OnEnable()
        {
            config = (GearboxConfig)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Update"))
            {
                float gearUpSpeed;
                GearRatio currentRatio = config.ratios[0];

                gearUpSpeed = config.gearUpRPM_Editor / currentRatio.ratio;
                gearUpSpeed /= config.finalRatio;
                gearUpSpeed *= (2 * Mathf.PI * config.wheelRadius_Editor);
                gearUpSpeed *= 60;
                gearUpSpeed /= 1000;
                currentRatio.gearUpSpeed = gearUpSpeed;

                config.ratios[0] = currentRatio;

                for (int i = 1; i < config.ratios.Length; i++)
                {
                    float wheelPeremeter = (2 * Mathf.PI * config.wheelRadius_Editor);
                    currentRatio = config.ratios[i];
                    float previousGearTopSpeed = config.ratios[i - 1].gearUpSpeed;
                    float ratio = previousGearTopSpeed * 1000;
                    ratio /= 60;
                    ratio /= wheelPeremeter;
                    ratio *= config.finalRatio;
                    ratio = config.targetRPMOnGearUP_Editor / ratio;

                    currentRatio.ratio = ratio;

                    gearUpSpeed= config.gearUpRPM_Editor / ratio;
                    gearUpSpeed /= config.finalRatio;
                    gearUpSpeed *= (2 * Mathf.PI * config.wheelRadius_Editor);
                    gearUpSpeed *= 60;
                    gearUpSpeed /= 1000;
                    currentRatio.gearUpSpeed = gearUpSpeed;

                    currentRatio.gearDownSpeed = ((config.gearDownRPM_Editor / currentRatio.ratio / config.finalRatio) * wheelPeremeter * 60) / 1000;
                    config.ratios[i] = currentRatio;
                }
            }
        }

        
    }
#endif
}