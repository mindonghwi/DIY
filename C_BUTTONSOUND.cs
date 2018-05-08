using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BUTTONSOUND : MonoBehaviour {

    AudioSource m_audsrcAudioButton;


	// Use this for initialization
	void Start () {
        m_audsrcAudioButton = gameObject.GetComponent<AudioSource>();
    }
	
    public void ButtonClick()
    {
        m_audsrcAudioButton.Play();
    }

}
