using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class NonRainAreaDetector : MonoBehaviour
{
    float rainStrength = 0;
    Material rainMaterial;

    const string noRainAreaProperty = "_isInsideNoRainArea";
    int noRainAreaPropertyID;

    bool isInsideNoRainArea = false;
    void Start()
    {
        MeshRenderer meshRenderer = null;
        gameObject.TryGetComponent<MeshRenderer>(out meshRenderer);
        if (meshRenderer == null)
            Destroy(this);

        rainMaterial = meshRenderer.sharedMaterial;

        noRainAreaPropertyID = Shader.PropertyToID(noRainAreaProperty);
    }

    void Update()
    {
        rainStrength += Time.deltaTime * (isInsideNoRainArea ? 0.2f : -1);
        rainStrength = math.clamp(rainStrength, 0, 1);

        rainMaterial.SetFloat(noRainAreaPropertyID, rainStrength);
    }
    void OnTriggerExit(Collider other)
    {
        isInsideNoRainArea = false;
    }
    void OnTriggerEnter(Collider other)
    {
        isInsideNoRainArea = true;
    }
    void OnTriggerStay(Collider other)
    {
        isInsideNoRainArea = true;
    }
}
