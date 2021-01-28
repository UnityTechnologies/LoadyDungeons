using System;
using System.Collections;
using System.Collections.Generic;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SetHat("Hat00");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            SetHat("Hat01");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            SetHat("Hat02");
        }
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

    public void SetAccessory()
    {
            
    }
}
