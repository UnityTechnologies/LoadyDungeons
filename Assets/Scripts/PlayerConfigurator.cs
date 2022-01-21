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
        remoteConfigScript.FetchConfigs();
        
        //If the condition is met, then a hat has been unlocked
        if(GameManager.s_ActiveHat >= 0)
        {
            //SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));

            // Fetch the correct hat variable from the ApplyRemoteConfigSettings instance
            if (ApplyRemoteConfigSettings.Instance.season == "Default")
            {
               //Debug.Log("Formatted String 2 " + string.Format("Hat{0:00}", remoteConfigScript.activeHat));

                SetHat(string.Format("Hat{0:00}", remoteConfigScript.activeHat));
            }

            else if (ApplyRemoteConfigSettings.Instance.season == "Winter")
            {
                SetHat(string.Format("Hat{0:00}", "04"));
            }

            else if (ApplyRemoteConfigSettings.Instance.season == "Halloween")
            {
                SetHat(string.Format("Hat{0:00}", "05"));
            }

            //hatKey is an Addressable Label
            //Debug.Log("Hat String: " + string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));
        }
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
