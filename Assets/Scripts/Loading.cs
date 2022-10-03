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

    private string language;

    void OnEnable()
    {
        m_SceneHandle = Addressables.DownloadDependenciesAsync("Level_0" + GameManager.s_CurrentLevel);
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
            /*language = ApplyRemoteConfigSettings.Instance.language;

            if (language == "English")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Play";
                m_LoadingText.GetComponent<Text>().text = "Loading...";
            }
            else if (language == "Spanish")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Jugar";
                m_LoadingText.GetComponent<Text>().text = "Cargando...";
            }
            else if (language == "French")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Jouer";
                m_LoadingText.GetComponent<Text>().text = "Chargement...";
            }
            else if (language == "German")
            {
                m_PlayButton.GetComponentInChildren<Text>().text = "Abspielen";
                m_LoadingText.GetComponent<Text>().text = "Die Beladung...";
            }*/
            
            m_PlayButton.SetActive(true);
        }
    }

    // Function to handle which level is loaded next
    public void GoToNextLevel()
    {
        Addressables.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel, UnityEngine.SceneManagement.LoadSceneMode.Single, true);

        
        /*Addressables.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel, UnityEngine.SceneManagement.LoadSceneMode.Single, true);
        
        if(ApplyRemoteConfigSettings.Instance.season == "Default")
        {
            Addressables.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel, UnityEngine.SceneManagement.LoadSceneMode.Single, true);
        }
        
        // Else If the season is supposed to be Winter
        else if (ApplyRemoteConfigSettings.Instance.season == "Winter")
        {
            Debug.LogError("InsideGoToNextLevel()");
            Addressables.LoadSceneAsync("Level_0" + "4", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
        }

        // Else If the season is supposed to be Halloween
        else if (ApplyRemoteConfigSettings.Instance.season == "Halloween")
        {
            Debug.LogError("InsideGoToNextLevel()");
            Addressables.LoadSceneAsync("Level_0" + "2", UnityEngine.SceneManagement.LoadSceneMode.Single, true);
        }*/
    }

    private void Update()
    {
        // We don't need to check for this value every single frame, and certainly not after the scene has been loaded
        m_LoadingSlider.value = m_SceneHandle.GetDownloadStatus().Percent;
    }
}
