using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    public Button m_ExitButton;

    // Start is called before the first frame update
    private void OnEnable()
    {
        m_ExitButton.onClick.AddListener(GameManager.ExitGameplay);
    }

    private void OnDisable()
    {
        m_ExitButton.onClick.RemoveListener(GameManager.ExitGameplay);
    }
}
