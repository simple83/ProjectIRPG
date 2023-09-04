using System;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    public monsterInfo[] monsterInfos;
    public Sprite[] monsterSprties;
}

[Serializable]
public class monsterInfo
{
    public string index;
    public long hp;
    public long atk;

}
