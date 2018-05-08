using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MONSTERSTATUS  {

    private float m_fMonsterHp;
    private float m_fMonsterSpeed;

    private float m_fMonsterDefencing;




    public void init(float fMonsterHp, float fMonsterSpeed , float fMonsterDefencing)
    {

        m_fMonsterDefencing = fMonsterDefencing;
        m_fMonsterHp = fMonsterHp;
        m_fMonsterSpeed = fMonsterSpeed;

    }

    public void setDownSpeed(float fSpeed)
    {
        m_fMonsterSpeed -= fSpeed;
    }

    public float getDefencing()
    {
        return m_fMonsterDefencing;
    }

    public float getHp()
    {
        return m_fMonsterHp;
    }
    public float getSpeed()
    {
        return m_fMonsterSpeed;
    }

    public void hpDown(float fDemege)
    {
        m_fMonsterHp -= fDemege;
    }
    public void setHp(float fHpPlus)
    {
        m_fMonsterHp += fHpPlus;
    }


}
