using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class C_DEFENCEMAP:Object  {

    private GameObject[,] m_arMarsMap;
    private GameObject m_goMarsMapHolder;

    private C_LOADNODE m_cLoadNode;

    private int[,] m_arDefenceMapIndex;

    public void init(C_LOADNODE cLoadNode)
    {
        m_goMarsMapHolder = new GameObject();
        m_goMarsMapHolder.transform.position = new Vector3(11.0f, 0.0f, 11.0f);
        m_cLoadNode = cLoadNode;
    }

    public void createMap(int nWidth, int nHeight)
    {
        m_goMarsMapHolder.name = "MarsMaps";
        m_arMarsMap = new GameObject[nWidth, nHeight];
        m_arDefenceMapIndex = new int[nWidth, nHeight];

        GameObject goTmpTile = null;
        Vector3 vecMapPosition = new Vector3(0.0f, 0.0f, 0.0f);
        float fMapScale = 2.0f;
        int nCount = 1;
        int nNodeIndex = 0;
        for (int i = 0; i < nWidth; i++)
        {
            for (int j = 0; j < nHeight; j++)
            {
                vecMapPosition = new Vector3((float)i * fMapScale, 0.0f, (float)j * fMapScale);

                if ((i + j) % 2 == 1)
                {
                    nNodeIndex = 1;
                }
                else
                {
                    nNodeIndex = 0;
                }



                if ((i == 0 && j ==5) || (i == 0 && j == 6)|| (j == 0 && i == 5) || (j == 0 && i == 6) 
                    || (i == 11 && j == 5) || (i == 11 && j == 6) || (j == 11 && i == 5) || (j == 11 && i == 6))
                {
                    goTmpTile = (GameObject)Instantiate(m_cLoadNode.getPossibleNode(nNodeIndex), vecMapPosition, Quaternion.identity);
                }
                else if (i == 0 || i == 4 || i == 7 || i == 11 || j == 0 || j == 4 || j == 7 || j == 11)
                {
                    goTmpTile = (GameObject)Instantiate(m_cLoadNode.getImpossibleNode(nNodeIndex), vecMapPosition, Quaternion.identity);
                }
                else
                {
                    goTmpTile = (GameObject)Instantiate(m_cLoadNode.getPossibleNode(nNodeIndex), vecMapPosition, Quaternion.identity);
                }


                m_arMarsMap[i, j] = goTmpTile;
                m_arMarsMap[i, j].name = "Tile" + nCount;
                m_arMarsMap[i, j].transform.parent = m_goMarsMapHolder.transform;

                
                nCount++;
            }


            
        }


    }


    public GameObject getTilePoint(int nRow, int nCol)
    {
        return m_arMarsMap[nRow,nCol];
    }

}
