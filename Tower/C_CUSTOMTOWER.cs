using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CUSTOMTOWER : MonoBehaviour ,C_SUPERTOWER{

    [SerializeField]
    private float m_fTowerDownrange;
    private float m_fTowerAttackSpeed;

    [SerializeField]
    Transform[] m_arTarget;
    Transform m_trPartToRotate;
    private float m_fFireCountdown;
    private int m_nTargetCount;

    [SerializeField]
    private GameObject m_goBullet;
    private GameObject m_goFirePoint;

    private C_TOWERANIMATION m_cAnimation;
    [SerializeField]
    private float m_fStriking;

    private int m_nTowerNumber;


    public void init(float fStriking, float fTowerDownrange, float fTowerAttackSpeed, int nTargetCount , int nTowerNumber)
    {
        m_fTowerDownrange = fTowerDownrange;
        m_fTowerAttackSpeed = fTowerAttackSpeed;
        m_nTargetCount = nTargetCount;
        m_fStriking = fStriking;
        
        m_nTowerNumber = nTowerNumber;

        gameObject.GetComponent<C_TOWERUI>().SetText(fStriking, fTowerDownrange, fTowerAttackSpeed);
    }

    // Use this for initialization
    void Start()
    {
        m_fFireCountdown = m_fTowerAttackSpeed;
        m_trPartToRotate = GetComponent<Transform>();

        m_arTarget = new Transform[m_nTargetCount];
        //m_goBullet = (GameObject)Resources.Load("Bullet");
        m_goFirePoint = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;

        m_cAnimation = gameObject.GetComponent<C_TOWERANIMATION>();

        InvokeRepeating("UpdateTarget", 0f, m_fTowerAttackSpeed);
    }

    private void UpdateTarget()
    {
        if (!GameObject.Find("EnemyHolder"))
        {
            return;
        }
        GameObject goEnemyHolder = GameObject.Find("EnemyHolder");
        Transform[] enemies = new Transform[goEnemyHolder.transform.childCount];
        float fShortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;
        List<Transform> listEnemy = new List<Transform>();

        for (int i = 0; i < goEnemyHolder.transform.childCount; i++)
        {
            enemies[i] = goEnemyHolder.transform.GetChild(i);
            listEnemy.Add(goEnemyHolder.transform.GetChild(i));
        }

        int nTmpEnemyNum = 0;
        for (int i = 0; i < m_nTargetCount; i++)
        {
            for (int j = 0; j < listEnemy.Count; j++)
            {
                float fDistaneToEnemy = Vector3.Distance(transform.position, listEnemy[j].transform.position);
                if (fDistaneToEnemy < fShortestDistance)
                {
                    fShortestDistance = fDistaneToEnemy;
                    nearestEnemy = listEnemy[j];
                    nTmpEnemyNum = j;
                }
            }


            if (nearestEnemy != null && fShortestDistance <= m_fTowerDownrange)
            {
                m_arTarget[i] = nearestEnemy;
                listEnemy.RemoveAt(nTmpEnemyNum);
            }
            else
            {
                m_arTarget[i] = null;
            }

            fShortestDistance = Mathf.Infinity;
        }

        listEnemy.Clear();
    }

    void Update()
    {

        m_fFireCountdown -= Time.deltaTime;

        if (m_arTarget.Length == 0)
        {
            return;
        }



        for (int i = 0; i < m_nTargetCount; i++)
        {

            if (m_arTarget[i] != null)
            {
                //target Lock On
                Vector3 dir = m_arTarget[i].position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(m_trPartToRotate.rotation, lookRotation, Time.deltaTime * C_TOWERINFO.m_fTurnSpeedRotate).eulerAngles;
                m_trPartToRotate.rotation = Quaternion.Euler(0f, rotation.y * C_TOWERINFO.m_fTurnSpeeds, 0f);

                if (m_fFireCountdown <= 0f)
                {
                    m_cAnimation.setAttackAnimation(m_fTowerAttackSpeed);
                    for (int j = 0; j < m_nTargetCount; j++)
                    {
                        Shoot(m_arTarget[j]);
                    }
                    m_cAnimation.setIdleAnimation();
                    m_fFireCountdown = m_fTowerAttackSpeed;

                }

            }

        }

    }

    //bullet
    private void Shoot(Transform trTarget) 
    {
        GameObject goBullet = Instantiate(m_goBullet, m_goFirePoint.transform.position, m_goFirePoint.transform.rotation) as GameObject;
        goBullet.AddComponent<C_BULLET>();
        goBullet.AddComponent<C_BULLETEFFECT>();

        C_SUPERBULLET bullet = goBullet.GetComponent<C_SUPERBULLET>();

        if (bullet != null)
        {
            bullet.Seek(trTarget, m_fStriking, 0.1f,0.0f);
        }

    }
    //Tower range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_fTowerDownrange);
    }

    public void setBullet(GameObject goBullet)
    {
        m_goBullet = goBullet;
    }
    public void setBulletColor(Material mtrBulletMaterial)
    {
        m_goBullet.GetComponent<Renderer>().material = mtrBulletMaterial;
    }
    public void UpgradeTowerAttack(float fNewStriking)
    {
        m_fStriking = fNewStriking;
        gameObject.GetComponent<C_TOWERUI>().SetText(m_fStriking,m_fTowerDownrange,m_fTowerAttackSpeed);
    }


    public int getTowerNum()
    {
        return m_nTowerNumber;
    }

    public float getStriking()
    {
        return m_fStriking;
    }

    public float getDownrange()
    {
        return m_fTowerDownrange;

    }
    public float getAttackSpeed()
    {
        return m_fTowerAttackSpeed;
    }
}
