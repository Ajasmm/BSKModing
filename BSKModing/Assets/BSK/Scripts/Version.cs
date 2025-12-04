using System;
using System.Diagnostics;

[Serializable]
public struct Version : IComparable<Version>
{
    public int majorVerions;
    public int midVersion;
    public int lowerVersion;

    public Version(string version)
    {
        majorVerions = midVersion = lowerVersion = 0;
        try
        {
            string[] versions = version.Split('.');
            UnityEngine.Debug.Log(string.Join(",", versions));
            if (version.Length >= 1)
                int.TryParse(versions[0], out majorVerions);
            if (version.Length >= 2)
                int.TryParse(versions[1], out midVersion);
            if (version.Length >= 3)
                int.TryParse(versions[2], out lowerVersion);
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogException(e);
        }
    }
    public Version(int majorVersion, int midVersion, int lowerVersion)
    {
        this.majorVerions = majorVersion;
        this.midVersion = midVersion;
        this.lowerVersion = lowerVersion;
    }

    public static bool operator >(Version version1, Version version2) => version1.CompareTo(version2) == 1;
    public static bool operator <(Version version1, Version version2) => version1.CompareTo(version2) == -1;
    public static bool operator ==(Version version1, Version version2) => version1.CompareTo(version2) == 0;
    public static bool operator !=(Version version1, Version version2) => version1.CompareTo(version2) != 0;

    public int CompareTo(Version obj)
    {
        if (obj.majorVerions == majorVerions && obj.midVersion == midVersion && obj.lowerVersion == lowerVersion)
            return 0;

        if (majorVerions < obj.majorVerions)
            return -1;
        else if (majorVerions > obj.majorVerions)
            return 1;

        if (midVersion < obj.midVersion)
            return -1;
        else if (midVersion > obj.midVersion)
            return 1;

        if (lowerVersion < obj.lowerVersion)
            return -1;
        else if (lowerVersion > obj.lowerVersion)
            return 1;

        return 1;
    }
    public override string ToString()
    {
        return new string($"{majorVerions}.{midVersion}.{lowerVersion}");
    }
}
