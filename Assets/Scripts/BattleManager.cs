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

    long enemyHp = 1, enemyAtk = 0, enemyDef = 0, enemyLevel = 1;
    long playerBaseHp = 1, playerCurrentHp = 1, playerAtk = 1, playerDef = 1, playerLuk = 1;
    bool isfighting = false;
    bool canPlayerAttack = true;
    bool canEnemyAttack = false;

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

    private void Update()
    {
        if(isfighting)
        {
            BattleUI battleUI = battleUIInstance.GetComponent<BattleUI>();
            //플레이어 선공
            if (canPlayerAttack)
            {
                isfighting = !(Attack(CalculateDamage(playerAtk, enemyDef), ref enemyHp) == 0);
                Debug.Log("플레이어의 공격!");
                Debug.Log("적의 남은 체력 : " + enemyHp);
                
                battleUI.UpdateEnemyHpText(enemyHp);
                canPlayerAttack = false;
                StartCoroutine(PlayerTurnEnd());
            }

            if (canEnemyAttack)
            {
                isfighting = !(Attack(CalculateDamage(enemyAtk, enemyDef), ref playerCurrentHp) == 0);
                Debug.Log("적의 공격!");
                Debug.Log("플레이어의 남은 체력 : " + playerCurrentHp);
                battleUI.UpdatePlayerHpText(playerBaseHp, playerCurrentHp);
                canEnemyAttack = false;
                StartCoroutine(EnemyTurnEnd());
            }
        }
    }

    IEnumerator PlayerTurnEnd()
    {
        yield return new WaitForSeconds(0.8f);
        canEnemyAttack = true;
    }
    IEnumerator EnemyTurnEnd()
    {
        yield return new WaitForSeconds(0.8f);
        canPlayerAttack = true;
    }

    public int StartBattle(GameObject enemy)
    {
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
        // BattleUI 프리팹 로드 및 적용
        LoadBattleUI(name, enemyLevel, enemyHp, playerBaseHp, enemyimage);
        //이제 진짜 전투 시작!
        isfighting = true;
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
        victimHp -= Damage;
        if(victimHp <= 0)
        {
            victimHp = 0;
            return 0;
        }
        return (victimHp - Damage);
        
    }
}
