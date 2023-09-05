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


    public void ShowUI(string name, long level, long hp, long atk, Sprite image)
    {
        // UI 텍스트를 변경하여 적 정보를 표시합니다.
        enemyNameText.text = name;
        enemyLevelText.text = "" + level;
        enemyHpText.text = "" + hp;
        enemySprite.sprite = image;
        gameObject.SetActive(true);

    }

    public void HideUI()
    {
        // BattleUI를 비활성화합니다.
        gameObject.SetActive(false);
    }

    public void UpdateEnemyHpText(long enemyHp)
    {
        enemyHpText.text = "" + (int)enemyHp;
    }
    public void UpdatePlayerHpText(long playerBaseHp, long playerCurrentHp)
    {

        playerHpText.text = ("" + (int)playerBaseHp) +"/"+ ("" + (int)playerCurrentHp);
    }
}

