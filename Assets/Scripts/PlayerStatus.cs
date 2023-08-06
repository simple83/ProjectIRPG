using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerStatus : MonoBehaviour
{
    //변수들은 GameManager에서 관리중

    private void LevelUp()
    {
        GameManager.instance.currentExp -= GameManager.instance.expToNextLevel[GameManager.instance.currentLevel];
        GameManager.instance.currentLevel++;
    }

    public void GainExp(int expAmount)
    {
        GameManager.instance.currentExp += expAmount;
        // 레벨업 체크
        while (GameManager.instance.currentExp >= GameManager.instance.expToNextLevel[GameManager.instance.currentLevel])
        {
            LevelUp();
        }
    }

    public long GetCurrentLevel()
    {
        return GameManager.instance.currentLevel;
    }
    public long GetBaseHP()
    {
        return GameManager.instance.baseHP;
    }

    public long GetBaseATK()
    {
        return GameManager.instance.baseATK;
    }
    public long GetBaseDEF()
    {
        return GameManager.instance.baseDEF;
    }
    public long GetBaseLUK()
    {
        return GameManager.instance.baseLUK;
    }
}
