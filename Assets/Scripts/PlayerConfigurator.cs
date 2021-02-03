using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerConfigurator : MonoBehaviour
{
    [SerializeField]
    private Transform m_HatAnchor;

    [SerializeField]
    private Transform m_AccessoryAnchor;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Remove this random stuff, just for testing atm
        SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 3)));
    }

    // Update is called once per frame
    void Update()
    {
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

    private void SetAccessory(string accessoryKey)
    {
        Addressables.InstantiateAsync(accessoryKey, m_AccessoryAnchor, false).Completed += OnAccessoryInstantiated;
    }

    private void OnAccessoryInstantiated(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("Accessory Instantiated");
    }
}
