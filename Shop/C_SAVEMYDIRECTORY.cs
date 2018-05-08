using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class C_SAVEMYDIRECTORY : MonoBehaviour {

    private C_LOADCUSTOMMAPDATA m_cLoadCustomMapData;

	// Use this for initialization
	void Start () {
        m_cLoadCustomMapData = GameObject.Find("LoadData").GetComponent<C_LOADCUSTOMMAPDATA>();

	}

    public void savingData()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Maps"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Maps");
        }

        int nIndex = 0;
        while (File.Exists(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt"))
        {
            nIndex++;
        }



        FileStream fs = new FileStream(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt", FileMode.Create, FileAccess.Write);
        byte[] data = new byte[4000];


        data = Encoding.Default.GetBytes(m_cLoadCustomMapData.getMapStrData());
        fs.Write(data, 0, m_cLoadCustomMapData.getMapStrData().Length);

        fs.Close();


        CheckInData(nIndex);

    }

    public void CheckInData(int nIndex)
    {
        while (!File.Exists(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt"))
        {

        }
        Destroy(gameObject);
    }

}
