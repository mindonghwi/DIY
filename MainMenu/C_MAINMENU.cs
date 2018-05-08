using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MAINMENU : MonoBehaviour {

    private GameObject m_goCanvas;
	// Use this for initialization
	void Start () {
        m_goCanvas = GameObject.Find("Canvas");
       

    }
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            { 
                Application.Quit();
            }
        }
        
    }

    public void btnGameSetting()
    {
        m_goCanvas.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void btnreturnMainMenu()
    {
        m_goCanvas.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void btnCustomGameSetting()
    {
        m_goCanvas.transform.GetChild(3).gameObject.SetActive(true);
    }
    public void btnCustomreturnMainMenu()
    {
        m_goCanvas.transform.GetChild(3).gameObject.SetActive(false);
    }


}
