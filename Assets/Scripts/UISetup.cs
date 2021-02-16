using UnityEngine;
using UnityEngine.UI;

public class UISetup : MonoBehaviour
{
    [SerializeField]
    private Button m_StartButton;

    private void OnEnable()
    {
        m_StartButton.onClick.AddListener(GameManager.LoadNextLevel);
    }

    private void OnDisable()
    {
        m_StartButton.onClick.RemoveListener(GameManager.LoadNextLevel);
    }
}
