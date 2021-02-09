using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class GameManager : MonoBehaviour
{
    public static int m_CurrentLevel = 0;

    // This variable can be tweaked via Remote Config as more levels are available
    public int m_MaxAvailableLevel = 0;

    // TODO: Maybe just have it inside the Start method and not class-wide
    private static AsyncOperationHandle<SceneInstance> m_GameplaySceneHandle;

    private static AsyncOperationHandle<SceneInstance> m_LoadingSceneHandle;


    //private void OnDestroy()
    //{
    //    // TODO: Check for null
    //    //m_SceneHandle.Completed -= OnSceneLoaded;
    //}

    // Instance method to get called from a UI raised event
    public void StartGameplay()
    {
        LoadLoadingScene();
    }

    public static void LoadLoadingScene()
    {
        // TODO: Add handle
        m_LoadingSceneHandle = Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Additive, false);

        m_LoadingSceneHandle.Completed += OnLoadingSceneLoaded;
    }

    public static void LoadGameplayScene()
    {
        m_GameplaySceneHandle = Addressables.LoadSceneAsync("Level_0" + m_CurrentLevel, UnityEngine.SceneManagement.LoadSceneMode.Additive, false);

        m_CurrentLevel++;

        m_GameplaySceneHandle.Completed += OnGameplayLevelLoaded;
    }

    public void ExitGame()
    {
        //Restore the first level to be played
        m_CurrentLevel = 0;

        Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, true).Completed += OnLoadingSceneLoaded;
    }

    public void LevelCompleted()
    {
        //TODO: Add handle
        LoadLoadingScene();
    }

    static void OnLoadingSceneLoaded(AsyncOperationHandle<SceneInstance> sceneHandle)
    {
        sceneHandle.Result.ActivateAsync();

        //if (m_GameplaySceneHandle.IsValid())
        //{
        //    Addressables.UnloadSceneAsync(m_GameplaySceneHandle);
        //}
        m_LoadingSceneHandle.Completed -= OnLoadingSceneLoaded;
    }

    static void OnGameplayLevelLoaded(AsyncOperationHandle<SceneInstance> sceneHandle)
    {
        sceneHandle.Result.ActivateAsync();

        if (m_GameplaySceneHandle.IsValid())
        {
            Addressables.UnloadSceneAsync(m_LoadingSceneHandle);
        }
        //m_GameplaySceneHandle.Completed -= OnGameplayLevelLoaded;
    }
}
