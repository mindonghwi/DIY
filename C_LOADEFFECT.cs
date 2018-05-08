using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LOADEFFECT{

    public enum E_EFFECT
    {
        E_BOOM1 = 0,
        E_BOOM2,
        E_ENEMYBLAST,
        E_EXPLODE01,
        E_EXPLODE02,
        E_FIREWORK,
        E_HIT,
        E_HIT2,
        E_SHINE,
        E_MAX,
    }

    private Object[] m_arEffect;

    public void init()
    {
        m_arEffect = Resources.LoadAll("Effect/Prefabs");
    }

    public Object getEffect(E_EFFECT eEffect)
    {
        return m_arEffect[(int)eEffect];
    }

}
