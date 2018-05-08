using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LOADITEM{

    [SerializeField]
    private Material[] m_mtrCharacter;
    [SerializeField]
    private GameObject[] m_arHair;
    [SerializeField]
    private GameObject[] m_arWeapon;
    [SerializeField]
    private GameObject[] m_arFace;
    private Material[] m_mtrHairMaterial;

    // Use this for initialization
    public void init () {
        m_mtrCharacter = Resources.LoadAll<Material>("CustomizingMaterial/Materials");
        m_arFace = Resources.LoadAll<GameObject>("CustomizingMaterial/Face");
        m_arHair = Resources.LoadAll<GameObject>("CustomizingMaterial/Hair");
        m_arWeapon = Resources.LoadAll<GameObject>("CustomizingMaterial/Weapon");
        m_mtrHairMaterial = Resources.LoadAll<Material>("CustomizingMaterial/HairMaterials");
    }
	
    public Material getLoadMaterial(int nIndex)
    {
        return m_mtrCharacter[nIndex];
    }
    public GameObject getLoadHair(int nIndex)
    {
        return m_arHair[nIndex];
    }
    public GameObject getLoadFace(int nIndex)
    {
        Debug.Log(nIndex);
        return m_arFace[nIndex];
    }
    public GameObject getLoadWeapon(int nIndex)
    {
        return m_arWeapon[nIndex];
    }
    public Material getLoadHairMaterial(int nIndex)
    {
        return m_mtrHairMaterial[nIndex];
    }

    public int getHairMaterialCustom()
    {
        return m_mtrHairMaterial.Length - 1;
    }

    public void release()
    {
        Resources.UnloadUnusedAssets();
    }


}
