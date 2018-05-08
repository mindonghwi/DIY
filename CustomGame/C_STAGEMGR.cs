using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomGame
{
    public class C_STAGEMGR : Object
    {
        private C_CUSTOMGAMEMAP m_cCustomGameMap;
        private C_LOADNODE m_cLoadNode;
        private GameObject[] m_arMovingPoint;
        private Transform[] m_arMovingPointTransform;
        private GameObject m_goMovingPointHolder;



        private void createStage(GameObject goMovingPoint, GameObject goGameTile, GameObject goImGameTile, C_LOADNODE cLoadNode,int nIndex)
        {
            int nWidth = 12;
            int nHeight = 12;

            m_cLoadNode = new C_LOADNODE();
            m_cLoadNode.load();

            m_cCustomGameMap = new C_CUSTOMGAMEMAP();
            m_cCustomGameMap.init(m_cLoadNode, nIndex);
            m_cCustomGameMap.createMap(nWidth, nHeight);

            m_arMovingPoint = new GameObject[m_cCustomGameMap.getRoadCol().Count];
            m_arMovingPointTransform = new Transform[m_cCustomGameMap.getRoadCol().Count];

            Vector3 vUp = new Vector3(0.0f, 1.0f, 0.0f);

            for (int i = 0; i < m_cCustomGameMap.getRoadCol().Count; i++)
            {
                m_arMovingPoint[i] = (GameObject)Instantiate(goMovingPoint,
                    m_cCustomGameMap.getNode(m_cCustomGameMap.getRoadRow()[i], m_cCustomGameMap.getRoadCol()[i]).transform.position + vUp, Quaternion.identity);
            }


            m_goMovingPointHolder = new GameObject();
            m_goMovingPointHolder.name = "MovingPoints";
            m_goMovingPointHolder.tag = "MovingPoints";
            m_goMovingPointHolder.transform.position = new Vector3(11.0f, 0.0f, 11.0f);
            for (int i = 0; i < m_arMovingPoint.Length; i++)
            {
                m_arMovingPoint[i].name = "MovingPoint" + i;
                m_arMovingPoint[i].transform.parent = m_goMovingPointHolder.transform;
                m_arMovingPointTransform[i] = m_arMovingPoint[i].transform;
            }
            
        }

        public void init(GameObject goMovingPoint, GameObject goGameTile, GameObject goGameImTile, C_PLAYER cPlayer, C_LOADNODE cLoadNode, int nIndex)
        {
            createStage(goMovingPoint, goGameTile, goGameImTile, cLoadNode,nIndex);
            getWavePoint().AddComponent<C_ENEMYWAVE>();
            getWavePoint().GetComponent<C_ENEMYWAVE>().setPlayer(cPlayer);
            getWavePoint().GetComponent<C_ENEMYWAVE>().setDifficultyHp(PlayerPrefs.GetFloat("CustomGameDifficulty"));
        }


        public GameObject getEnemyWave()
        {
            return getWavePoint();
        }

        public Transform[] getMovingPoint()
        {
            return m_arMovingPointTransform;
        }
        public GameObject getWavePoint()
        {
            return m_arMovingPoint[0];
        }

        public List<int> getListTowerSelected()
        {
            return m_cCustomGameMap.getTowers();
        }

        public float getDiffculty()
        {
            return m_cCustomGameMap.getDiffculty();
        }
        public int getStartResource()
        {
            return m_cCustomGameMap.getStartResource();
        }
        public int getStartCoinPrice()
        {
            return m_cCustomGameMap.getStartCoinPrice();
        }
    }
}