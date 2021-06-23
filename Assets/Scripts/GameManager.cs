using UnityEngine;
using UnityEngine.AddressableAssets;

public class GameManager : MonoBehaviour
{
    public static int s_CurrentLevel = 0;

    public static int s_MaxAvailableLevel = 4;

    public static int s_ActiveHat;

    public void ExitGame()
    {
        s_CurrentLevel = 0;
    }

    public static void LoadNextLevel()
    {
        // We are going to be using the Addressables API to manage our scene loading and unloading, the equivalent way on the UnityEngine.SceneManagement API is:
        // SceneManager.LoadSceneAsync("LoadingScene", LoadSceneMode.Single);

        // Scene loaded in Single mode, the previously loaded scenes will be disposed by the Addressables.
        Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }

    public static void LevelCompleted()
    {
        s_CurrentLevel++;

        // Just to make sure we don't try to go beyond the allowed number of levels.
        s_CurrentLevel = s_CurrentLevel % s_MaxAvailableLevel;

        LoadNextLevel();
    }

    public static void ExitGameplay()
    {
        Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }
}
