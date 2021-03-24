using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Open()
    {
        m_Animator.SetTrigger("Open");
    }
}
