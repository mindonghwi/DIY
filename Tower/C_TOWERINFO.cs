using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TOWERINFO : MonoBehaviour
{

    public enum E_SNIPER
    {
        E_BCD = 0,
        E_BTG,
        E_BTH,
        E_BTC,
        E_MAX,
    }
    public enum E_MASSACRE
    {
        E_ENT = 0,
        E_LTC,
        E_DASH,
        E_XRD,
        E_MAX,
    }
    public enum E_BOMBING
    {
        E_URG = 0,
        E_MCO,
        E_ETC,
        E_ETH,
        E_MAX,
    }
    public enum E_MAGIC
    {
        E_INK = 0,
        E_KNC,
        E_STEAM,
        E_EOS,
        E_MAX,
    }
    public enum E_DECELERATE
    {
        E_SPC = 0,
        E_GCS,
        E_ZET,
        E_QTUM,
        E_MAX,
    }
    public enum E_NOMAL
    {
        E_GAS = 0,
        E_NEO,
        E_STORM,
        E_IOTA,
        E_MAX,
    }
    public enum E_TOWERCLASSIFICATION
    {
        E_SPINER = 0,
        E_MASSACRE,
        E_BOMBING,
        E_MAGIC,
        E_DECELERATE,
        E_NOMAL,
        E_MAX
    }

    //public static int m_nTowersClassification = 6;
    public static int m_nClassificatedTowerCount = 4;
    public static float m_fUpgradeCount = 0;

    public static float m_fTurnSpeedRotate = 180.0f;
    public static float m_fTurnSpeeds = 1.0f;
}
