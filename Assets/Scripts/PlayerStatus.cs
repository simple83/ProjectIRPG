using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerStatus : MonoBehaviour
{
    public long currentLevel = 1;
    public long currentExp = 0;
    public long currentStatusPoint = 0;
    public int[] expToNextLevel;

    public long baseHP = 100;
    public long baseATK = 10;
    public long baseDEF = 10;
    public long baseLUK = 1;

    private void LevelUp()
    {
        currentExp -= expToNextLevel[currentLevel];
        currentLevel++;
    }

    public void GainExp(int expAmount)
    {
        currentExp += expAmount;
        // 레벨업 체크
        while (currentExp >= expToNextLevel[currentLevel])
        {
            LevelUp();
        }
    }

    public long GetCurrentLevel()
    {
        return currentLevel;
    }
    public long GetBaseHP()
    {
        return baseHP;
    }

    public long GetBaseATK()
    {
        return baseATK;
    }
    public long GetBaseDEF()
    {
        return baseDEF;
    }
    public long GetBaseLUK()
    {
        return baseLUK;
    }
}
