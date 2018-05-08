using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace MapEdit
{
    public class C_TOWERSELECT : MonoBehaviour
    {
        private C_LOADDATA m_cLoadData;
        private C_MYTOWERPROC m_cMyTowerProc;
        private GameObject goTmpNode;
        private Toggle[] m_tgTest;
        int m_nTowerIndex = 0;

        GraphicRaycaster gr;
        PointerEventData ped;
        private GameObject playerManager;
        void Start()
        {
            m_cMyTowerProc = new C_MYTOWERPROC();
            m_cLoadData = GameObject.Find("LoadData").GetComponent<C_LOADDATA>();
            m_cMyTowerProc.init();

            playerManager = GameObject.Find("PlayerManager");

            gameObject.GetComponent<C_MAPEDITMR>().setBool(playerManager.GetComponent<ProductManager>().towers.Count);

            m_tgTest = new Toggle[playerManager.GetComponent<ProductManager>().towers.Count];


            settingView();
            gr = GameObject.Find("MainCanvas").GetComponent<GraphicRaycaster>();
            ped = new PointerEventData(null);
        }
        

        private void settingView()
        {
            float fSellWidthSize = 250.0f;
            float fSellHeightSize = 80.0f;

            GameObject goTowerContents = GameObject.Find("MainCanvas").transform.GetChild(4).GetChild(1).GetChild(1).GetChild(0).GetChild(0).gameObject;
            GameObject goTowerSelectNode = (GameObject)Resources.Load("TowerButton");

            Sprite[] arTowerImage = Resources.LoadAll<Sprite>("TowerSelect");
            

            goTowerContents.GetComponent<GridLayoutGroup>().cellSize = new Vector2(fSellWidthSize, fSellHeightSize);

            goTowerContents.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, ((fSellHeightSize) + goTowerContents.GetComponent<GridLayoutGroup>().spacing.y) * (float)playerManager.GetComponent<ProductManager>().towers.Count);

            int nSpIndex = 0;
            for (int i = 0; i < playerManager.GetComponent<ProductManager>().towers.Count; i++)
            {
                goTmpNode = Instantiate(goTowerSelectNode);

                if (i < arTowerImage.Length)
                {
                    nSpIndex = i;
                }
                else
                {
                    nSpIndex = arTowerImage.Length - 1;
                }

                goTmpNode.transform.GetChild(0).GetComponent<Image>().sprite = arTowerImage[nSpIndex];
                goTmpNode.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
                goTmpNode.transform.SetParent(goTowerContents.transform);

                m_tgTest[i] = goTmpNode.transform.GetChild(1).GetComponent<Toggle>();
                m_tgTest[i].gameObject.AddComponent<C_TOWERINOUT>();
                m_tgTest[i].gameObject.GetComponent<C_TOWERINOUT>().setIndex(i);

                goTmpNode.transform.GetChild(1).GetComponent<Toggle>().onValueChanged.AddListener(((value) => ToggleValueChanged(value, nSpIndex)));

                goTmpNode.GetComponent<RectTransform>().sizeDelta = new Vector2(fSellWidthSize, fSellHeightSize);
                goTmpNode.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);

            }
            Debug.Log(goTmpNode.transform.parent.parent.parent.parent.parent.parent.name);
        }

        void ToggleValueChanged(bool value, int nIndex)
        {

            ped.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>(); // 여기에 히트 된 개체 저장 
            gr.Raycast(ped, results);
            if (results.Count != 0)
            {
                GameObject obj = results[1].gameObject.transform.parent.gameObject;
                Debug.Log(obj.name);
                m_nTowerIndex = obj.transform.GetComponent<C_TOWERINOUT>().m_nIndex;

            }

            m_tgTest[m_nTowerIndex].gameObject.GetComponent<C_TOWERINOUT>().setSelected(m_tgTest[m_nTowerIndex].isOn);

            m_tgTest[m_nTowerIndex].transform.parent.parent.parent.parent.parent.parent.parent.GetComponent<C_MAPDETAILBTNCTN>().btnSelectedTower(m_nTowerIndex);

            Debug.Log(m_nTowerIndex);
        }


        //public void Tmp()
        //{
        //    int nIndex = 0;
        //    Vector3 vecTowerPos = new Vector3(0.0f, 0.0f, 0.0f);
        //    float fRow = 0.0f;
        //    float fCol = 0.0f;

        //    Debug.Log(m_cLoadData);

        //    while (nIndex < m_cLoadData.getLoadCustomTower().getTowerCount())
        //    {
        //        if (nIndex %4 == 0)
        //        {
        //            fRow += 4.0f;
        //            fCol = 0.0f;
        //        }
        //        vecTowerPos.x = fRow;
        //        vecTowerPos.y = fCol;

        //        m_cMyTowerProc.mapEditCreateTower(m_goTowerHolder, m_cLoadData, nIndex, vecTowerPos);

        //        fCol += 4.0f;

        //        nIndex++;
        //    }
        //}

        public void CreateTower(GameObject goTmpTower, int nIndex)
        {
            Vector3 vecTowerPos = new Vector3(0.0f, 0.0f, 0.0f);
            m_cMyTowerProc.mapEditCreateTower(goTmpTower, m_cLoadData, nIndex, vecTowerPos);
        }


        public int getTowerCount()
        {
            return m_cLoadData.getLoadCustomTower().getTowerCount();
        }
    }

    public class C_TOWERINOUT : MonoBehaviour
    {
        public int m_nIndex;
        public bool m_bSelected;
        public void setIndex(int nIndex)
        {
            m_nIndex = nIndex;
        }
       public void setSelected(bool bSelected)
        {
            m_bSelected = bSelected;
        }
    }
}