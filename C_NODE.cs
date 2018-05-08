using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C_NODE : MonoBehaviour
{
    public Color m_colorHoverColor;
    public Color m_colorNotEnoughMoneyColor;
    public GameObject m_goTower;
    private Renderer m_rendMy;
    private Color m_colorStartColor;

    void Start()
    {
        m_rendMy = GetComponent<Renderer>();
        m_colorStartColor = m_rendMy.material.color;

        m_goTower = null;

    }

}
