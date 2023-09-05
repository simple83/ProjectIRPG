using NUnit.Framework.Interfaces;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject battleUIPrefab;
    private GameObject battleUIInstance;

    private static BattleManager instance;
    public static BattleManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForShortTime(float time)
    {
        Debug.Log("대기 시작");
        yield return new WaitForSeconds(time); // 2초 동안 대기
        Debug.Log("대기 종료");
    }

    public int StartBattle(GameObject enemy)
    {
        long enemyHp = 1, enemyAtk = 0, enemyDef = 0, enemyLevel = 1;
        long playerBaseHp = 1, playerCurrentHp = 1, playerAtk = 1, playerDef = 1, playerLuk = 1;
        //적 정보 받아오기
        long[] enemyData = GetEnemyData(enemy);
        if (enemyData != null)
        {
            enemyHp = enemyData[0];
            enemyAtk = enemyData[1];
            enemyLevel = enemyData[2];
        }
        else
        {
            Debug.Log("적 정보를 받아오는데 실패했습니다.");
            return 0;
        }
        string name = GetEnemyName(enemy);
        Sprite enemyimage = GetEnemySprite(enemy);
        // BattleUI 프리팹 로드 및 적용
        LoadBattleUI(name, enemyHp, enemyAtk, enemyLevel, enemyimage);
        BattleUI battleUI = battleUIInstance.GetComponent<BattleUI>();
        //플레이어 현재 스텟정보 받아오기
        long[] playerData = GetPlayerData();
        if (playerData != null)
        {
            playerBaseHp = playerData[0];
            playerCurrentHp = playerData[0];
            playerAtk = playerData[1];
            playerDef = playerData[2];
            playerLuk = playerData[3];
        }
        else
        {
            Debug.Log("플레이어 정보를 받아오는데 실패했습니다.");
            return 0;
        }

        //이제 진짜 전투 시작!
        //클릭하면시작하게 기다리고싶음
        while (true)
        {
            //플레이어 선공
            bool isBattleEnd = (Attack(CalculateDamage(playerAtk, enemyDef), ref enemyHp) == 0); //return값이 0이면 배틀종료
            battleUI.UpdateEnemyHpText(enemyHp);
            Debug.Log("적 HP");
            Debug.Log(enemyHp);
            StartCoroutine(WaitForShortTime(0.8f));
            if (isBattleEnd)
            {
                break;
            }
            else { }
            isBattleEnd = (Attack(CalculateDamage(enemyAtk, enemyDef), ref playerCurrentHp) != 0);
            battleUI.UpdatePlayerHpText(playerBaseHp, playerCurrentHp);
            StartCoroutine(WaitForShortTime(0.8f));
            if (isBattleEnd)
            {
                break;
            }
            else { }
        }
        return 0;
    }
    public long[] GetEnemyData(GameObject enemy)
    {
        //전투 할 적 정보 받아오기
        Debug.Log("전투 시작!");
        EnemyData enemyData = enemy.GetComponent<EnemyData>();

        if (enemyData != null)
        {
            long hp = enemyData.GetHp();
            long atk = enemyData.GetAtk();
            long level = enemyData.Getlevel();
            long[] returnarray = new long[3];
            returnarray[0] = hp;
            returnarray[1] = atk;
            returnarray[2] = level;
            return returnarray;
        }
        else
        {
            Debug.Log("컴포넌트를 찾을 수 없습니다.");
            return null;
        }
    }
    public string GetEnemyName(GameObject enemy) 
    {
        EnemyData enemyData = enemy.GetComponent<EnemyData>();
        if (enemyData != null)
        {
            string name = enemyData.GetName();
            return name;
        }
        else
        {
            Debug.Log("컴포넌트를 찾을 수 없습니다.");
            return null;
        }
    }
    public Sprite GetEnemySprite(GameObject enemy) 
    {
        Sprite enemyimage = null;


        SpriteRenderer spriteRenderer = enemy.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            enemyimage = spriteRenderer.sprite;
            return enemyimage;
        }
        else
        {
            Debug.Log("SpriteRenderer 컴포넌트를 찾을 수 없습니다.");
            return null;
        }
    }
    public long[] GetPlayerData()
    {
        long playerhp = PlayerStatus.Instance.baseHp;
        long playeratk = PlayerStatus.Instance.baseAtk;
        long playerdef = PlayerStatus.Instance.baseDef;
        long playerluk = PlayerStatus.Instance.baseLuk;

        long[] returnarray = { playerhp, playeratk, playerdef, playerluk };
        return returnarray;
    }
    public void LoadBattleUI(string name, long hp, long atk, long level, Sprite enemyimage)
    {
        // BattleUI 프리팹 로드 및 적용
        if (battleUIInstance == null)
        {
            battleUIInstance = Instantiate(battleUIPrefab);
        }

        BattleUI battleUI = battleUIInstance.GetComponent<BattleUI>();
        if (battleUI != null)
        {
            battleUI.ShowUI(name, level, hp, atk, enemyimage);
        }
        else
        {
            Debug.Log("BattleUI 컴포넌트를 찾을 수 없습니다.");
        }
    }
    
    public long CalculateDamage(long attakerAtk, long victimDef)
    {
        //방어력 효율 계산식 구현필요
        return attakerAtk;
    }
    public long Attack(long Damage, ref long victimHp)
    {
        if(victimHp - Damage <= 0)
        {
            return 0;
        }
        else
        {
            return (victimHp - Damage);
        }
    }
}
