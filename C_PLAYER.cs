using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PLAYER : MonoBehaviour {
    private int m_nGold;
    private int m_nCoin;
    [SerializeField]
    private int m_nHealth;
    public void init(int nGold, int nCoin, int nHealth)
    {
        m_nGold = nGold;
        m_nCoin = nCoin;
        m_nHealth = nHealth;
    }

    public void addGold(int nGoid)
    {
        m_nGold += nGoid;
    }

    public void addCoin(int nCoin, int nCoinPrice)
    {
        if(m_nGold < nCoinPrice)
        {
            return;
        }
        m_nCoin += nCoin;
        m_nGold -= nCoinPrice;
    }
    public void buyTower()
    {
        m_nGold -= 100;
    }
    public void sellCoin(int nCoinPrice)
    {
        if (m_nCoin  <= 0)
        {
            return;
        }
        m_nCoin--;
        m_nGold += nCoinPrice;
    }
    public void upgradeTower(int nUpgradeCount)
    {
        m_nGold -= nUpgradeCount * 5;
    }
    public int getGoid()
    {
        return m_nGold;
    }
    public int getCoin()
    {
        return m_nCoin;
    }
    public int getHealth()
    {
        return m_nHealth;
    }
    public void downHealth()
    {
        if (m_nHealth == 0)
        {
            
            return;
        }
        m_nHealth -= 1;
    }
}
