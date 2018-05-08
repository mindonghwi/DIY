using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface C_SUPERSTAGE{

    void createStage(GameObject goMovingPoint, GameObject goGameTile, GameObject goImGameTile, C_LOADNODE cLoadNode);
    Transform[] getMovingPoint();
    GameObject getWavePoint();
    C_DEFENCEMAP getDefenceMap();
}
