using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface C_SUPERMONSTER{
    void takeDamege(float fDamege);
    bool isDownSpeed();
    void setDownSpeed(float fDownSpeed);
    void setPlayer(C_PLAYER cPlayer);
    void setHP(float fHp);
    float getHp();
    void setDifficultyHp(float fDifficultyHp);
    void setEnemyWave(C_ENEMYWAVE cEnemyWave);

}
