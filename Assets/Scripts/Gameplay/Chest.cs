using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Chest : MonoBehaviour
{
    private Animator m_Animator;

    [SerializeField]
    private ParticleSystem m_ParticleSystem;

    [SerializeField]
    private float m_ParticlePlayDelayTime = 0.75f;

    [SerializeField]
    private GameObject m_Key;

    [SerializeField]
    private float m_KeyDestroyDelayTime = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Open()
    {
        // TODO: cache the string as a hash
        m_Animator.SetTrigger("Open");

        StartCoroutine(PlayParticles());

        StartCoroutine(DestroyKey());
    }

    private IEnumerator DestroyKey()
    {
        yield return new WaitForSeconds(m_KeyDestroyDelayTime);

        m_Key.SetActive(false);
    }

    private IEnumerator PlayParticles()
    {
        yield return new WaitForSeconds(m_ParticlePlayDelayTime);

        m_ParticleSystem.Play();
    }
}
