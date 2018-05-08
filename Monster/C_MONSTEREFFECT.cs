using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MONSTEREFFECT : MonoBehaviour {

    private C_LOADEFFECT m_cEffect;

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("Main Camera").GetComponent<C_GAMEMGR>())
        {
            m_cEffect = GameObject.Find("Main Camera").GetComponent<C_GAMEMGR>().getLoadEffect();

        }
        else
        {
            m_cEffect = GameObject.Find("Main Camera").GetComponent<C_CUSTOMGAMEMGR>().getLoadEffect();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Instantiate(m_cEffect.getEffect(C_LOADEFFECT.E_EFFECT.E_BOOM2), gameObject.transform.position + new Vector3(0.0f,1.0f,0.0f), Quaternion.identity);

    }
}
