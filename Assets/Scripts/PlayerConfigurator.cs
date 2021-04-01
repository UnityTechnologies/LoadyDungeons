using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerConfigurator : MonoBehaviour
{
    [SerializeField]
    private Transform m_HatAnchor;

    [SerializeField]
    private GameManagerSO m_GameManager;

    private AsyncOperationHandle m_HatLoadingHandle;

    void Start()
    {
        // TODO: Implement a m_GameManager.HatsUnlocked method on the GameManager script
        //If the condition is met, then a hat has been unlocked
        if(m_GameManager.s_ActiveHat >= 0)
        {
            SetHat(string.Format("Hat{0:00}", m_GameManager.s_ActiveHat));
        }
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
