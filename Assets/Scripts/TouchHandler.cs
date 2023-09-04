using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandler : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private TouchEventManager touchEventManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        touchEventManager = GetComponent<TouchEventManager>();
    }

    private void Update()
    {
        if (touchEventManager.IsTouching() && !EventSystem.current.IsPointerOverGameObject())
        {
            Move();
        }
        else
        {
            Stop();
        }
    }

    void Move()
    {
        Vector3 targetPosition;

        // 마우스 클릭 위치 또는 첫 번째 터치 위치 가져오기
#if UNITY_EDITOR
        targetPosition = Input.mousePosition;
#else
        if (Input.touchCount > 0)
        {
            targetPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
#endif

        // 플레이어의 현재 위치와 이동할 위치 계산
        Vector3 currentPosition = transform.position;
        Vector3 movePosition = Camera.main.ScreenToWorldPoint(targetPosition + new Vector3(0, 0, 10f));

        // 이동 방향과 거리 계산
        Vector3 direction = (movePosition - currentPosition).normalized;
        float distance = Vector3.Distance(movePosition, currentPosition);

        // Rigidbody2D를 사용하여 움직임 적용
        rb.velocity = direction * moveSpeed * distance;
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }
}