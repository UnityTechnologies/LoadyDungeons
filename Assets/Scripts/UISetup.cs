using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetup : MonoBehaviour
{
    public Button m_StartButton;

    // Start is called before the first frame update
    private void Start()
    {
        m_StartButton.onClick.AddListener(GameManager.LoadNextLevel);
    }

    private void OnDisable()
    {
        m_StartButton.onClick.RemoveListener(GameManager.LoadNextLevel);
    }
}
