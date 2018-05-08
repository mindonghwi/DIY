using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BUTTON : MonoBehaviour {

    [SerializeField]
    private GameObject m_goCus;

	// Use this for initialization
	void Start () {
        m_goCus = GameObject.Find("Cus");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void button0()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setMaterial(0);
    }

    public void button1()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setMaterial(1);
    }
    public void button2()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setMaterial(2);
    }
    public void button3()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setMaterial(3);
    }
    public void button4()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setMaterial(4);
    }
    public void button5()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setMaterial(5);
    }

    public void btnHair1()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(0);
    }
    public void btnHair2()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(1);
    }
    public void btnHair3()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(2);
    }
    public void btnHair4()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(3);
    }

    public void btnWeapon1()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setWeapon(0);
    }
    public void btnWeapon2()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setWeapon(1);
    }
    public void btnFace1()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setFace(0);
    }
    public void btnFace2()
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setFace(1);
    }

    public void btnCustomTowerUpDate()
    {
        m_goCus.GetComponent<C_CREATETOWER>().upgradeTowerData();
    }




    //public void btnHairMaterial0()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(0);
    //}
    //public void btnHairMaterial1()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(1);
    //}
    //public void btnHairMaterial2()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(2);
    //}
    //public void btnHairMaterial3()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(3);
    //}
    //public void btnHairMaterial4()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(4);
    //}
    //public void btnHairMaterial5()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(5);
    //}
    //public void btnHairMaterial6()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(6);
    //}
    //public void btnHairMaterial7()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(7);
    //}
    //public void btnHairMaterial8()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(8);
    //}
    //public void btnHairMaterial9()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(9);
    //}
    //public void btnHairMaterial10()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(10);
    //}
    //public void btnHairMaterial11()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(11);
    //}
    //public void btnHairMaterial12()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(12);
    //}
    //public void btnHairMaterial13()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(13);
    //}
    //public void btnHairMaterial14()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(14);
    //}
    //public void btnHairMaterial15()
    //{
    //    m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHair(15);
    //}
    public void btnHairMaterial(int nIndex)
    {
        m_goCus.GetComponent<C_CUSTOMIZINGCLOTH>().setHairMaterial(nIndex);
    }

}
