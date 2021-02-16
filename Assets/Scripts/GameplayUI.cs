using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private Button m_ExitButton;

    private void OnEnable()
    {
        m_ExitButton.onClick.AddListener(GameManager.ExitGameplay);
    }

    private void OnDisable()
    {
        m_ExitButton.onClick.RemoveListener(GameManager.ExitGameplay);
    }
}
