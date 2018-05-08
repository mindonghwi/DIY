using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LOADBULLET{

    [SerializeField]
    private GameObject[] m_arBullet;
    private Material[] m_arBulletTexture;
	// Use this for initialization
	public void init() {
        m_arBullet = Resources.LoadAll<GameObject>("Bullet/Rocket Pack/Prefabs/Grey");
        m_arBulletTexture = Resources.LoadAll<Material>("Bullet/Rocket Pack/Materials");
    }

    public GameObject getBullet(int nIndex)
    {
        return m_arBullet[nIndex];
    }

    public Material getBulletMaterial(int nIndex)
    {
        return m_arBulletTexture[nIndex];
    }
}
