using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Loading : MonoBehaviour
{
    private bool m_LoadingComplete = false;

    [SerializeField]
    private Slider m_LoadingSlider;

    [SerializeField]
    private GameObject m_PlayButton;

    // TODO: Maybe just have it inside the Start method and not class-wide
    AsyncOperationHandle m_SceneHandle;

    // Start is called before the first frame update
    void OnEnable()
    {
        m_SceneHandle = Addressables.DownloadDependenciesAsync("Level_0" + GameManager.s_CurrentLevel);
        m_SceneHandle.Completed += OnSceneLoaded;
    }

    private void OnDisable()
    {
        m_SceneHandle.Completed -= OnSceneLoaded;
    }

    private void OnSceneLoaded(AsyncOperationHandle obj)
    {
        // The scene is loaded, show the button and now turn the scene on?
        m_PlayButton.SetActive(true);

        //m_LoadingComplete = true;
    }

    public void GoToNextLevel()
    {
        Addressables.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel, UnityEngine.SceneManagement.LoadSceneMode.Single, true);
     }

    private void Update()
    {
        // TODO: Comment the range of the percentcomplete
        //if (!m_LoadingComplete)
        {
            m_LoadingSlider.value = m_SceneHandle.PercentComplete;
        }
    }

    //Make the oncomplete 
}
