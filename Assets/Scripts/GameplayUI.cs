using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private Button m_ExitButton;
 
    [SerializeField]
    private Image m_KeyIndicator;

    [SerializeField]
    private GameManagerSO m_GameManager;

    private void OnEnable()
    {
        m_ExitButton.onClick.AddListener(m_GameManager.ExitGameplay);
    }

    private void OnDisable()
    {
        m_ExitButton.onClick.RemoveListener(m_GameManager.ExitGameplay);
    }

    public void KeyCollected()
    {
        m_KeyIndicator.color = Color.white;
    }
}
