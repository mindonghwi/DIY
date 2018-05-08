using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C_ROADEDIT :MonoBehaviour
{
    private int[] m_arNodeIndex;

    // Use this for initialization
    void Start () {
        
    }

    void OnMouseEnter()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
    public void setNodeIndex(int nRow, int nCol)
    {
        m_arNodeIndex = new int[2];
        m_arNodeIndex[0] = nRow;
        m_arNodeIndex[1] = nCol;
    }

    public int[] getNodeIndex()
    {
        return m_arNodeIndex;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
