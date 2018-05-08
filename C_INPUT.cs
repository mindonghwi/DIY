using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_INPUT : MonoBehaviour {
    private bool m_bIsBuild;
    private bool m_bIsMerge;
    private C_TOWERUPGRADE m_cTowerUpgrade;

    [SerializeField]
    private C_PLAYER m_cPlayer;
    private C_GAMECOIN m_cGameCoin;
    private C_ENEMYWAVE m_cEnemyWave;

    private bool m_bIsPause;
    private GameObject m_goTowerHolder;
    private bool m_bIsSell;

    private GameObject m_goCoin;
    private Slider m_SldCoin;

    [SerializeField]
    private bool m_bCoinSell;
    [SerializeField]
    private bool m_bCoinBuy;

    //슬라이더 max값을 자신이 살수 있는 코인의 총 양으로 한다.
    // Use this for initialization
    void Start () {
        m_cTowerUpgrade = GameObject.Find("TowerCreater").GetComponent<C_TOWERUPGRADE>();
        m_goCoin = GameObject.Find("MainUiCanvas").transform.GetChild(8).gameObject;
        m_SldCoin = m_goCoin.transform.GetChild(4).GetComponent<Slider>();

        m_bIsPause = false;
        m_bCoinBuy = false;
        m_bCoinSell = false;
        }
    public void load(C_PLAYER cPlayer, C_GAMECOIN cGameCooin ,C_ENEMYWAVE cEnemyWave, GameObject goTowerHolder)
    {
        m_cPlayer = cPlayer;
        m_cGameCoin = cGameCooin;
        m_cEnemyWave = cEnemyWave;
        m_goTowerHolder = goTowerHolder;
    }

    public void onIsBuild()
    {
        m_bIsBuild = true;
        offIsMerge();
        offIsSell();
    }
    public void onIsMerge()
    {
        m_bIsMerge = true;
        offIsBuild();
        offIsSell();
    }
    public void offIsMerge()
    {
        m_bIsMerge = false;
    }
    public void offIsBuild()
    {
        m_bIsBuild = false;
    }
    public void onIsSell()
    {
        m_bIsSell = true;
        offIsBuild();
        offIsMerge();
    }
    public void offIsSell()
    {
        m_bIsSell = false;
    }

    public void TowerUpgrade()
    {
        if (m_cPlayer.getGoid() < m_cTowerUpgrade.getUpgradeCount() * 5)
        {
            return;
        }
        m_cPlayer.upgradeTower(m_cTowerUpgrade.getUpgradeCount());


        m_cTowerUpgrade.upgradeTowerAttack(m_goTowerHolder);

    }
    public int getUpgradePrice()
    {
        return m_cTowerUpgrade.getUpgradeCount() * 5;
    }


   public bool getIsBuild()
    {
        return m_bIsBuild;
    }
    public bool getIsMerge()
    {
        return m_bIsMerge;
    }
    public bool getIsSell()
    {
        return m_bIsSell;
    }


    public void buyCoin()
    {
        m_goCoin.SetActive(true);
        m_SldCoin.value = 0;
        setSliderMax();
        m_bCoinBuy = true;
        m_bCoinSell = false;
        ChangeValue();
    }
    public void sellCoin()
    {
        m_goCoin.SetActive(true);
        m_SldCoin.value = 0;
        m_SldCoin.minValue = 0;
        m_SldCoin.maxValue = m_cPlayer.getCoin();
        m_bCoinSell = true;
        m_bCoinBuy = false;
        ChangeValue();
    }
    public void setSliderMax()
    {
        m_SldCoin.minValue = 1;
        m_SldCoin.maxValue = m_cPlayer.getGoid() / m_cGameCoin.getCoinPrice();
    }

    public void offCoinCount()
    {
        m_goCoin.SetActive(false);
    }

    public void buynSellCoinForCount()
    {
        if (m_bCoinBuy)
        {
            for (int i = 0; i < m_SldCoin.value; i++)
            {
                m_cPlayer.addCoin(1, m_cGameCoin.getCoinPrice());
            }
        }
        else if (m_bCoinSell)
        {
            for (int i = 0; i < m_SldCoin.value; i++)
            {
                m_cPlayer.sellCoin(m_cGameCoin.getCoinPrice());
            }
        }
        m_bCoinSell = false;
        m_bCoinBuy = false;
        offCoinCount();
    }

    

    public void ChangeValue()
    {
        m_goCoin.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = m_SldCoin.value.ToString();
    }

    public void startWave()
    {
        if (m_cEnemyWave.getNextWave())
        {
            m_cEnemyWave.startWave();
        }
    }
    public void upValue()
    {
        m_SldCoin.value++;
        ChangeValue();
    }
    public void downValue()
    {
        m_SldCoin.value--;
        ChangeValue();
    }


    public void setPuase()
    {
        if (m_bIsPause)
        {
            m_bIsPause = false;
            Time.timeScale = 1.0f;

        }
        else
        {
            m_bIsPause = true;
            Time.timeScale = 0.0f;
        }
    }
    public void offPause()
    {
        m_bIsPause = false;
        Time.timeScale = 1.0f;
    }


    public bool getPause()
    {
        return m_bIsPause;
    }


}
