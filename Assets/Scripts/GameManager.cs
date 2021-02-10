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
        s_MainMenuSceneHandle = Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Additive, true);
    }

    // Instance method to get called from a UI raised event
    public static void StartGameplay()
    {
        LoadLoadingScene();
    }

    public static void LoadLoadingScene()
    {
        s_LoadingSceneHandle = Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Additive, false);

        s_LoadingSceneHandle.Completed += OnLoadingSceneLoaded;
    }

    public static void LoadGameplayScene()
    {
        s_GameplaySceneHandle = Addressables.LoadSceneAsync("Level_0" + s_CurrentLevel, UnityEngine.SceneManagement.LoadSceneMode.Additive, false);

        s_CurrentLevel++;

        s_GameplaySceneHandle.Completed += OnGameplayLevelLoaded;
    }

    public void ExitGame()
    {
        //Restore the first level to be played
        s_CurrentLevel = 0;

        Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, true).Completed += OnLoadingSceneLoaded;
    }

    public static void LevelCompleted()
    {
        //TODO: Add handle
        LoadLoadingScene();
    }

    static void OnLoadingSceneLoaded(AsyncOperationHandle<SceneInstance> sceneHandle)
    {
        s_LoadingSceneHandle.Result.ActivateAsync();

        if (s_GameplaySceneHandle.IsValid())
        {
            Debug.Log("Unloaded gameplay scene");   
            Addressables.UnloadSceneAsync(s_GameplaySceneHandle, true);
        }

        if(s_MainMenuSceneHandle.IsValid())
        {
            Debug.Log("Unloaded mainmenu scene");
            Addressables.UnloadSceneAsync(s_MainMenuSceneHandle, true);
        }

        s_LoadingSceneHandle.Completed -= OnLoadingSceneLoaded;
    }

    static void OnGameplayLevelLoaded(AsyncOperationHandle<SceneInstance> sceneHandle)
    {
        s_GameplaySceneHandle.Completed -= OnGameplayLevelLoaded;
    }

    public static void ActivateGameplayScene()
    {
        s_GameplaySceneHandle.Result.ActivateAsync();

        if (s_GameplaySceneHandle.IsValid())
        {
            Addressables.UnloadSceneAsync(s_LoadingSceneHandle);
        }
    }
}
