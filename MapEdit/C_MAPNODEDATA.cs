using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MAPNODEDATA
{

    private TextAsset m_txtaMapData;

    // Use this for initialization
    public void init()
    {
        m_txtaMapData = (TextAsset)Resources.Load("MapData");
    }

    public void Parse(int[,] arMapNodeData)
    {
        int nOffsetIndex = 0;
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                arMapNodeData[i, j] = m_txtaMapData.text[nOffsetIndex] - 48;
                nOffsetIndex++;
            }
            nOffsetIndex += 2;
        }

    }

    public void release()
    {
        Resources.UnloadUnusedAssets();
    }
}
