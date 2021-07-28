using UnityEngine;
using Unity.RemoteConfig; // We need this namespace for remotely configuring our selected hat
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerConfigurator : MonoBehaviour
{
    [SerializeField]
    private Transform m_HatAnchor;

    [SerializeField]
    private GameManagerSO m_GameManager;

    private AsyncOperationHandle m_HatLoadingHandle;

    public struct userAttributes
    {
        // Optionally declare variables for any custom user attributes:
        public bool expansionFlag;
    }

    public struct appAttributes
    {
        // Optionally declare variables for any custom app attributes:
        public int level;
        public int score;
        public string appVersion;
    }


    void Start()
    {
        ConfigManager.FetchCompleted += ApplyRemoteSettings;

        ConfigManager.SetEnvironmentID("5bd6cbe9-1b79-4a51-b22b-59f547eaaf1a");

        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());

        // TODO: Implement a m_GameManager.HatsUnlocked method on the GameManager script
        //If the condition is met, then a hat has been unlocked
        //if(m_GameManager.s_ActiveHat >= 0)
        //{
        //    SetHat(string.Format("Hat{0:00}", m_GameManager.s_ActiveHat));
        //}
    }

    // TODO: Change the string parameter 
    public void SetHat(string hatKey)
    {
        // We are using the InstantiateAsync function on the Addressables API, the non-Addressables way 
        // looks something like the following line, however, this version is not Asynchronous
        // GameObject.Instantiate(prefabToInstantiate);
        m_HatLoadingHandle = Addressables.InstantiateAsync(hatKey, m_HatAnchor, false);

        m_HatLoadingHandle.Completed += OnHatInstantiated;
    }

    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        m_GameManager.s_ActiveHat = ConfigManager.appConfig.GetInt("Selected_Hat");

        SetHat(string.Format("Hat{0:00}", m_GameManager.s_ActiveHat));
    }

    private void OnHatInstantiated(AsyncOperationHandle obj)
    {
        // We can check for the status of the InstantiationAsync operation: Failed, Succeeded or None
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Hat instantiated successfully");
        }

        m_HatLoadingHandle.Completed -= OnHatInstantiated;
    }
}
