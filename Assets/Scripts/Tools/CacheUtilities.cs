using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
// Based on this script by kimsama: https://gist.github.com/kimsama/5530104
public class CacheTools : ScriptableObject
{
    [MenuItem("Tools/Cache/Clean Cache")]
    public static void CleanCache()
    {
        if (Caching.ClearCache())
        {
            Debug.LogWarning("Successfully cleaned all caches.");
        }
        else
        {
            Debug.LogWarning("Cache was in use.");
        }
    }
}
#endif