using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public long GetHp();

    public long GetAtk();
    public long Getlevel();
    public string GetName();
}
