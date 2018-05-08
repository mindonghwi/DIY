using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LOADAURA{

    [SerializeField]
    Object[] m_arTowerEffect;

    public enum E_AURAEFFECT
    {
        E_ARCANE = 0,
        E_EARTH,
        E_FIRE,
        E_FROST,
        E_LIFE,
        E_LIGHT,
        E_LIGHTNING,
        E_SHADOW,
        E_STORM,
        E_WATER,
        E_MAX
    }

    // Use this for initialization
    public void init()
    {
        m_arTowerEffect = Resources.LoadAll("Effect/AuraRing");
    }


    public Object getTowerAuraEffect(C_LOADAURA.E_AURAEFFECT eAuraEffect)
    {
        return m_arTowerEffect[(int)eAuraEffect];
    }
}
