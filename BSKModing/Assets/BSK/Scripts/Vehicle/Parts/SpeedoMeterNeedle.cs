using Unity.Mathematics;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class SpeedoMeterNeedle : MonoBehaviour
{
    [SerializeField] public NeedleType needleType = NeedleType.SpeedoMeter;
    [SerializeField] Quaternion startRotation;
    [SerializeField] float maxRotation;
    [SerializeField] public float maxValue = 150;
    [SerializeField] bool inverse = false;

    Transform mTransform;


    async void Start()
    {
        mTransform = transform;
    }

#if UNITY_EDITOR
    [SerializeField] bool debugMod = false;
    [SerializeField] float debugValue = -1;
    void Update()
    {
        if (!debugMod)
            return;

        UpdateNeedle(debugValue);
    }
#endif

    public void UpdateNeedle(float value)
    {
        value = math.clamp(value, 0, maxValue);
        UpdateNeedleInternal(math.unlerp(0, maxValue, value));
    }
    private void UpdateNeedleInternal(float value)
    {
        mTransform.localRotation = startRotation;
        mTransform.Rotate(Vector3.up, math.lerp(0, maxRotation, value), Space.Self);
    }

    public enum NeedleType
    {
        SpeedoMeter,
        RPMMeter,
        FuelMeter
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(SpeedoMeterNeedle))]
    private class NeedleCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Record startRot"))
            {
                var needle = target as SpeedoMeterNeedle;
                if (needle == null)
                    return;

                Undo.RecordObject(needle, "startRot");
                needle.startRotation = needle.transform.localRotation;
                EditorUtility.SetDirty(needle);
            }
            if (GUILayout.Button("Record endRot"))
            {
                var needle = target as SpeedoMeterNeedle;
                if (needle == null)
                    return;
                Undo.RecordObject(needle, "endRot");
                needle.maxRotation = needle.inverse ?
                360 - Quaternion.Angle(needle.startRotation, needle.transform.rotation) :
                Quaternion.Angle(needle.startRotation, needle.transform.rotation);
                EditorUtility.SetDirty(needle);
            }
        }
    }
#endif
}
