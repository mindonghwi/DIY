using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_FINSHLOADMAP : MonoBehaviour {

    private GameObject m_goPlayerMGR;
    void Start()
    {
        m_goPlayerMGR = GameObject.Find("PlayerManager");

        gameObject.GetComponent<Button>().onClick.AddListener(() => updates());
    }

    // Update is called once per frame
    void updates()
    {
        m_goPlayerMGR.GetComponent<ProductManager>().LoadProducts();
    }
}
