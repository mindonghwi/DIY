using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ENEMYWAVE : MonoBehaviour {
    [SerializeField]
    private GameObject[] m_arEnemy;
    private GameObject m_goEnemyHolder;
    private bool m_bSpawning;

    [SerializeField]
    private int m_nStageCount;


    [SerializeField]
    private C_PLAYER m_cPlayer;
    private C_GAMECOIN m_cGameCoin;
    private C_SUPERMONSTER[] m_arSuperMonster;
    private float m_fHpPlus;

    private float m_nEnemyCount;

    private bool m_bStartWave;
    private bool m_bNextWave;
    private GameObject m_goStartButton;

    private float m_fDifficultyHp;

    [SerializeField]
    private GameObject[] m_arBoss;


    IEnumerator SpawnWave()
    {
        if (m_nStageCount != 0&& m_nStageCount % 10 == 0)
        {
            SpawnBoss();
            m_nEnemyCount += 20;
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                SpawnEnemy();
                m_nEnemyCount++;
                yield return new WaitForSeconds(0.2f);
            }
        }

    }

    void Awake()
    {
        m_nEnemyCount = 0;
        m_goEnemyHolder = new GameObject();
        m_goEnemyHolder.transform.position = new Vector3(11.0f, 0.0f, 11.0f);
        m_goEnemyHolder.name = "EnemyHolder";
        m_bSpawning = false;
        m_nStageCount = 0;
        m_arEnemy = new GameObject[6];
        m_fHpPlus = 0;
        m_arSuperMonster = new C_SUPERMONSTER[6];
        
        m_bStartWave = false;
        m_bNextWave = true;

        m_fDifficultyHp = 0.0f;

        int nCount = 1;
        for (int i = 0; i < m_arEnemy.Length; i++)
        {
            m_arEnemy[i] = (GameObject)Resources.Load("Enemy/Enemy" + nCount);
            m_arSuperMonster[i] = m_arEnemy[i].GetComponent<C_SUPERMONSTER>();
            nCount++;
        }

        m_arBoss = Resources.LoadAll<GameObject>("Boss");
    }


    void Start()
    {
        m_cGameCoin = GameObject.Find("Player").GetComponent<C_GAMECOIN>();
        m_goStartButton = GameObject.Find("StartHexagon");
        for (int i = 0; i < m_arSuperMonster.Length; i++)
        {
            m_arSuperMonster[i].setPlayer(m_cPlayer);
            m_arSuperMonster[i].setEnemyWave(gameObject.GetComponent<C_ENEMYWAVE>());
        }

        for (int i = 0; i < m_arBoss.Length; i++)
        {
            m_arBoss[i].GetComponent<C_MONSTERBOSS>().setPlayer(m_cPlayer);
            m_arBoss[i].GetComponent<C_MONSTERBOSS>().setEnemyWave(gameObject.GetComponent<C_ENEMYWAVE>());
        }
    }

    private void SpawnEnemy()
    {
        int nRandomSpawn = 0;
        nRandomSpawn = Random.Range(0, ((m_nStageCount / 10)+1));
        //nRandomSpawn = Random.Range(0, 5);
        GameObject goTmpEnemy;
        goTmpEnemy = Instantiate(m_arEnemy[nRandomSpawn], this.gameObject.transform.position,Quaternion.identity);
        goTmpEnemy.transform.parent = m_goEnemyHolder.transform;
    }
    private void SpawnBoss()
    {
        GameObject goTmpBoss;
        goTmpBoss = Instantiate(m_arBoss[m_nStageCount/10], this.gameObject.transform.position, Quaternion.identity);
        goTmpBoss.transform.parent = m_goEnemyHolder.transform;
    }

    void Update()
    {

        if (m_bStartWave)
        {
            if (!m_bSpawning)
            {
                StartCoroutine(SpawnWave());
                m_bSpawning = true;
                m_bStartWave = false;
                m_bNextWave = false;
                m_goStartButton.SetActive(false);
            }
        }

        if (m_nEnemyCount == 20 && m_goEnemyHolder.transform.childCount == 0)
        {
            m_nEnemyCount = 0;
            m_nStageCount++;
            NextStage();
            m_bSpawning = false;
            m_bNextWave = true;
            Debug.Log(m_nStageCount);
        }

    }

    public void setPlayer(C_PLAYER cPlayer)
    {
        m_cPlayer = cPlayer;
    }

    private void NextStage()
    {
        if (m_nStageCount % 10 == 0)
        {
            m_cPlayer.addGold(700);

        }
        m_cPlayer.addGold(300);
        m_cGameCoin.FlututionCoin((m_nStageCount + 1));


        m_fHpPlus = m_fHpPlus + 100.0f * (2.0f * 2.0f * (float)(int)(m_nStageCount / 10) + 2.0f);
        for (int i = 0; i < m_arSuperMonster.Length; i++)
        {
            m_arSuperMonster[i].setHP(m_fHpPlus);
        }

        
       m_goStartButton.SetActive(true);
        

        Debug.Log(m_arSuperMonster[0].getHp());
    }

    public bool getStartWave()
    {
        return m_bStartWave;
    }
    public void startWave()
    {
        m_bStartWave = true;
    }
    public bool getNextWave()
    {
        return m_bNextWave;
    }

    public void setDifficultyHp(float fDifficultyHp)
    {
        m_fDifficultyHp = fDifficultyHp;

        for (int i = 0; i < m_arSuperMonster.Length; i++)
        {
            m_arSuperMonster[i].setDifficultyHp(m_fDifficultyHp);
        }

        for (int i = 0; i < m_arBoss.Length; i++)
        {
            m_arBoss[i].GetComponent<C_MONSTERBOSS>().setDifficultyHp(m_fDifficultyHp);
        }
    }

    public int getStageCount()
    {
        return m_nStageCount;
    }
}


