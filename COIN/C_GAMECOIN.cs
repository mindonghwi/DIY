using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GAMECOIN : MonoBehaviour {

    private int m_nCoinPrice;
    private int m_nFlutuation;
    private string m_strCoinName;
    private GameObject m_goUp;
    private GameObject m_goDown;

    private int m_nOverFluCount;
    private int m_nUnderFluCount;
    private int m_nMinFlu;
    private int m_nMaxFlu;
    public void init(int nCoinPrice)
    {
        m_nCoinPrice = nCoinPrice;
        m_strCoinName = "MerciCoin";
        m_goUp = GameObject.Find("UpFlu");
        m_goDown = GameObject.Find("DownFlu");
        m_nOverFluCount = 1;
        m_nUnderFluCount = 1;
        m_nMinFlu = -200;
        m_nMaxFlu = 200;
    }

    public void FlututionCoin(int nStageCount)
    {
        
        m_nFlutuation = (Random.Range(m_nMinFlu / m_nUnderFluCount, m_nMaxFlu / m_nOverFluCount)/10 * nStageCount);
        m_nCoinPrice += m_nCoinPrice * m_nFlutuation / 100;

        if (m_nFlutuation > 0)
        {
            m_goUp.SetActive(true);
            m_goDown.SetActive(false);
            m_nOverFluCount++;
            if (m_nCoinPrice > 20)
            {
                m_nMaxFlu = m_nMaxFlu / 2;
            }
        }
        else if(m_nFlutuation < 0)
        {
            m_goUp.SetActive(false);
            m_goDown.SetActive(true);
            m_nUnderFluCount++;
            m_nMinFlu = m_nMinFlu / 4;
        }
        else
        {
            m_goUp.SetActive(false);
            m_goDown.SetActive(false);
        }

        if (m_nOverFluCount > 1 && m_nUnderFluCount > 1)
        {
            m_nOverFluCount = 1;
            m_nUnderFluCount = 1;
            m_nMaxFlu = 200;
            m_nMinFlu = -200;
        }

        if (m_nCoinPrice < 2)
        {
            m_nMaxFlu = 400;
            m_nCoinPrice = 2;
        }


    }

    public void buyCoin(C_PLAYER cPlayer)
    {
        cPlayer.addCoin(1,m_nCoinPrice);
    }

    public int getCoinPrice()
    {
        return m_nCoinPrice;
    }
    public int getFlutuatuion()
    {
        return m_nFlutuation;
    }
    public string getCoinName()
    {
        return m_strCoinName;
    }

}
