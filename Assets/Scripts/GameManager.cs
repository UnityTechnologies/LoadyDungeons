using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Replace this code with better loading handling
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Trying to load scene 00");
            Addressables.LoadSceneAsync("Level_00", UnityEngine.SceneManagement.LoadSceneMode.Additive, true).Completed += OnSceneLoaded;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Trying to load scene 00");
            Addressables.LoadSceneAsync("Level_01", UnityEngine.SceneManagement.LoadSceneMode.Additive, true).Completed += OnSceneLoaded;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Trying to load scene 02");
            Addressables.LoadSceneAsync("Level_02", UnityEngine.SceneManagement.LoadSceneMode.Additive, true).Completed += OnSceneLoaded;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Trying to load scene 03");
            Addressables.LoadSceneAsync("Level_03", UnityEngine.SceneManagement.LoadSceneMode.Additive, true).Completed += OnSceneLoaded;
        }
    }

    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> sceneHandle)
    {
        Debug.Log("Scene Loaded");
    }
}
