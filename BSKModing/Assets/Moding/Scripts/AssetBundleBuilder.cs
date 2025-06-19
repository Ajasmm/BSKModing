#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using Unity.Android.Gradle;


public static class AssetBundleBuilder
{
    [MenuItem("Moding/AndroidBuild")]
    public static void AndroidBuild()
    {
        Build(BuildTarget.Android);
    }
    [MenuItem("Moding/WindowsBuild")]
    public static void WindowsBuild()
    {
        Build(BuildTarget.StandaloneWindows);
    }


    private static void Build(BuildTarget buildTarget)
    {
        string assetBundleDirectory = $"Assets/AssetBundles/{(buildTarget == BuildTarget.Android ? "Android" : "Windows")}";
        if(!Directory.Exists(assetBundleDirectory))
            Directory.CreateDirectory(assetBundleDirectory);

        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.ForceRebuildAssetBundle,
                                        buildTarget);
    }
}
#endif