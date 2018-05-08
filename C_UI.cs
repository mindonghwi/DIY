using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_UI  {

    private Text m_txtGold;
    private Text m_txtCoinCount;
    private Text m_txtHealth;

    private Text m_txtCoinName;
    private Text m_txtCoinPrice;
    private Text m_txtCoinFlutuation;

    private Text m_txtWaveCount;
    private Text m_txtUpgradeTower;
    public void init()
    {
        m_txtGold = GameObject.Find("Gold").GetComponent<Text>();
        m_txtCoinCount = GameObject.Find("Coin").GetComponent<Text>();
        m_txtHealth = GameObject.Find("Health").GetComponent<Text>();

        m_txtCoinName = GameObject.Find("CoinName").GetComponent<Text>();
        m_txtCoinFlutuation = GameObject.Find("CoinFlu").GetComponent<Text>();
        m_txtCoinPrice = GameObject.Find("CoinPrice").GetComponent<Text>();
        m_txtWaveCount = GameObject.Find("WaveText").GetComponent<Text>();
        m_txtUpgradeTower = GameObject.Find("UpgradeTowerText").GetComponent<Text>();
    }

    public void UpdateUi(C_PLAYER cPlayer, C_GAMECOIN cGameCoin, C_INPUT cInput)
    {
        m_txtGold.text = cPlayer.getGoid().ToString();
        m_txtCoinCount.text = cPlayer.getCoin().ToString();
        m_txtHealth.text = cPlayer.getHealth().ToString();

        m_txtCoinName.text = cGameCoin.getCoinName();
        m_txtCoinFlutuation.text = cGameCoin.getFlutuatuion().ToString()+"%";
        m_txtCoinPrice.text = cGameCoin.getCoinPrice().ToString();
        m_txtUpgradeTower.text = cInput.getUpgradePrice().ToString();
    }

    public void updataWave(C_ENEMYWAVE cEnemyWave)
    {
        int nCount = cEnemyWave.getStageCount() + 1;
        m_txtWaveCount.text = "Wave : " + nCount.ToString();
    }
}
