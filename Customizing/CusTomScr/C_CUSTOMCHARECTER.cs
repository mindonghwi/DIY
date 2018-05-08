using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CUSTOMCHARECTER : MonoBehaviour {

    [SerializeField]
    private GameObject m_goCharacter;

    [SerializeField]
    private Renderer m_mtrCharacterMaterial;

    private int m_nHairItemNumber;
    private int m_nHandItemNumber;
    private int m_nFaceItemNumber;
    private int m_nMaterielNumber;
    private int m_nHairMaterielNumber;

    private C_LOADDATA m_cLoadData;

    private GameObject m_goHand;
    private GameObject m_goFace;
    private GameObject m_goHair;

    private GameObject m_goAura;
    private GameObject m_goBullet;
    private GameObject m_goTmpAura;
    private GameObject m_goTmpBullet;

    private int m_nBulletNum;
    private int m_nAuraNum;

    private C_LOADBULLET m_cLoadBullet;
    private C_LOADAURA m_cLoadAura;

    private uint m_nHairColorNum;
    private int m_nBulletColor;
    void Start()
    {

        m_cLoadData = GameObject.Find("LoadData").GetComponent<C_LOADDATA>();
        m_cLoadBullet = new C_LOADBULLET();
        m_cLoadBullet.init();
        m_cLoadAura = new C_LOADAURA();
        m_cLoadAura.init();

        m_goCharacter = Instantiate((GameObject)Resources.Load("Tower/Custom/customizingTower"));
        m_goCharacter.transform.Translate(new Vector3(0.0f, -1.0f, 0.0f));
        m_mtrCharacterMaterial = m_goCharacter.transform.GetChild(1).gameObject.GetComponent<Renderer>();
        m_goCharacter.tag = "CustomTower";

        m_goHand = m_goCharacter.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        m_goFace = m_goCharacter.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject;
        m_goHair = m_goCharacter.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject;

        m_nHairItemNumber = -1;
        m_nHandItemNumber = -1;
        m_nFaceItemNumber = -1;
        m_nMaterielNumber = 0;
        m_nHairMaterielNumber = m_cLoadData.getLoadItem().getHairMaterialCustom();

        m_goAura = new GameObject();
        m_goAura.name = "Aura";
        m_goBullet = new GameObject();
        m_goBullet.name = "Bullet";

        m_nAuraNum = (int)C_LOADAURA.E_AURAEFFECT.E_ARCANE;
        m_nBulletNum = 0;

        m_goTmpBullet =Instantiate(m_cLoadBullet.getBullet(m_nBulletNum), m_goCharacter.transform.position + new Vector3(3.0f, 1.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;


        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect((C_LOADAURA.E_AURAEFFECT)m_nAuraNum), m_goCharacter.transform.position, Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;


        m_nHairColorNum = 0;
        m_nBulletColor = 0;
    }

    void Update()
    {

    }

    public void setMaterial(int nIndex)
    {
        m_mtrCharacterMaterial.material = m_cLoadData.getLoadItem().getLoadMaterial(nIndex);
        m_nMaterielNumber = nIndex;
        Debug.Log(nIndex);
    }
    public void setHair(int nIndex)
    {

        if (m_goHair.transform.childCount > 0)
        {
            Destroy(m_goHair.transform.GetChild(0).gameObject);
        }

        GameObject goTmpHair;
        if (nIndex == 4)
        {
            goTmpHair = Instantiate(m_cLoadData.getLoadItem().getLoadHair(nIndex)
            , m_goHair.transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
            goTmpHair.transform.parent = m_goHair.transform;
            if (m_nHairMaterielNumber != -1)
            {
                goTmpHair.transform.GetChild(1).GetComponent<Renderer>().materials[1].color = m_cLoadData.getLoadItem().getLoadHairMaterial(m_nHairMaterielNumber).color;

            }
        }
        else
        {
            goTmpHair = Instantiate(m_cLoadData.getLoadItem().getLoadHair(nIndex)
           , m_goCharacter.transform.GetChild(1).position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
            goTmpHair.transform.parent = m_goHair.transform;
            if (m_nHairMaterielNumber != -1)
            {
                goTmpHair.GetComponent<Renderer>().material = m_cLoadData.getLoadItem().getLoadHairMaterial(m_nHairMaterielNumber);
            }
        }
        m_nHairItemNumber = nIndex;

    }
    public void setWeapon(int nIndex)
    {
        if (m_goHand.transform.childCount > 0)
        {
            Destroy(m_goHand.transform.GetChild(0).gameObject);
        }
        GameObject goTmpWeapon = Instantiate(m_cLoadData.getLoadItem().getLoadWeapon(nIndex), m_goHand.transform.position, m_goHand.transform.rotation);
        goTmpWeapon.transform.parent = m_goHand.transform;
        m_nHandItemNumber = nIndex;
    }
    public void setFace(int nIndex)
    {
        if (m_goFace.transform.childCount > 0)
        {
            Destroy(m_goFace.transform.GetChild(0).gameObject);
        }
        GameObject goTmpFace = Instantiate(m_cLoadData.getLoadItem().getLoadFace(nIndex), m_goCharacter.transform.position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
        goTmpFace.transform.parent = m_goFace.transform;
        m_nFaceItemNumber = nIndex;
    }
    public void setHairMaterial(int nIndex)
    {
        if (m_nHairItemNumber != -1)
        {
            if (m_nHairItemNumber == 4)
            {
                m_goHair.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials[1].color = m_cLoadData.getLoadItem().getLoadHairMaterial(nIndex).color;
            }
            else
            {
                m_goHair.transform.GetChild(0).GetComponent<Renderer>().material = m_cLoadData.getLoadItem().getLoadHairMaterial(nIndex);
            }
        }
        m_nHairMaterielNumber = nIndex;
    }

    public void setHairMaterialCustom(Color32 colorData)
    {
        m_nHairColorNum = 0;
        if (m_nHairItemNumber != -1)
        {
            if (m_nHairItemNumber == 4)
            {

                m_goHair.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().materials[1].color = colorData;
            }
            else
            {
                m_goHair.transform.GetChild(0).GetComponent<Renderer>().material.color = colorData;
            }
        }
        
        m_nHairColorNum = colorChangeInt(colorData);
        Debug.Log(colorData.ToString("x") + "         " + m_nHairColorNum);
    }

    public GameObject getCharacter()
    {
        return m_goCharacter;
    }
    public int getHairItemNum()
    {
        return m_nHairItemNumber;
    }
    public int getHandItemNum()
    {
        return m_nHandItemNumber;
    }
    public int getFaceItemNum()
    {
        return m_nFaceItemNumber;
    }
    public int getMaterialNum()
    {
        return m_nMaterielNumber;
    }

    public void setAuraSelect(int nIndex)
    {
        Destroy(m_goAura.transform.GetChild(0).gameObject);
        m_goTmpAura = Instantiate(m_cLoadAura.getTowerAuraEffect((C_LOADAURA.E_AURAEFFECT)nIndex), m_goCharacter.transform.position, Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;
        m_goTmpAura.transform.parent = m_goAura.transform;
        m_nAuraNum = nIndex;
    }
    public void setBulletSelect(int nIndex)
    {
        Destroy(m_goBullet.transform.GetChild(0).gameObject);
        m_goTmpBullet = Instantiate(m_cLoadBullet.getBullet(nIndex), m_goCharacter.transform.position + new Vector3(3.0f, 1.0f, 0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f));
        m_goTmpBullet.transform.parent = m_goBullet.transform;
        m_nBulletNum = nIndex;
    }
    public void setBulletColorSelect(int nIndex)
    {
        m_goTmpBullet.GetComponent<Renderer>().material = m_cLoadBullet.getBulletMaterial(nIndex);
        m_nBulletColor = nIndex;
    }

    public void setTowersItem()
    {
        PlayerPrefs.SetInt("hairItem", m_nHairItemNumber);
        PlayerPrefs.SetInt("weaponItem", m_nHandItemNumber);
        PlayerPrefs.SetInt("faceItem", m_nFaceItemNumber);
        PlayerPrefs.SetInt("materialItem", m_nMaterielNumber);
        PlayerPrefs.SetInt("HairMaterielNumber", m_nHairMaterielNumber);
        PlayerPrefs.SetInt("HairColorNum", (int)m_nHairColorNum);
    }

    private Color32 intChangeColor(int nIndex, Color32 colorData)
    {

        colorData.a = (byte)((nIndex) & 0xFF);
        colorData.b = (byte)((nIndex >> 8) & 0xFF);
        colorData.g = (byte)((nIndex >> 16) & 0xFF);
        colorData.r = (byte)((nIndex >> 24) & 0xFF);

        return colorData;

    }

    private uint colorChangeInt(Color32 colorData)
    {
        uint nColor = 0;

        nColor = (uint)((colorData.r << 24) | (colorData.g << 16) |
                     (colorData.b << 8) | (colorData.a << 0));


        return nColor;
    }

    public string getStrTowerNomal()
    {
        //아이디는 서버에 쓸거고 아직 안나와서 안씀 서버에서 받아와야함
        string tmpStr1;
        string tmpStr2;
        if (m_nMaterielNumber < 10)
        {
            tmpStr1 = "0" + m_nMaterielNumber.ToString();
        }
        else
        {
            tmpStr1 = m_nMaterielNumber.ToString();
        }
        if (m_nHairMaterielNumber < 10)
        {
            tmpStr2 = "0" + m_nHairMaterielNumber.ToString();
        }
        else
        {
            tmpStr2 = m_nHairMaterielNumber.ToString();
        }

        if (m_nHairItemNumber == -1)
        {
            m_nHairItemNumber = 5;
        }
        if (m_nHandItemNumber == -1)
        {
            m_nHandItemNumber = 2;
        }
        if (m_nFaceItemNumber == -1)
        {
            m_nFaceItemNumber = 2;
        }
        

        string strData =  "/" + m_nFaceItemNumber + "/" + m_nHandItemNumber + "/" + tmpStr1 + "/" + m_nHairItemNumber + "/" + tmpStr2 + "/" + m_nAuraNum + "/" + m_nBulletNum + "/" ;
        return strData;
    }

    public string getStrTowerSub()
    {
        string tmpStr;

        if (m_nHairColorNum == 0)
        {
            tmpStr = "0000000000";
        }
        else if (m_nHairColorNum < Mathf.Pow(10,8) )
        {
            tmpStr = "00" + m_nHairColorNum.ToString();
        }
        else if (m_nHairColorNum < Mathf.Pow(10, 9))
        {
            tmpStr = "0" + m_nHairColorNum.ToString();
        }
        else
        {
            tmpStr = m_nHairColorNum.ToString();
        }

        string strData = tmpStr + "/" + m_nBulletColor + "/";
        return strData;
    }
}
