using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EFFECT : MonoBehaviour {

    private ParticleSystem m_psParticleSystem;

	// Use this for initialization
	void Start () {
        m_psParticleSystem = GetComponent<ParticleSystem>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!m_psParticleSystem.isPlaying || m_psParticleSystem.time >= m_psParticleSystem.main.duration)
        {
            Destroy(gameObject);
        }
	    
	}
}
