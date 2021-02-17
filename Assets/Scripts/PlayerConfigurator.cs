using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerConfigurator : MonoBehaviour
{
    [SerializeField]
    private Transform m_HatAnchor;

    void Start()
    {
        //TODO: Remove this random stuff, just for testing atm
        SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));
    }

    // TODO: Change the string parameter 
    public void SetHat(string hatKey)
    {
        // We are using the InstantiateAsync function on the Addressables API, the non-Addressables way 
        // looks something like the following line, however, this version is not Asynchronous
        // GameObject.Instantiate(prefabToInstantiate);

        Addressables.InstantiateAsync(hatKey, m_HatAnchor, false).Completed += OnHatInstantiated;
    }

    private void OnDisable()
    {
        // TODO: Unsubscribe
    }

    // TOASK: Where to unsubscribe 
    private void OnHatInstantiated(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("Hat Instantiated");


    }
}
