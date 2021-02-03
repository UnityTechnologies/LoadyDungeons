using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int m_CurrentLevel = 0;

    // This variable can be tweaked via Remote Config as more levels are available
    private int m_MaxAvailableLevel = 0;

    // TODO: Maybe just have it inside the Start method and not class-wide
    AsyncOperationHandle<SceneInstance> m_SceneHandle;


    private void OnDestroy()
    {
        // TODO: Check for null
        //m_SceneHandle.Completed -= OnSceneLoaded;
    }

    public void StartGameplay()
    {
        Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Single, true).Completed += OnSceneLoaded;
    }

    public void ExitGame()
    {
        Addressables.LoadSceneAsync("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, true).Completed += OnSceneLoaded;
    }

    public void LevelCompleted()
    {
        //TODO: Replace this hardcoded code to increase the level
        Debug.Log("Loading next level");

        // Load the Loading scene
        Addressables.LoadSceneAsync("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Single, true);

        //Addressables.UnloadSceneAsync(Scenema)
        //LoadLevel(++currentLevel);
    }

    public void LoadLevel(int levelToLoad)
    {
        Debug.Log("Trying to load scene " + levelToLoad);
        Addressables.LoadSceneAsync("Level_0"+ levelToLoad, UnityEngine.SceneManagement.LoadSceneMode.Additive, true).Completed += OnSceneLoaded;
    }

    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> sceneHandle)
    {
        Debug.Log("Scene Loaded");
    }
}
