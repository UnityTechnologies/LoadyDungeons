using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerConfigurator : MonoBehaviour
{
    [SerializeField]
    private Transform m_HatAnchor;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Remove this random stuff, just for testing atm
        SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));
    }

    // TODO: Change the string parameter 
    public void SetHat(string hatKey)
    {
        Addressables.InstantiateAsync(hatKey, m_HatAnchor, false).Completed += OnHatInstantiated;
    }

    // TOASK: Where to unsubscribe 

    private void OnHatInstantiated(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("Hat Instantiated");
    }
}
