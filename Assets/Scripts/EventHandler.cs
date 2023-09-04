using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{

    private void OnEnable()
    {
        // CollisionHandler 클래스의 이벤트 핸들러 등록
        CollisionHandler.OnCollisionOccurred += HandleCollision;
    }

    private void OnDisable()
    {
        // CollisionHandler 클래스의 이벤트 핸들러 등록 해제 (메모리 누수 방지)
        CollisionHandler.OnCollisionOccurred -= HandleCollision;
    }

    // 이벤트 핸들러
    private void HandleCollision(GameObject other)
    {
        // 몬스터와 충돌했을 때 전투 화면으로 전환
        if (other.CompareTag("Monster"))
        {
            BattleManager.Instance.StartBattle(other);
        }
    }
}
