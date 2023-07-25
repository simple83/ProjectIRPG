using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // 이벤트를 정의할 델리게이트 선언
    public delegate void CollisionEvent(GameObject other);

    // 실제 이벤트 인스턴스 생성
    public static event CollisionEvent OnCollisionOccurred;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌이 발생한 상대 오브젝트를 이벤트로 전달
        OnCollisionOccurred?.Invoke(other.gameObject);
    }
}