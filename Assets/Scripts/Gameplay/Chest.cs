using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField]
    private Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Open()
    {
        // TODO: cache the string as a hash
        m_Animator.SetTrigger("Open");
    }
}
