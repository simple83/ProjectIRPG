using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class EnemyData : MonoBehaviour
{

    [SerializeField] long hp;
    [SerializeField] long atk;
    [SerializeField] long level;
    [SerializeField] string enemyName;

    public long GetHp()
    {
        return hp;
    }
    public long GetAtk()
    {
        return atk;
    }
    public long Getlevel()
    {
        return level;
    }
    public string GetName()
    {
        return enemyName;
    }
}

