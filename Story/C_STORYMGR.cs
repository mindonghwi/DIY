using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class C_STORYMGR : MonoBehaviour {

    private VideoPlayer m_vpStory;
    private C_SCENEMGR m_cSceneMgr;

	// Use this for initialization
	void Start () {
        m_vpStory = gameObject.GetComponent<VideoPlayer>();
        m_cSceneMgr = gameObject.GetComponent<C_SCENEMGR>();
        m_vpStory.Play();
    }
	
	// Update is called once per frame
	void Update () {

        if (m_vpStory.frame > 200)
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    m_cSceneMgr.LoginScene();
                }
            }

            if (m_vpStory.frame == (long)m_vpStory.frameCount)
            {
                m_cSceneMgr.LoginScene();
            }
        }
        

    }
}
