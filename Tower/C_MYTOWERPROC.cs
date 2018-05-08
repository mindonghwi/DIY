using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MYTOWERPROC : Object {


    private C_LOADDATA m_cLoadData;
    private GameObject m_goMyTower;
    private GameObject m_goTurret;
    private C_TOWERUPGRADE m_cTowerUpgrade;


    // Use this for initialization
    public void init()
    {
        m_cLoadData = GameObject.Find("LoadData").GetComponent<C_LOADDATA>();

        m_cTowerUpgrade = GameObject.Find("TowerCreater").GetComponent<C_TOWERUPGRADE>();
        
    }


    private void upgradeTowerData(GameObject goTower, int nListIndex)
    {
        //goTower.transform.GetChild(1).GetComponent<Renderer>().material 
        //    = m_cLoadData.getLoadItem().getLoadMaterial((int)m_cLoadData.getLoadCustomTower().getWantData((int)C_LOADCUSTOMTOWER.E_LISTORDER.E_CLOTH, nListIndex));

        goTower.transform.GetChild(1).GetComponent<Renderer>().material
            = m_cLoadData.getLoadItem().getLoadMaterial((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_CLOTH));


        GameObject m_goHand = goTower.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        GameObject m_goFace = goTower.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject;
        GameObject m_goHair;

        if (nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS1 && nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS2 &&
            nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS3 && nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS4)
        {
            m_goHair = goTower.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(2).gameObject;
        }
        else
        {
            m_goHair = goTower.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(1).gameObject;
        }


        if (m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_FACE) < 2)
        {
            //GameObject goTmpFace = Instantiate(m_cLoadData.getLoadItem().getLoadFace((int)m_cLoadData.getLoadCustomTower().getList(nListIndex)[(int)C_LOADCUSTOMTOWER.E_LISTORDER.E_FACE])
            //    , goTower.transform.position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
            GameObject goTmpFace = Instantiate(m_cLoadData.getLoadItem().getLoadFace((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_FACE))
                                                 , goTower.transform.position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
            goTmpFace.transform.parent = m_goFace.transform;

        }

        if (m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HEAD) < 5)
        {

            GameObject goTmpHair;
            if (nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_SOLIDER1 || nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_SOLIDER2
                || nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_SOLIDER3|| nListIndex == (int)C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_SOLIDER4
                || m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HEAD) == 4)
            {
                //goTmpHair = Instantiate(m_cLoadData.getLoadItem().getLoadHair((int)m_cLoadData.getLoadCustomTower().getList(nListIndex)[(int)C_LOADCUSTOMTOWER.E_LISTORDER.E_HEAD])
                //, m_goHair.transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
                goTmpHair = Instantiate(m_cLoadData.getLoadItem().getLoadHair((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_HEAD))
                                       , m_goHair.transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));

                if (m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_HEADMATERIAL) != 16)
                {
                    goTmpHair.transform.GetChild(1).GetComponent<Renderer>().materials[1].color = m_cLoadData.getLoadItem().getLoadHairMaterial((int)(m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HEADMATERIAL))).color;

                    if (m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HAIRCOLOR) != 0)
                    {
                       goTmpHair.transform.GetChild(1).GetComponent<Renderer>().materials[1].color = intChangeColor(m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HAIRCOLOR));
                    }
                }
                goTmpHair.transform.parent = m_goHair.transform;
            }
            else
            {
                // goTmpHair = Instantiate(m_cLoadData.getLoadItem().getLoadHair((int)m_cLoadData.getLoadCustomTower().getList(nListIndex)[(int)C_LOADCUSTOMTOWER.E_LISTORDER.E_HEAD])
                //, goTower.transform.GetChild(1).position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));
                goTmpHair = Instantiate(m_cLoadData.getLoadItem().getLoadHair((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HEAD))
                                        , goTower.transform.GetChild(1).position, Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f)));

                if (m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HEADMATERIAL) != 17)
                {
                    goTmpHair.GetComponent<Renderer>().material = m_cLoadData.getLoadItem().getLoadHairMaterial((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_HEADMATERIAL));

                    Debug.Log(m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HAIRCOLOR));

                    goTmpHair.GetComponent<Renderer>().material.color = intChangeColor(m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_HAIRCOLOR));
                    
                }
                goTmpHair.transform.parent = m_goHair.transform;
            }

        }

        if ((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_WEAPON) < 2)
        {
            GameObject goTmpWeapon = Instantiate(m_cLoadData.getLoadItem().getLoadWeapon((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_WEAPON))
                , m_goHand.transform.position, m_goHand.transform.rotation);

            goTmpWeapon.transform.parent = m_goHand.transform;

        }
        goTower.name = "Tower"+ m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_ID);

        goTower.AddComponent<C_CUSTOMTOWER>();
        goTower.AddComponent<C_TOWER>();

        goTower.AddComponent<C_TOWERANIMATION>();
        goTower.GetComponent<Animation>().enabled = true;
        goTower.AddComponent<C_TOWERUI>();

        goTower.GetComponent<C_CUSTOMTOWER>().setBullet(m_cLoadData.getLoadBullet().getBullet((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_BULLET)));
        goTower.GetComponent<C_CUSTOMTOWER>().setBulletColor(m_cLoadData.getLoadBullet().getBulletMaterial((int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_BULLETCOLOR)));


        goTower.GetComponent<C_CUSTOMTOWER>().init(//gameObject.GetComponent<C_TOWERUPGRADE>().getAttacking((int)m_cLoadData.getLoadCustomTower().getList(nListIndex)[(int)C_LOADCUSTOMTOWER.E_LISTORDER.E_BULLET])
            m_cTowerUpgrade.getAttacking(nListIndex)
            , m_cLoadData.getLoadCustomTower().getWantFTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERFLOAT.E_DOWNRANGE)
            , m_cLoadData.getLoadCustomTower().getWantFTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERFLOAT.E_SPEEDOFSTRIKING)
            , (int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_TARGETCOUNT),
            nListIndex);

        GameObject goTmpEffect = Instantiate(m_cLoadData.getLoadAura().getTowerAuraEffect(
            (C_LOADAURA.E_AURAEFFECT)(int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nListIndex,C_LOADTOWERDATA.E_LISTORDERINT.E_AURA))
            , goTower.transform.position + new Vector3(0.0f,0.53f,0.0f), Quaternion.Euler(-90.0f, 0.0f, 0.0f)) as GameObject;

        goTmpEffect.transform.parent = goTower.transform;

    }

    private GameObject CreateTowerPrefab(C_LOADCUSTOMTOWER.E_LISTTOWERNUM eListTowerNum)
    {
        if (eListTowerNum == C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS1 || eListTowerNum == C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS2 ||
            eListTowerNum == C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS3 || eListTowerNum == C_LOADCUSTOMTOWER.E_LISTTOWERNUM.E_CRIS4)
        {
            m_goMyTower = m_cLoadData.getLoadCustomTower().getCrisModel();
        }
        else
        {
            m_goMyTower = m_cLoadData.getLoadCustomTower().getNomalModel();
        }

        return m_goMyTower;
    }

    public void createTower(RaycastHit rayHit, GameObject goTowerHolder, C_LOADDATA cLoadData, C_INPUT cInput)
    {
        int nRandom = 0;
        Debug.Log(m_cLoadData.getLoadCustomTower().getGardeList(0).ToArray().Length);
        nRandom = Random.Range(0, m_cLoadData.getLoadCustomTower().getGardeList(0).ToArray().Length);
        

        m_goTurret = CreateTowerPrefab((C_LOADCUSTOMTOWER.E_LISTTOWERNUM)nRandom);


        rayHit.transform.gameObject.GetComponent<C_NODE>().m_goTower = Instantiate(m_goTurret, rayHit.transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);

        upgradeTowerData(rayHit.transform.gameObject.GetComponent<C_NODE>().m_goTower, m_cLoadData.getLoadCustomTower().getGardeList(0)[nRandom]);


        rayHit.transform.gameObject.GetComponent<C_NODE>().m_goTower.GetComponent<C_TOWER>().m_nLevel = 0;
        rayHit.transform.gameObject.GetComponent<C_NODE>().m_goTower.GetComponent<C_TOWER>().m_goMyNode = rayHit.transform.gameObject;
        rayHit.transform.gameObject.GetComponent<C_NODE>().m_goTower.transform.parent = goTowerHolder.transform;


        cInput.offIsBuild();
    }

    public void mapEditCreateTower(GameObject goTowerHolder, C_LOADDATA cLoadData, int nIndex, Vector3 vecPos)
    {
        m_goTurret = CreateTowerPrefab((C_LOADCUSTOMTOWER.E_LISTTOWERNUM)nIndex);

        GameObject m_goTmpTower;

        m_goTmpTower = Instantiate(m_goTurret, vecPos,Quaternion.identity);

        upgradeTowerData(m_goTmpTower, nIndex);
        m_goTmpTower.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        m_goTmpTower.transform.parent = goTowerHolder.transform;
        Destroy(m_goTmpTower.GetComponent<AudioSource>());

        m_goTmpTower.GetComponent<C_TOWER>().m_nLevel = (int)m_cLoadData.getLoadCustomTower().getWantNTowerData(nIndex, C_LOADTOWERDATA.E_LISTORDERINT.E_GRADE);
    }


    public void upgradeTurret(RaycastHit rayHit, GameObject goTowerHolder, C_LOADDATA cLoadData, C_INPUT cInput)
    {
        if (rayHit.transform.parent.gameObject.GetComponent<C_TOWER>().m_nLevel == 3)
        {
            return;
        }

        int nIndex = 0;
        int nCount = 0;
        int nTmpIndex = 0;
        while (nIndex < goTowerHolder.transform.childCount && nCount == 0)
        {
            if (rayHit.transform.parent.name == goTowerHolder.transform.GetChild(nIndex).name && goTowerHolder.transform.GetChild(nIndex) != rayHit.transform.parent)
            {
                nTmpIndex = nIndex;
                nCount++;
            }

            nIndex++;
        }
        int nTowerLevel = rayHit.transform.parent.gameObject.GetComponent<C_TOWER>().m_nLevel + 1;

        if (nCount == 0 || m_cLoadData.getLoadCustomTower().getGardeList(nTowerLevel).ToArray().Length == 0)
        {
            return;
        }
        else
        {
            int nRandom = 0;
            
            Debug.Log(nTowerLevel);
            nRandom = Random.Range(0, m_cLoadData.getLoadCustomTower().getGardeList(nTowerLevel).ToArray().Length);

            Debug.Log(m_cLoadData.getLoadCustomTower().getGardeList(nTowerLevel)[nRandom]);

            
            m_goTurret = CreateTowerPrefab((C_LOADCUSTOMTOWER.E_LISTTOWERNUM)m_cLoadData.getLoadCustomTower().getGardeList(nTowerLevel)[nRandom]);




            GameObject goTmpTower = Instantiate(m_goTurret, rayHit.transform.parent.position, Quaternion.identity);
            upgradeTowerData(goTmpTower, m_cLoadData.getLoadCustomTower().getGardeList(nTowerLevel)[nRandom]);


            goTmpTower.transform.parent = goTowerHolder.transform;
            goTmpTower.GetComponent<C_TOWER>().m_goMyNode = rayHit.transform.parent.gameObject.GetComponent<C_TOWER>().m_goMyNode;
            goTmpTower.GetComponent<C_TOWER>().m_nLevel = nTowerLevel;


            Destroy(goTowerHolder.transform.GetChild(nTmpIndex).gameObject);
            Destroy(rayHit.transform.parent.gameObject);
            goTmpTower.GetComponent<C_TOWER>().m_goMyNode.GetComponent<C_NODE>().m_goTower = goTmpTower;


            cInput.offIsMerge();
        }
    }

    public void ActiveTowerUi(RaycastHit rayHit)
    {
        rayHit.transform.parent.gameObject.GetComponent<C_TOWERUI>().OnMouseDown();
    }


    public GameObject getCustomTower()
    {
        return m_goMyTower;
    }

    public void SellTower(RaycastHit rayHit)
    {
        rayHit.transform.parent.gameObject.GetComponent<C_TOWER>().m_goMyNode.GetComponent<C_NODE>().m_goTower = null;
        Destroy(rayHit.transform.parent.gameObject);
 
    }

    private Color32 intChangeColor(uint nIndex)
    {
        Color32 colorData = new Color32();
        uint nIndexs = (uint)nIndex;
        colorData.a = (byte)((nIndexs) & 0xFF);
        colorData.b = (byte)((nIndexs >> 8) & 0xFF);
        colorData.g = (byte)((nIndexs >> 16) & 0xFF);
        colorData.r = (byte)((nIndexs >> 24) & 0xFF);

        return colorData;
    }
}
