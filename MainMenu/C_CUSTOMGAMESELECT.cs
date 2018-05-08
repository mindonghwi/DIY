using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.U2D;
public class C_CUSTOMGAMESELECT : MonoBehaviour
{

    private GameObject m_goTmpButton;

    private GridLayoutGroup m_lygContent;
    private int nMapCount;


    // Use this for initialization
    void Start()
    {

        float fSellWidthSize = 0;
        float fSellHeightSize = 0;
        fSellWidthSize = gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.width *
            (gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMax.x - gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMin.x) / 2.0f;
        fSellHeightSize = gameObject.transform.parent.parent.parent.GetComponent<RectTransform>().rect.height *
            (gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMax.y - gameObject.transform.parent.parent.GetComponent<RectTransform>().anchorMin.y) / 6.0f;
        m_lygContent = gameObject.GetComponent<GridLayoutGroup>();


        m_lygContent.cellSize = new Vector2(216.0f, 216.0f);

        m_lygContent.spacing = new Vector2(23.0f,0.0f);

        if (!Directory.Exists(Application.persistentDataPath + "/Maps"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Maps");
        }

        int nIndex = 0;
        while (File.Exists(Application.persistentDataPath + "/Maps/" + "CustomMap" + nIndex + ".txt"))
        {
            nIndex++;
        }

        nMapCount = nIndex;
        m_goTmpButton = new GameObject();
        m_goTmpButton.AddComponent<C_CUSTOMMAPBTN>();


        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(216.0f * nMapCount + 23.0f * (float)(nMapCount-1), 216.0f);


        GameObject goTmpMap;
        for (int i = 0; i < nMapCount; i++)
        {
            goTmpMap = Instantiate(m_goTmpButton);
            goTmpMap.transform.SetParent(gameObject.transform);
            goTmpMap.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            goTmpMap.GetComponent<C_CUSTOMMAPBTN>().init(i);
            goTmpMap.GetComponent<C_CUSTOMMAPBTN>().parse();
            goTmpMap.GetComponent<C_CUSTOMMAPBTN>().ReturnData();
        }

    }



}
