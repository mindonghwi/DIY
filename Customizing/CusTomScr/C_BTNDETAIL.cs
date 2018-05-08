using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_BTNDETAIL : MonoBehaviour {

    private C_CUSTOMCHARECTER m_cCustomCharecter;
    private GameObject m_goHairColorButton;

    // Use this for initialization
    void Start()
    {
        m_cCustomCharecter = GameObject.Find("CustomCtr").GetComponent<C_CUSTOMCHARECTER>();

        m_goHairColorButton = GameObject.Find("HairColorPanel");
    }

    public void btnClothSelect(int nIndex)
    {
        m_cCustomCharecter.setMaterial(nIndex);
    }

    public void btnHairSelect(int nIndex)
    {
        m_cCustomCharecter.setHair(nIndex);
    }
    public void btnHairColorSelect(int nIndex)
    {
        m_cCustomCharecter.setHairMaterial(nIndex);
    }
    public void btnHairColorCustomSelect(int nIndex)
    {
        m_cCustomCharecter.setHairMaterialCustom(m_goHairColorButton.transform.GetChild(nIndex).GetComponent<Button>().colors.normalColor);
    }
    public void btnWeaponSelect(int nIndex)
    {
        m_cCustomCharecter.setWeapon(nIndex);
    }
    public void btnFaceSelect(int nIndex)
    {
        m_cCustomCharecter.setFace(nIndex);
    }
    public void btnAuraSelect(int nIndex)
    {
        m_cCustomCharecter.setAuraSelect(nIndex);
    }
    public void btnBulletSelect(int nIndex)
    {
        m_cCustomCharecter.setBulletSelect(nIndex);
    }
    public void btnBulletColorSelect(int nIndex)
    {
        m_cCustomCharecter.setBulletColorSelect(nIndex);
    }
}
