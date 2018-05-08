using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserManager;

public class C_WRITEDATA : MonoBehaviour {

    //private C_LOADTOWERDATA m_cLoadTawerData;
    private C_DATASETTING m_cDataSetting;

    private GameObject playerManager;
    private string url;

   

	// Use this for initialization
	void Start () {
        playerManager = GameObject.Find("PlayerManager");
        url = playerManager.GetComponent<PlayerManager>().url;

        //m_cLoadTawerData = new C_LOADTOWERDATA();
        //m_cLoadTawerData.setTowerCount();
        m_cDataSetting = GameObject.Find("MainCanvas").GetComponent<C_DATASETTING>();
    }
	
    public void WriteData()
    {
        string strTowerData = "";
        

        string strAttack;
        string strDwonRange;
        if (m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()) < 10)
        {
            strAttack = "000" + m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()).ToString("N1");
        }
        else if (m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()) < 100)
        {
            strAttack = "00" + m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()).ToString("N1");
        }
        else if (m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()) < 1000)
        {
            strAttack = "0" + m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()).ToString("N1");
        }
        else
        {
            strAttack = m_cDataSetting.getStrikingRealValue(m_cDataSetting.getGrade()).ToString("N1");
        }


        if (m_cDataSetting.getDownRangeRealValue(m_cDataSetting.getGrade()) < 10)
        {
            strDwonRange = "0" + m_cDataSetting.getDownRangeRealValue(m_cDataSetting.getGrade()).ToString("N1");
        }
        else
        {
            strDwonRange = m_cDataSetting.getDownRangeRealValue(m_cDataSetting.getGrade()).ToString("N1");
        }
        int nTmpGrade = m_cDataSetting.getGrade() + 1;
        strTowerData = playerManager.GetComponent<ProductManager>().towers.Count.ToString() + gameObject.GetComponent<C_CUSTOMCHARECTER>().getStrTowerNomal() 
            + m_cDataSetting.getTargetCount() + "/"+ nTmpGrade + "/" +
            gameObject.GetComponent<C_CUSTOMCHARECTER>().getStrTowerSub() 
            + strAttack + "/"
            + m_cDataSetting.getAttackSpeedRealValue(m_cDataSetting.getGrade()).ToString("N2") + "/"
            + strDwonRange + "/";

        Tower temp = new Tower(strTowerData);
        url += "/api/tower";
        Debug.Log(url + " " + temp.getJson());

        playerManager.GetComponent<HttpManager>().POST(url, temp.getJson());


        //m_cLoadTawerData.SavingCustomTower(strTowerData);
    }

}
