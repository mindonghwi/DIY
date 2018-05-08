using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_GAMESETTING : MonoBehaviour {
    [SerializeField]
    private Dropdown m_ddDifficulty;
    private Dropdown m_ddStartResource;
    private Dropdown m_ddStartCoinPrice;

    private float[] m_arDifficultySettingValue;
    private int[] m_arStartResourceSettingValue;
    private int[] m_arStartCoinPriceSettingValue;

    // Use this for initialization
    void Start()
    {
        //30 (012) 1
        m_ddDifficulty = GameObject.Find("Canvas").transform.GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetComponent<Dropdown>();
        m_ddStartResource = GameObject.Find("Canvas").transform.GetChild(2).GetChild(0).GetChild(1).GetChild(1).GetComponent<Dropdown>();
        m_ddStartCoinPrice = GameObject.Find("Canvas").transform.GetChild(2).GetChild(0).GetChild(2).GetChild(1).GetComponent<Dropdown>();

        init();
    }

    private void init()
    {
        m_arDifficultySettingValue = new float[3];
        m_arStartCoinPriceSettingValue = new int[3];
        m_arStartResourceSettingValue = new int[3];

        int nTmpCoinPrice = 200;
        int nTmpStartResource = 300;
        for (int i = 0; i < 3; i++)
        {
            m_arDifficultySettingValue[i] = (float)(i + 1);
            m_arStartCoinPriceSettingValue[i] = nTmpCoinPrice;
            m_arStartResourceSettingValue[i] = nTmpStartResource;

            nTmpCoinPrice += 300;
            nTmpStartResource += 500;

        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void btnDataPass()
    {
        PlayerPrefs.SetFloat("difficultyHp", m_arDifficultySettingValue[m_ddDifficulty.value]);
        PlayerPrefs.SetInt("coinPrice", m_arStartCoinPriceSettingValue[m_ddStartCoinPrice.value]);
        PlayerPrefs.SetInt("StartResource", m_arStartResourceSettingValue[m_ddStartResource.value]);

        PlayerPrefs.SetInt("difficultyReward", 1 + m_ddDifficulty.value - m_ddStartResource.value);
    }
}
