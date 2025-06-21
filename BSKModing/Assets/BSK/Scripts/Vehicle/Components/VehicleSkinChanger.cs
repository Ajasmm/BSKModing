using UnityEngine;
using System.Collections.Generic;

public class VehicleSkinChanger : MonoBehaviour, ISkin
{
    const string skinTextureProperty = "_BaseMap";

    [SerializeField] Material[] skinMaterials;

    MeshRenderer[] _meshWithskinTextureMaterials;
    List<Material> _materials = new List<Material>();
    Texture _previousSkin;

    void OnDestroy()
    {
        DestroySkinPreviousSkin();
    }

    private void DestroySkinPreviousSkin()
    {
        if (_previousSkin != null)
            Destroy(_previousSkin);
    }
    public void ChangeSkin(Texture skin)
    {
        _meshWithskinTextureMaterials = GetComponentsInChildren<MeshRenderer>();
        _materials.Clear();

        foreach (var skinMaterial in skinMaterials)
        {
            Material newMaterail = new Material(skinMaterial);
            _materials.Add(newMaterail);
            List<Material> sharedMaterials = new List<Material>();

            foreach (var meshRenderer in _meshWithskinTextureMaterials)
            {
                sharedMaterials.Clear();
                meshRenderer.GetSharedMaterials(sharedMaterials);

                for (int i = 0; i < sharedMaterials.Count; i++)
                {
                    if (sharedMaterials[i] == skinMaterial)
                        sharedMaterials[i] = newMaterail;
                }

                meshRenderer.SetSharedMaterials(sharedMaterials);
            }
        }

        foreach (var sharedMaterial in _materials)
        {
            sharedMaterial.SetTexture(skinTextureProperty, skin);
        }

        skinMaterials = _materials.ToArray();
        DestroySkinPreviousSkin();
        _previousSkin = skin;

    }
}
