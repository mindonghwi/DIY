using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TOWERUPGRADE : MonoBehaviour {

    [SerializeField]
    private float[] m_arTowerAttacking;
    private int m_nUpgradeCount;
    [SerializeField]
    private float[] m_ArTowerAttackingIncrease;
    private GameObject playerManager;
    private int m_nTowerCount;
    //겜 매니저에서 타워가 몇개 들어오고 거기서 몇개의 공격력 초기값이 들어올 것이다.


    public void load(float[][] arAttacking)
    {
        if (m_nTowerCount == 0)
        {
            m_nTowerCount = playerManager.GetComponent<ProductManager>().towers.Count;
        }

        m_arTowerAttacking = new float[m_nTowerCount];
        m_ArTowerAttackingIncrease = new float[m_nTowerCount];

        for (int i = 0; i < m_arTowerAttacking.Length; i++)
        {
            m_arTowerAttacking[i] = arAttacking[i][(int)C_LOADCUSTOMTOWER.E_LISTORDER.E_STRIKING];
            
        }
        m_nUpgradeCount = 0;
    }
    public void init(int nTowerCount)
    {
        m_arTowerAttacking = new float[nTowerCount];
        m_ArTowerAttackingIncrease = new float[nTowerCount];

    }
    public void loadSecond(float fAttacking, int nIndex)
    {

        m_arTowerAttacking[nIndex] = fAttacking;
        m_ArTowerAttackingIncrease[nIndex] = m_arTowerAttacking[nIndex] * 0.06f;
        m_nUpgradeCount = 0;
    }

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager");
        m_nTowerCount = playerManager.GetComponent<ProductManager>().towers.Count;
    }


    public void upgradeTowerAttack(GameObject goTowerHolder)
    {
        m_nUpgradeCount++;

        for (int i = 0; i < m_arTowerAttacking.Length; i++)
        {
            m_arTowerAttacking[i] += m_ArTowerAttackingIncrease[i];
        }

        Debug.Log(goTowerHolder.transform.childCount);
        for (int i = 0; i < goTowerHolder.transform.childCount; i++)
        {
            goTowerHolder.transform.GetChild(i).GetComponent<C_CUSTOMTOWER>().UpgradeTowerAttack(
                m_arTowerAttacking[goTowerHolder.transform.GetChild(i).GetComponent<C_CUSTOMTOWER>().getTowerNum()]);
        }
        
    }

    public float getAttacking(int nIndex)
    {
        return m_arTowerAttacking[nIndex];
    }

    public int getUpgradeCount()
    {
        return m_nUpgradeCount;
    }
}
