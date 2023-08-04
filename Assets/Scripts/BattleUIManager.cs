using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public Text playerLevelText;
    public Text enemyLevelText;
    public Text playerHealthText;
    public Text playerAttackText;

    private void Start()
    {
        UpdatePlayerLevel(1);
        UpdateEnemyLevel(1);
        UpdatePlayerHealth(100);
    }

    // 플레이어 레벨 텍스트 업데이트
    public void UpdatePlayerLevel(int level)
    {
        playerLevelText.text = "" + level;
    }

    // 적 레벨 텍스트 업데이트
    public void UpdateEnemyLevel(int level)
    {
        enemyLevelText.text = "" + level;
    }

    // 플레이어 체력 텍스트 업데이트
    public void UpdatePlayerHealth(int health)
    {
        playerHealthText.text = "" + health;
    }

}
