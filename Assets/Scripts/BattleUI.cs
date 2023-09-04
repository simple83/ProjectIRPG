using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyLevelText;
    public TextMeshProUGUI enemyHpText;
    public TextMeshProUGUI enemyAtkText;
    public Image enemySprite;


    public void ShowUI(string name, long level, long hp, long atk, Sprite image)
    {
        // UI 텍스트를 변경하여 적 정보를 표시합니다.
        enemyNameText.text = name;
        enemyLevelText.text = "" + level;
        enemySprite.sprite = image;
        gameObject.SetActive(true);

    }

    public void HideUI()
    {
        // BattleUI를 비활성화합니다.
        gameObject.SetActive(false);
    }
}

