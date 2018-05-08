using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CREATETOWER : MonoBehaviour {

    private int m_nMtrCustom;
    private int m_nHair;
    private int m_nWeapon;
    private int m_nFace;

    private C_LOADITEM m_cLoadItem;
    private C_LOADAURA m_cLoadAura;
    private C_LOADBULLET m_cLoadBullet;
    private GameObject m_goMyTower;

    // Use this for initialization
    void Start () {

        m_cLoadItem = new C_LOADITEM();
        m_cLoadItem.init();
        m_cLoadAura = new C_LOADAURA();
        m_cLoadAura.init();
        m_cLoadBullet = new C_LOADBULLET();
        m_cLoadBullet.init();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void upgradeTowerData()
    {
        m_nHair = PlayerPrefs.GetInt("hairItem");
        m_nWeapon = PlayerPrefs.GetInt("weaponItem");
        m_nFace = PlayerPrefs.GetInt("faceItem");
        m_nMtrCustom = PlayerPrefs.GetInt("materialItem");


        Debug.Log(m_nWeapon + "" + m_nHair + "" + m_nFace + "" + m_nMtrCustom);

    }

    public void CreateTower()
    {
        m_goMyTower = Instantiate((GameObject)Resources.Load("Tower/Custom/customizingTower"));

        m_goMyTower.transform.GetChild(1).GetComponent<Renderer>().material = m_cLoadItem.getLoadMaterial(m_nMtrCustom);

        GameObject m_goHand = m_goMyTower.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        GameObject m_goFace = m_goMyTower.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject;
        GameObject m_goHair = m_goMyTower.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject;

        if (m_nFace != -1)
        {
            GameObject goTmpFace = Instantiate(m_cLoadItem.getLoadFace(m_nFace), m_goMyTower.transform.position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));

            goTmpFace.transform.parent = m_goFace.transform;

        }
        if (m_nHair != -1)
        {
            GameObject goTmpHair = Instantiate(m_cLoadItem.getLoadHair(m_nHair), m_goMyTower.transform.GetChild(1).position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));

            goTmpHair.GetComponent<Renderer>().material = m_cLoadItem.getLoadHairMaterial(PlayerPrefs.GetInt("HairMaterielNumber"));

            goTmpHair.transform.parent = m_goHair.transform;

        }
        if (m_nWeapon != -1)
        {
            GameObject goTmpWeapon = Instantiate(m_cLoadItem.getLoadWeapon(m_nWeapon), m_goHand.transform.position, m_goHand.transform.rotation);

            goTmpWeapon.transform.parent = m_goHand.transform;

        }

        m_goMyTower.AddComponent<C_CUSTOMTOWER>();
        m_goMyTower.AddComponent<C_TOWER>();
        m_goMyTower.AddComponent<C_TOWERUI>();
        m_goMyTower.AddComponent<C_TOWERANIMATION>();
        m_goMyTower.GetComponent<Animation>().enabled = true;

        m_goMyTower.AddComponent<C_CUSTOMTOWER>().setBullet(m_cLoadBullet.getBullet(PlayerPrefs.GetInt("bullet")));
        m_goMyTower.AddComponent<C_CUSTOMTOWER>().init(PlayerPrefs.GetFloat("striking",0.0f), PlayerPrefs.GetFloat("downrange", 0.0f)
            , PlayerPrefs.GetFloat("speedOfStriking", 0.0f), PlayerPrefs.GetInt("targetCount", 0),25);



        GameObject goTmpEffect = Instantiate(m_cLoadAura.getTowerAuraEffect((C_LOADAURA.E_AURAEFFECT)PlayerPrefs.GetInt("aura")), m_goMyTower.transform.position, Quaternion.Euler(-90.0f, 0.0f, 0.0f))as GameObject;

        //m_goMyTower.AddComponent<C_CUSTOMTOWER>().setBullet(GameObject.Find("BulletnAura").GetComponent<C_AURABULLETBUTTON>().getBulletNum());

        //GameObject goTmpEffect = Instantiate(GameObject.Find("BulletnAura").GetComponent<C_AURABULLETBUTTON>().getAuraNum(), m_goMyTower.transform.position, Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;

        goTmpEffect.transform.parent = m_goMyTower.transform;
        GameObject.Find("Cus").GetComponent<C_CUSTOMIZINGCLOTH>().getCharacter().SetActive(false);
    }

    public void btnNextSetting()
    {
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
    }

    public GameObject getCustomTower()
    {
        return m_goMyTower;
    }
}
