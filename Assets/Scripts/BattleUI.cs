using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyLevelText;
    public TextMeshProUGUI enemyHpText;
    public TextMeshProUGUI enemyAtkText;
    public TextMeshProUGUI playerHpText;
    public Image enemySprite;


    public void ShowUI(string enemyName, long enemyLevel, long enemyHp, long playerBaseHp, Sprite image)
    {
        // UI 텍스트를 변경하여 적 정보를 표시합니다.
        enemyNameText.text = enemyName;
        enemyLevelText.text = "" + enemyLevel;
        enemyHpText.text = "" + enemyHp;
        playerHpText.text = ("" + (int)playerBaseHp) + "/" + ("" + (int)playerBaseHp);
        enemySprite.sprite = image;

        gameObject.SetActive(true);

    }

    public void DestroyBattleUI()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateEnemyHpText(long enemyHp)
    {
        enemyHpText.text = "" + (int)enemyHp;
    }
    public void UpdatePlayerHpText(long playerBaseHp, long playerCurrentHp)
    {

        playerHpText.text = ("" + (int)playerCurrentHp) +"/"+ ("" + (int)playerBaseHp);
    }
}

