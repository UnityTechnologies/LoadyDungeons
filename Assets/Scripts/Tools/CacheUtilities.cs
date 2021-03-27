using UnityEngine;
using UnityEditor;

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

    [MenuItem("Tools/Cache/Clean Store")]
    public static void CleanStore()
    {
        // TODO: Clean up the current selected store
    }
}