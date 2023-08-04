using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreen : MonoBehaviour
{
    public BattleUI battleUI;
    public void StartBattle(GameObject enemy)
    {
        Debug.Log("전투 시작!");
        IEnemy enemyDataComponent = enemy.GetComponent<IEnemy>();

        if (enemyDataComponent != null)
        {
            long hp = enemyDataComponent.GetHp();
            long atk = enemyDataComponent.GetAtk();
            long level = enemyDataComponent.Getlevel();
            string name = enemyDataComponent.GetName();
            Debug.Log(hp);
            Debug.Log(atk);
            Debug.Log(level);
            Debug.Log(name);
            battleUI.gameObject.SetActive(true);
            battleUI.ShowUI(name, level, hp, atk);
        }
        else
        {
            Debug.Log("컴포넌트를 찾을 수 없습니다.");
        }
    }
}