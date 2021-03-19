using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class Store : MonoBehaviour
{
    [SerializeField]
    private Button m_ClearCacheButton;

    [SerializeField]
    private Button m_BuyHatsButton;

    [SerializeField]
    private Button m_LeftArrowButton;

    [SerializeField]
    private Button m_RightArrowButton;

    [SerializeField]
    private GameManagerSO m_GameManager;

    private AsyncOperationHandle m_HatsHandle;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Check if the hats have been unlocked
    }

    public void PurchaseHats()
    {
        // TODO: Download the assets and then assign the first hat to the character
        m_HatsHandle = Addressables.DownloadDependenciesAsync("Hat00");

        m_HatsHandle.Completed += OnHatsDownloaded;
    }

    private void OnHatsDownloaded(AsyncOperationHandle obj)
    {
        if(m_HatsHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Hats Unlocked");

            // Save the first hat
            m_GameManager.s_ActiveHat = 0;

            //TODO: Position it on the Dino's head
            Addressables.InstantiateAsync("Hat0" + m_GameManager.s_ActiveHat);

            //Hide the Purchase Button
            m_BuyHatsButton.gameObject.SetActive(false);

            //Show the clear cache button to remove the apps and purge the Addressables cache
            m_ClearCacheButton.gameObject.SetActive(true);

            // Show the arrow buttons
            m_LeftArrowButton.gameObject.SetActive(true);
            m_RightArrowButton.gameObject.SetActive(true);
        }

        m_HatsHandle.Completed -= OnHatsDownloaded;
    }

    public void NextHat()
    {

    }

    public void PreviousHat()
    {

    }

    public void ClearAddressablesCache()
    {
        if(Caching.ClearCache())
        {
            Debug.Log("Cleared Cache Successfully");
            
            // Reload the scene or destroy the game object
        }
    }
}
