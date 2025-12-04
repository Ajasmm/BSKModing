using UnityEngine;

[CreateAssetMenu(menuName ="Mods/Version", fileName ="versionAsset")]
public class ModVersion : ScriptableObject
{
    [SerializeField] public Version version = new Version("3.0.1");
}
