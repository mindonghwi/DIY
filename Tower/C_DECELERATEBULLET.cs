using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_DECELERATEBULLET : MonoBehaviour, C_SUPERBULLET
{

    private Transform m_trTarget;

    private float m_fExplosionRadius = 0.0f;
    private float m_fdamage;
    private float m_fSpeed = 70.0f;
    private float m_fDownSpeed;

    public void Seek(Transform trTarget, float fDamege, float fExplsingRidius, float fDownSpeed)
    {
        m_trTarget = trTarget;
        m_fdamage = fDamege;
        m_fExplosionRadius = fExplsingRidius;
        m_fDownSpeed = fDownSpeed;
    }


    void Update()
    {

        if (m_trTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = m_trTarget.position - transform.position;
        float distanceThisFrame = m_fSpeed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(m_trTarget);

    }


    void HitTarget()
    {
        if (m_fExplosionRadius >= 0f)
        {
            Explode();
            Damage1(m_trTarget);
        }
        else
        {
            Damage1(m_trTarget);
        }

        Destroy(gameObject);
    }

    void Damage1(Transform enemy)
    {
        C_SUPERMONSTER cSuperMonster = enemy.GetComponent<C_SUPERMONSTER>();
        cSuperMonster.takeDamege(m_fdamage);
        if (cSuperMonster.isDownSpeed())
        {
            cSuperMonster.setDownSpeed(m_fDownSpeed);
        }
   
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_fExplosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage1(collider.transform);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_fExplosionRadius);
    }
}
