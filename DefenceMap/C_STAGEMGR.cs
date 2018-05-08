using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_STAGEMGR {

    private C_SUPERSTAGE m_cStage = new C_NOMALSTAGE();
    public static C_STAGEINFO.E_STAGE m_eStage = C_STAGEINFO.E_STAGE.E_MAX;

    public void init(GameObject goMovingPoint, GameObject goGameTile, GameObject goGameImTile, C_PLAYER cPlayer, C_LOADNODE cLoadNode, float fDifficultyHp)
    {
        m_cStage.createStage(goMovingPoint, goGameTile, goGameImTile, cLoadNode);
        m_cStage.getWavePoint().AddComponent<C_ENEMYWAVE>();
        m_cStage.getWavePoint().GetComponent<C_ENEMYWAVE>().setPlayer(cPlayer);
        m_cStage.getWavePoint().GetComponent<C_ENEMYWAVE>().setDifficultyHp(fDifficultyHp);
    }
    public GameObject getStageNode(int nRow, int nCol)
    {
        return m_cStage.getDefenceMap().getTilePoint(nRow, nCol);
    }

    public Transform[] getStageMovingPoint()
    {
        return m_cStage.getMovingPoint();
    }

    public GameObject getEnemyWave()
    {
        return m_cStage.getWavePoint();
    }

    public void release()
    {
        m_cStage = null;
    }

}
