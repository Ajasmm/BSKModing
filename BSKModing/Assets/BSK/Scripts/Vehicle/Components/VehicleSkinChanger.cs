using UnityEngine;
using System.Collections.Generic;

public class VehicleSkinChanger : MonoBehaviour, ISkin
{
    const string skinTextureProperty = "_BaseMap";

    [SerializeField] Material[] skinMaterials;

    public void ChangeSkin(Texture skin)
    {

    }
}
