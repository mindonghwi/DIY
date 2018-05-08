using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MONSTERBETA : MonoBehaviour,C_SUPERMONSTER {

    private C_MONSTERSTATUS m_cMonsterStatus;
    private C_ENEMYMOVE m_cEnenyMove;
    private Transform[] m_arTargetTransform;
    private int m_nTargetCount;
    private GameObject m_goTmpTargetParent;
    private int m_nNextTarget;
    private bool m_bSpeedDown;
    [SerializeField]
    private float m_fPlusHp;

    [SerializeField]
    private C_PLAYER m_cPlayer;

    [SerializeField]
    private float m_fDifficultyHp;

    [SerializeField]
    private C_ENEMYWAVE m_cEnemyWave;


    void Awake()
    {
        m_goTmpTargetParent = GameObject.Find("MovingPoints");
        m_nTargetCount = m_goTmpTargetParent.transform.childCount;
        m_arTargetTransform = new Transform[m_nTargetCount];
        m_bSpeedDown = false;
        if (m_cEnemyWave.getStageCount() == 0)
        {
            m_fPlusHp = 0.0f;
        }

        m_cEnenyMove = new C_ENEMYMOVE();
    }
    // Use this for initialization
    void Start()
    {
        m_cMonsterStatus = new C_MONSTERSTATUS();
        float fHp = (100.0f + m_fPlusHp) * m_fDifficultyHp;
        m_cMonsterStatus.init(fHp, 4.5f, 0.0f);

        for (int i = 0; i < m_nTargetCount; i++)
        {
            m_arTargetTransform[i] = m_goTmpTargetParent.transform.GetChild(i);
        }
        m_nNextTarget = 1;
        Debug.Log(fHp);
    }

    void Update()
    {
        if (m_cMonsterStatus.getHp() <= 0.0f || m_nNextTarget == m_arTargetTransform.Length)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        m_nNextTarget = m_cEnenyMove.MoveNomal(this.gameObject, m_arTargetTransform, m_cMonsterStatus.getSpeed() * 5.0f, m_nNextTarget, m_cPlayer);
    }


    public void takeDamege(float fDamege)
    {
        m_cMonsterStatus.hpDown(fDamege);
    }
    public bool isDownSpeed()
    {
        return m_bSpeedDown;
    }
    public void setDownSpeed(float fDownSpeed)
    {
        if (m_bSpeedDown)
        {
            return;
        }
        m_cMonsterStatus.setDownSpeed(fDownSpeed);
        m_bSpeedDown = true;

    }
    public float getHp()
    {
        return m_fPlusHp;
    }
    public void setPlayer(C_PLAYER cPlayer)
    {
        m_cPlayer = cPlayer;
    }
    public void setHP(float fHp)
    {
        m_fPlusHp = fHp;
    }
    void OnDestroy()
    {
        Debug.Log(m_cPlayer.getHealth());
        if (m_nNextTarget == m_arTargetTransform.Length)
        {
            m_cPlayer.downHealth();
        }
    }
    public void setDifficultyHp(float fDifficultyHp)
    {
        m_fDifficultyHp = fDifficultyHp;
    }

    public void setEnemyWave(C_ENEMYWAVE cEnemyWave)
    {
        m_cEnemyWave = cEnemyWave;
    }
}
