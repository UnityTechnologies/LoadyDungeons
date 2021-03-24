using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Chest : MonoBehaviour
{
    private Animator m_Animator;

    [SerializeField]
    private ParticleSystem m_ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Open()
    {
        // TODO: cache the string as a hash
        m_Animator.SetTrigger("Open");

        m_ParticleSystem.Play();
    }
}
