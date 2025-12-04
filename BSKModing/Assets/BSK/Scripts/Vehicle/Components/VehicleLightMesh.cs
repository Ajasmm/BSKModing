using UnityEditor;
using UnityEngine;

namespace BSK.Veghicle
{
    public class VehicleLightMesh : MonoBehaviour
    {
        [SerializeField] public VehicleLightType lightType = VehicleLightType.Park;
        [SerializeField] public MeshRenderer meshRenderer;

#if UNITY_EDITOR
        void OnValidate()
        {

            if (meshRenderer == null || meshRenderer.gameObject != this.gameObject)
            {
                meshRenderer = gameObject.GetComponent<MeshRenderer>();
                EditorUtility.SetDirty(this);
            }
        }
#endif
    }

    public enum VehicleLightType
    {
        Park,
        Dim,
        Bright,
        Left_Indicator,
        Right_Indicator,
        Hazard_Indictor,
        Brake,
        Reverce,
        Additional_Light1,
        Additional_Light2,
        Additional_Light3
    }
}
