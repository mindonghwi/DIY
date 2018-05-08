using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AURABULLETBUTTON : MonoBehaviour {


    private GameObject m_goAura;
    private C_LOADAURA m_cLoadAura;
    private C_LOADBULLET m_cLoadBullet;
    private GameObject m_goTmpAura;
    private GameObject m_goTmpBullet;
    private GameObject m_goBullet;
    private C_LOADAURA.E_AURAEFFECT m_eAura;
    private int m_nBulletNum;
    void Start()
    {

        m_cLoadAura = new C_LOADAURA();
        m_cLoadAura.init();
        m_cLoadBullet = new C_LOADBULLET();
        m_cLoadBullet.init();
        m_goAura = new GameObject();
        m_goAura.name = "Aura";
        m_goBullet = new GameObject();
        m_goBullet.name = "Bullet";

        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(0), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_ARCANE), new Vector3(0.0f, 0.0f, 0.3f), Quaternion.Euler(-90.0f,0.0f,0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_ARCANE;
        m_nBulletNum = 0;
    }


    public void btnARCANE()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_ARCANE),new Vector3(0.0f,0.0f,0.0f),Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_ARCANE;
    }
    public void btnEARTH()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_EARTH), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_EARTH;
    }
    public void btnFIRE()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_FIRE), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_FIRE;
    }
    public void btnFROST()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_FROST), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_FROST;
    }
    public void btnLIFE()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_LIFE), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_LIFE;
    }
    public void btnLIGHT()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_LIGHT), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_LIGHT;
    }
    public void btnLIGHTNING()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_LIGHTNING), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_LIGHTNING;
    }
    public void btnSHADOW()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_SHADOW), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_SHADOW;
    }
    public void btnSTORM()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_STORM), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_STORM;
    }
    public void btnWATER()
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT.E_WATER), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_eAura = C_LOADAURA.E_AURAEFFECT.E_WATER;
    }

    public void btnBullet0()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(0), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 0;
    }
    public void btnBulle1()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(1), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 1;
    }
    public void btnBullet2()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(2), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 2;
    }
    public void btnBullet3()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(3), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 3;
    }
    public void btnBullet4()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(4), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 4;
    }
    public void btnBullet5()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(5), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 5;
    }
    public void btnBullet6()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(6), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 6;
    }
    public void btnBullet7()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(7), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 7;
    }
    public void btnBullet8()
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(8), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = 8;
    }

    public void btnNextPage()
    {
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Cus").GetComponent<C_CUSTOMIZINGCLOTH>().getCharacter().SetActive(true);
        m_goBullet.SetActive(false);
        m_goAura.SetActive(false);
    }

    public Object getAuraNum()
    {
        return m_cLoadAura.getTowerAuraEffect(m_eAura);
    }
    public GameObject getBulletNum()
    {
        return m_cLoadBullet.getBullet(m_nBulletNum);
    }

    public void btnUpdateBulletAuraData()
    {
        PlayerPrefs.SetInt("bullet", m_nBulletNum);
        PlayerPrefs.SetInt("aura", (int)m_eAura);
    }
}
