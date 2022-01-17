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
    private GameObject m_PlayButton;

    private string language;

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
        // We show the UI button once the scene is successfully downloaded      
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {  
            language = ApplyRemoteConfigSettings.Instance.language;

            if (language == "English")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Play";
            }
            else if (language == "Spanish")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Jugar";
            }
            else if (language == "French")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Jouer";
            }
            else if (language == "German")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Abspielen";
            }
            
            m_PlayButton.SetActive(true);
        }
    }

    public void GoToNextLevel()
    {
        Addressables.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel, UnityEngine.SceneManagement.LoadSceneMode.Single, true);
    }

    private void Update()
    {
        // We don't need to check for this value every single frame, and certainly not after the scene has been loaded
        m_LoadingSlider.value = m_SceneHandle.GetDownloadStatus().Percent;
    }
}
