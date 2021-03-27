using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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

    [SerializeField]
    private Transform m_HatAttachPoint;

    private AsyncOperationHandle m_DownloadHatsHandle;

    private AsyncOperationHandle m_HatHandle;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: Check if the hats have been unlocked
        if(m_GameManager.s_ActiveHat >= 0)
        {
            ShowHatSelectionUI();

            m_HatHandle = Addressables.InstantiateAsync("Hat0" + m_GameManager.s_ActiveHat, m_HatAttachPoint);
        }
    }

    public void PurchaseHats()
    {
        // TODO: Download the assets and then assign the first hat to the character
        m_DownloadHatsHandle = Addressables.DownloadDependenciesAsync("Hat00");

        m_DownloadHatsHandle.Completed += OnHatsDownloaded;
    }

    private void OnHatsDownloaded(AsyncOperationHandle obj)
    {
        if(m_DownloadHatsHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("Hats Unlocked");

            // TODO: Avoid assigning directly the int to the gamemanager property
            // Save the first hat
            m_GameManager.s_ActiveHat = 0;

            //TODO: Position it on the Dino's head
            m_HatHandle = Addressables.InstantiateAsync("Hat0" + m_GameManager.s_ActiveHat, m_HatAttachPoint);

            ShowHatSelectionUI();
        }

        m_DownloadHatsHandle.Completed -= OnHatsDownloaded;
    }

    public void NextHat()
    {
        // Clear the current selected hat
        Addressables.ReleaseInstance(m_HatHandle);

        if(m_GameManager.s_ActiveHat < 3)
        {
            ++m_GameManager.s_ActiveHat;
        }
        else
        {
            m_GameManager.s_ActiveHat = 0;
        }

        m_HatHandle = Addressables.InstantiateAsync("Hat0" + m_GameManager.s_ActiveHat, m_HatAttachPoint);
    }

    public void PreviousHat()
    {
        // Clear the current selected hat
        Addressables.ReleaseInstance(m_HatHandle);

        if (m_GameManager.s_ActiveHat > 1)
        {
            --m_GameManager.s_ActiveHat;
        }
        else
        {
            m_GameManager.s_ActiveHat = 3;
        }

        m_HatHandle = Addressables.InstantiateAsync("Hat0" + m_GameManager.s_ActiveHat, m_HatAttachPoint);
    }

    public void ClearAddressablesCache()
    {
        if(Caching.ClearCache())
        {
            Debug.Log("Cleared Cache Successfully");

            // Reset the hat 
            m_GameManager.s_ActiveHat = -1;

            HideHatSelectionUI();

            //TODO: Reload the scene or destroy the game object
            Addressables.ReleaseInstance(m_HatHandle);
        }
    }

    private void ShowHatSelectionUI()
    {
        //Hide the Purchase Button
        m_BuyHatsButton.gameObject.SetActive(false);

        //Show the clear cache button to remove the apps and purge the Addressables cache
        m_ClearCacheButton.gameObject.SetActive(true);

        // Show the arrow buttons
        m_LeftArrowButton.gameObject.SetActive(true);
        m_RightArrowButton.gameObject.SetActive(true);
    }

    private void HideHatSelectionUI()
    {
        // Show the Purchase Button
        m_BuyHatsButton.gameObject.SetActive(true);

        // Hide the clear cache button to remove the apps and purge the Addressables cache
        m_ClearCacheButton.gameObject.SetActive(false);

        // Hide the arrow buttons
        m_LeftArrowButton.gameObject.SetActive(false);
        m_RightArrowButton.gameObject.SetActive(false);
    }
}
