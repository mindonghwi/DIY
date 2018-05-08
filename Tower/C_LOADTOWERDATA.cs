using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class C_LOADTOWERDATA{

    private FileStream m_fsTowerData;
    private StreamWriter m_swWriter;
    private StreamReader m_srReader;
    private uint[] m_arListOrderIntData = new uint[(int)E_LISTORDERINT.E_MAX];
    private float[] m_arListOrderFloatData = new float[(int)E_LISTORDERFLOAT.E_MAX];

    private int m_nTowerCount;

    public enum E_LISTORDERINT
    {
        E_ID = 0,
        E_FACE,
        E_WEAPON,
        E_CLOTH,
        E_HEAD,
        E_HEADMATERIAL,
        E_AURA,
        E_BULLET,
        E_TARGETCOUNT,
        E_GRADE,
        E_HAIRCOLOR,
        E_BULLETCOLOR,
        E_MAX
    }
    public enum E_LISTORDERFLOAT
    {
        E_STRIKING,
        E_SPEEDOFSTRIKING,
        E_DOWNRANGE,
        E_MAX
    }
    // Use this for initialization
    public void init () {

        
        string strpath = "Assets/Resources/TowerTableData.txt";
        if (Application.platform == RuntimePlatform.Android)
        {
            strpath = pathForDocumentsFile("TowerTableData");

            //strpath = Application.persistentDataPath + "/" + "TowerTableData.txt";
        }
        m_fsTowerData = new FileStream(strpath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        m_srReader = new StreamReader(m_fsTowerData);
        m_fsTowerData.Seek(0,SeekOrigin.Begin);
    }

    public void release()
    {
        m_srReader.Close();
        m_fsTowerData.Close();
    }

    public void setTowerCount()
    {
        m_nTowerCount = 0;
        init();
        while (!m_srReader.EndOfStream)
        {
            m_srReader.ReadLine();
            m_nTowerCount++;
        }
        release();
    }

    public void Parse()
    {
        
        char[] arReadData = new char[10];
        int[] arReadBufferCount = { 2, 1, 1, 2, 1, 2, 1, 1, 1,1, 10, 1, 6, 4, 4 };
        m_arListOrderIntData = new uint[(int)E_LISTORDERINT.E_MAX];
        m_arListOrderFloatData = new float[(int)E_LISTORDERFLOAT.E_MAX];

        int nBufferIndex = 0;
        for (int i = 0; i < (int)E_LISTORDERINT.E_MAX; i++)
        {
            m_srReader.Read(arReadData, 0, arReadBufferCount[nBufferIndex]);
            m_srReader.Read();

            m_arListOrderIntData[i] = (uint)changeCharToInt(arReadData, arReadBufferCount[nBufferIndex]);
            nBufferIndex++;
        }

        for (int i = 0; i < (int)E_LISTORDERFLOAT.E_MAX; i++)
        {
            m_srReader.Read(arReadData, 0, arReadBufferCount[nBufferIndex]);
            m_srReader.Read();

            m_arListOrderFloatData[i] = changeCharToFloat(arReadData, arReadBufferCount[nBufferIndex]);
            nBufferIndex++;
        }

        m_srReader.Read();
        m_srReader.Read();
    }

    public void SavingCustomTower(string strCustomTower)
    {
        m_fsTowerData = new FileStream("Assets/Resources/TowerTableData.txt", FileMode.Append, FileAccess.Write);

        m_swWriter = new StreamWriter(m_fsTowerData);
        m_swWriter.WriteLine(strCustomTower);
        m_swWriter.Close();
    }

    private int changeCharToInt(char[] arReadData, int nBufferSize)
    {
        int nData = 0;
        int nChpher = nBufferSize - 1;

        for (int i = 0; i < nBufferSize; i++)
        {
            nData += (arReadData[i] - 48) * (int)(Mathf.Pow(10.0f, (float)nChpher));
            nChpher -= 1;
        }

        return nData;
    }

    private float changeCharToFloat(char[] arReadData, int nBufferSize)
    {
        float fData = 0.0f;

        string strTmp = new string(arReadData, 0, nBufferSize);

        float.TryParse(strTmp, out fData);
        
        
        return fData;
    }

    public uint[] GetNTowerData()
    {
        return m_arListOrderIntData;
    }
    public float[] GetFTowerData()
    {
        return m_arListOrderFloatData;
    }

    public int getTowerCount()
    {
        return m_nTowerCount;
    }

    public void writeStringToFile(string str, string filename)
    {
#if !WEB_BUILD
        string path = pathForDocumentsFile(filename);
        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(str);

        sw.Close();
        file.Close();
#endif
    }


    public string readStringFromFile(string filename)//, int lineIndex )
    {
#if !WEB_BUILD
        string path = pathForDocumentsFile(filename);

        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;
            str = sr.ReadLine();

            sr.Close();
            file.Close();

            return str;
        }

        else
        {
            return null;
        }
#else
return null;
#endif
    }


    public string pathForDocumentsFile(string filename)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), filename);
        }

        else if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }

        else
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
    }
}
