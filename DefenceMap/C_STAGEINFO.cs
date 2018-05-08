using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_STAGEINFO : MonoBehaviour {
    public enum E_STAGE
    {
        E_STAGE1,
        E_STAGE2,
        E_STAGE3,
        E_STAGE4,
        E_STAGE5,
        E_STAGE6,
        E_STAGE7,
        E_STAGE8,
        E_STAGE9,
        E_STAGE0,
        E_MAX
    }

    private int[] m_arStageMovingPointCount;

    public void init()
    {
        m_arStageMovingPointCount = new int[(int)E_STAGE.E_MAX];
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE1] = 2;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE2] = 6;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE3] = 7;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE4] = 4;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE5] = 6;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE6] = 7;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE7] = 3;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE8] = 8;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE9] = 5;
        m_arStageMovingPointCount[(int)E_STAGE.E_STAGE0] = 4;
    }

    public int getMovingPointCount(C_STAGEINFO.E_STAGE eStage)
    {
        return m_arStageMovingPointCount[(int)eStage];
    }
}
