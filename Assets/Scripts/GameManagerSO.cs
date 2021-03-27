using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu()]
public class GameManagerSO : ScriptableObject
{
    public int s_CurrentLevel = 0;

    public int s_MaxAvailableLevel = 4;

    // The value of -1 means no hats have been purchased
    public int s_ActiveHat = -1;

    public void OnEnable()
    {
        // When we go to the 
        s_CurrentLevel = 0;
    }

    public void ExitGame()
    {
        s_CurrentLevel = 0;
    }

    public void LoadNextLevel()
    {
        // We are going to be using the Addressables API to manage our scene loading and unloading, the equivalent way on the UnityEngine.SceneManagement API is:
        // SceneManager.LoadSceneAsync("LoadingScene", LoadSceneMode.Single);

        // Scene loaded in Single mode, the previously loaded scenes will be disposed by the Addressables.
        Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }

    public void LevelCompleted()
    {
        s_CurrentLevel++;

        // Just to make sure we don't try to go beyond the allowed number of levels.
        s_CurrentLevel = s_CurrentLevel % s_MaxAvailableLevel;

        LoadNextLevel();
    }

    public void ExitGameplay()
    {
        Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }

    public void LoadStore()
    {
        Addressables.LoadSceneAsync("Store", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }
}
