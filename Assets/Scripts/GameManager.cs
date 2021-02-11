using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class GameManager : MonoBehaviour
{
    public static int s_CurrentLevel = 0;

    // This variable can be tweaked via Remote Config as more levels are available
    public int m_MaxAvailableLevel = 0;

    public static AsyncOperationHandle<SceneInstance> s_GameplaySceneHandle;

    public static AsyncOperationHandle<SceneInstance> s_MainMenuSceneHandle;

    public static AsyncOperationHandle<SceneInstance> s_LoadingSceneHandle;


    private void Start()
    {
        //TODO: subscribe and release handle
        //s_MainMenuSceneHandle = Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Additive, true);
    }

    public void ExitGame()
    {
        //Restore the first level to be played
        s_CurrentLevel = 0;

        //Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, true).Completed += OnLoadingSceneLoaded;
    }

    public static void LoadNextLevel()
    {
        Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }

    public static void LevelCompleted()
    {
        //TODO: Check we are not going beyond the max scene
        s_CurrentLevel++;

        LoadNextLevel();
    }
}
