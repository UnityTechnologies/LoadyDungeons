using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerConfigurator : MonoBehaviour
{
    [SerializeField]
    private Transform m_HatAnchor;

    private AsyncOperationHandle m_HatLoadingHandle;

    void Start()
    {
        // At the moment, we randomly assign a Hat, but ideally, we have the unlocked hat property saved
        SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));
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
    }
}
