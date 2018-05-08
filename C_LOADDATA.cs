using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LOADDATA : MonoBehaviour {
    private C_LOADAURA m_cLoadAura;
    private C_LOADBULLET m_cLoadBullet;
    private C_LOADEFFECT m_cLoadEffect;
    private C_LOADITEM m_cLoadItem;
    private C_LOADNODE m_cLoadNode;
    [SerializeField]
    private C_LOADCUSTOMTOWER m_cLoadCustomTower;


    // Use this for initialization
    void Awake () {
        m_cLoadAura = new C_LOADAURA();
        m_cLoadBullet = new C_LOADBULLET();
        m_cLoadEffect = new C_LOADEFFECT();
        m_cLoadItem = new C_LOADITEM();
        m_cLoadNode = new C_LOADNODE();


        m_cLoadAura.init();
        m_cLoadBullet.init();
        m_cLoadEffect.init();
        m_cLoadItem.init();
        m_cLoadNode.load();

    }

    void Start()
    {
        if (gameObject.GetComponent<C_LOADCUSTOMTOWER>())
        {
            m_cLoadCustomTower = gameObject.GetComponent<C_LOADCUSTOMTOWER>();
        }
    }
    public C_LOADAURA getLoadAura()
    {
        return m_cLoadAura;
    }
    
    public C_LOADBULLET getLoadBullet()
    {
        return m_cLoadBullet;
    }
    public C_LOADEFFECT getLoadEffect()
    {
        return m_cLoadEffect;
    }
    public C_LOADITEM getLoadItem()
    {
        return m_cLoadItem;
    }
    public C_LOADNODE getLoadNode()
    {
        return m_cLoadNode;
    }

    public C_LOADCUSTOMTOWER getLoadCustomTower()
    {
        return m_cLoadCustomTower;
    }
}
