using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameManager : MonoBehaviour
{
    public static int s_CurrentLevel = 0;

    // This variable can be tweaked via Remote Config as more levels are available
    public static int s_MaxAvailableLevel = 4;

    public void ExitGame()
    {
        s_CurrentLevel = 0;
    }

    public static void LoadNextLevel()
    {
        Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }

    /// <summary>
    public static void LevelCompleted()
    {
        s_CurrentLevel++;

        // Just to make sure we don't try to go beyond the allowed number of levels.
        s_CurrentLevel = s_CurrentLevel % s_MaxAvailableLevel;

        LoadNextLevel();
    }

    public static void ExitGameplay()
    {
        //TODO: Or load the Loading scene here
        //TODO: Replace string with label
        Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }
}
