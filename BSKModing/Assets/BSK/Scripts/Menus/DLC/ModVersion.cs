using UnityEngine;

[CreateAssetMenu(menuName ="Mods/Version", fileName ="versionAsset")]
public class ModVersion : ScriptableObject
{
    [SerializeField] public Version version = new Version("3.0.1");
    [SerializeField] public Sprite icon;
    [SerializeField] public string modName;
    [SerializeField] public string teamName;
    [SerializeField] public string description;
    [SerializeField] public string youtubeLink;
    [SerializeField] public string supportLink;
}
