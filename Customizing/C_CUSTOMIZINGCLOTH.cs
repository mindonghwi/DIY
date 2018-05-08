using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CUSTOMIZINGCLOTH : MonoBehaviour {
    [SerializeField]
    private GameObject m_goCharacter;

    [SerializeField]
    private Renderer m_mtrCharacterMaterial;

    private GameObject m_goHand;
    private GameObject m_goFace;
    private GameObject m_goHair;

    private int m_nHairItemNumber;
    private int m_nHandItemNumber;
    private int m_nFaceItemNumber;
    private int m_nMaterielNumber;
    private int m_nHairMaterielNumber;

    private C_LOADITEM m_cLoadItem;
    GameObject m_goTmpHair;

    void Start () {

        m_cLoadItem = new C_LOADITEM();
        m_cLoadItem.init();

        m_goCharacter = Instantiate((GameObject)Resources.Load("Tower/Custom/customizingTower"));
        m_goCharacter.transform.Translate(new Vector3(0.0f, -1.0f, 0.0f));
        m_mtrCharacterMaterial = m_goCharacter.transform.GetChild(1).gameObject.GetComponent<Renderer>();
        m_goCharacter.tag = "CustomTower";
        m_goCharacter.SetActive(false);

        m_goHand = m_goCharacter.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        m_goFace = m_goCharacter.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject;
        m_goHair = m_goCharacter.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject;

        m_nHairItemNumber = -1;
        m_nHandItemNumber = -1;
        m_nFaceItemNumber = -1;
        m_nMaterielNumber = 0;
        m_nHairMaterielNumber = -1;
        m_mtrCharacterMaterial.material = m_cLoadItem.getLoadMaterial(m_nMaterielNumber);
    }
	
	void Update () {
		
	}

    public void setMaterial(int nIndex)
    {
        m_mtrCharacterMaterial.material = m_cLoadItem.getLoadMaterial(nIndex);
        m_nMaterielNumber = nIndex;
        Debug.Log(nIndex);
    }

    public void setHair(int nIndex)
    {
        if (m_goHair.transform.childCount > 0)
        {
            Destroy(m_goHair.transform.GetChild(0).gameObject);
        }

        m_goTmpHair = Instantiate(m_cLoadItem.getLoadHair(nIndex), m_goCharacter.transform.GetChild(1).position,Quaternion.Euler(new Vector3(-90.0f,0.0f,0.0f)));

        m_goTmpHair.transform.parent = m_goHair.transform;
        m_nHairItemNumber = nIndex;
        if (m_nHairMaterielNumber != -1)
        {
            setHairMaterial(m_nHairMaterielNumber);

        }

    }
    public void setWeapon(int nIndex)
    {
        if (m_goHand.transform.childCount > 0)
        {
            Destroy(m_goHand.transform.GetChild(0).gameObject);
        }
        GameObject goTmpWeapon = Instantiate(m_cLoadItem.getLoadWeapon(nIndex), m_goHand.transform.position, m_goHand.transform.rotation);
        goTmpWeapon.transform.parent = m_goHand.transform;
        m_nHandItemNumber = nIndex;
    }
    public void setFace(int nIndex)
    {
        if (m_goFace.transform.childCount > 0)
        {
            Destroy(m_goFace.transform.GetChild(0).gameObject);
        }
        GameObject goTmpFace = Instantiate(m_cLoadItem.getLoadFace(nIndex), m_goCharacter.transform.position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
        goTmpFace.transform.parent = m_goFace.transform;
        m_nFaceItemNumber = nIndex;
    }

    public void setHairMaterial(int nIndex)
    {
        if (m_nHairItemNumber == -1)
        {
            return;
        }

        m_goTmpHair.GetComponent<Renderer>().material = m_cLoadItem.getLoadHairMaterial(nIndex);
        m_nHairMaterielNumber = nIndex;
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
    public C_LOADITEM getLoadItem()
    {
        return m_cLoadItem;
    }
    
    public void setTowersItem()
    {
        PlayerPrefs.SetInt("hairItem", m_nHairItemNumber);
        PlayerPrefs.SetInt("weaponItem", m_nHandItemNumber);
        PlayerPrefs.SetInt("faceItem", m_nFaceItemNumber);
        PlayerPrefs.SetInt("materialItem", m_nMaterielNumber);
        PlayerPrefs.SetInt("HairMaterielNumber", m_nHairMaterielNumber);
    }

}
