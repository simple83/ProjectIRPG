using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerStatus : MonoBehaviour
{
    private static PlayerStatus instance;

    public static PlayerStatus Instance
    {
        get { return instance; }
    }

    public long currentLevel = 1;
    public long currentExp = 0;
    public long currentStatusPoint = 0;
    public int[] expToNextLevel;

    public long baseHp = 100;
    public long baseAtk = 10;
    public long baseDef = 10;
    public long baseLuk = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 이 오브젝트를 다른 씬에서도 유지
        }
        else
        {
            Destroy(gameObject); // 중복 제거
        }
    }

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

    public long GetBaseHp()
    {
        return baseHp;
    }

    public long GetBaseAtk()
    {
        return baseAtk;
    }

    public long GetBaseDef()
    {
        return baseDef;
    }

    public long GetBaseLuk()
    {
        return baseLuk;
    }
}

