using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LOADNODE {

    private GameObject[] m_arImpossibleNode;
    private GameObject[] m_arPossibleNode;


    public void load()
    {
        m_arImpossibleNode = new GameObject[2];
        m_arPossibleNode = new GameObject[2];

        int nCount = 1;
        for (int i = 0; i < m_arPossibleNode.Length; i++)
        {
            m_arImpossibleNode[i] = (GameObject)Resources.Load("MapPrefab/BlockLight" + nCount);
            m_arPossibleNode[i] = (GameObject)Resources.Load("MapPrefab/GroundPiece" + nCount);
            nCount++;
        }
    }

    public GameObject getImpossibleNode(int nCount)
    {
        return m_arImpossibleNode[nCount];
    }
    public GameObject getPossibleNode(int nCount)
    {
        return m_arPossibleNode[nCount];
    }
}
