using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour
{
    public int level = 1;
    public string enemyName = "Enemy";

    public UnityEvent<EnemyInfoEventArgs> OnEnemyLevelChanged; // 적 레벨이 변경될 때 호출될 이벤트

    private void Start()
    {
        // 적 레벨 초기화 이벤트 발생
        if (OnEnemyLevelChanged != null)
        {
            OnEnemyLevelChanged.Invoke(new EnemyInfoEventArgs(this));
        }
    }

    // 적 레벨 설정 메서드
    public void SetLevel(int newLevel)
    {
        level = newLevel;

        // 적 레벨 변경 이벤트 발생
        if (OnEnemyLevelChanged != null)
        {
            OnEnemyLevelChanged.Invoke(new EnemyInfoEventArgs(this));
        }
    }

    // 적 이름 반환
    public string GetEnemyName()
    {
        return enemyName;
    }
}