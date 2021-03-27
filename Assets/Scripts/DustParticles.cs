using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticles : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem m_ParticleSystem;

    public void PlayParticles()
    {
        m_ParticleSystem.Play();
    }
}
