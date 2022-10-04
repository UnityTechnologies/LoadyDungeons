using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// Used for the Hat selection logic
public class PlayerConfigurator : MonoBehaviour
{
    [SerializeField]
    private Transform m_HatAnchor;

    private AsyncOperationHandle m_HatLoadingHandle;

    private ApplyRemoteConfigSettings remoteConfigScript;

    void Start()
    {   
        // Get the instance of ApplyRemoteConfigSettings
        remoteConfigScript = ApplyRemoteConfigSettings.Instance;

        // Call the FetchConfigs() to see if there's any new settings
        //remoteConfigScript.FetchConfigs();
        
        //If the condition is met, then a hat has been unlocked
        SetHat(string.Format("Hat{0:00}", ApplyRemoteConfigSettings.Instance.activeHat));
    }

    public void SetHat(string hatKey)
    {
        // We are using the InstantiateAsync function on the Addressables API, the non-Addressables way 
        // looks something like the following line, however, this version is not Asynchronous
        // GameObject.Instantiate(prefabToInstantiate);
        m_HatLoadingHandle = Addressables.InstantiateAsync(hatKey, m_HatAnchor, false);

        m_HatLoadingHandle.Completed += OnHatInstantiated;
    }

    private void OnDisable()
    {
        m_HatLoadingHandle.Completed -= OnHatInstantiated;
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
