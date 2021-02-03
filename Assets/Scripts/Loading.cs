using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using System;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Slider m_LoadingSlider;

    [SerializeField]
    private GameObject m_PlayButton;

    // TODO: Maybe just have it inside the Start method and not class-wide
    AsyncOperationHandle<SceneInstance> m_SceneHandle;

    // Start is called before the first frame update
    void Start()
    {
            //TODO: Change the  
            m_SceneHandle = Addressables.LoadSceneAsync("Level_00", UnityEngine.SceneManagement.LoadSceneMode.Single, false);

            m_SceneHandle.Completed += OnSceneLoaded;
    }

    private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        // The scene is loaded, show the button and now turn the scene on?
        m_PlayButton.SetActive(true);
    }


    public void LoadNextLevel()
    {
        if(m_SceneHandle.Status == AsyncOperationStatus.Succeeded)
        {
            m_SceneHandle.Result.ActivateAsync();
        }
    }

    private void Update()
    {
        m_LoadingSlider.value = m_SceneHandle.PercentComplete;
    }
}
