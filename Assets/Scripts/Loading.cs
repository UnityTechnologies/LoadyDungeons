using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Loading : MonoBehaviour
{
    private AsyncOperationHandle m_SceneHandle;

    [SerializeField]
    private Slider m_LoadingSlider;

    [SerializeField]
    private GameObject m_PlayButton, m_LoadingText;

    private string sceneAddressToLoad;

    void OnEnable()
    {
        if (ApplyRemoteConfigSettings.Instance.season == "Winter")
        {
            sceneAddressToLoad = "Level_04";
        }
        else
        {
            sceneAddressToLoad = "Level_0" + GameManager.s_CurrentLevel;
        }
        
        m_SceneHandle = Addressables.DownloadDependenciesAsync(sceneAddressToLoad);
        m_SceneHandle.Completed += OnSceneLoaded;
        
        Debug.Log("Loading dependencies for level: " + GameManager.s_CurrentLevel);
    }

    private void OnDisable()
    {
        m_SceneHandle.Completed -= OnSceneLoaded;
    }

    private void OnSceneLoaded(AsyncOperationHandle obj)
    {
        // We show the UI button once the scene is successfully downloaded      
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            m_PlayButton.SetActive(true);
        }
    }

    // Function to handle which level is loaded next
    public void GoToNextLevel()
    {
        Addressables.LoadSceneAsync(sceneAddressToLoad, UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }

    private void Update()
    {
        // We don't need to check for this value every single frame, and certainly not after the scene has been loaded
        m_LoadingSlider.value = m_SceneHandle.GetDownloadStatus().Percent;
    }
}
