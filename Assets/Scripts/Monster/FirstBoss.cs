using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour,IEnemy
{
    EnemyClass enemy = new EnemyClass(10,10,100,"거대 슬라임");

    public long GetHp()
    {
        return enemy.GetHp();
    }
    public long GetAtk()
    {
        return enemy.GetAtk();
    }
    public long Getlevel()
    {
        return enemy.Getlevel();
    }
    public string GetName()
    {
        return enemy.GetName();
    }
}
