using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (touchEventManager.IsTouching())
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

        // ���콺 Ŭ�� ��ġ �Ǵ� ù ��° ��ġ ��ġ ��������
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

        // �÷��̾��� ���� ��ġ�� �̵��� ��ġ ���
        Vector3 currentPosition = transform.position;
        Vector3 movePosition = Camera.main.ScreenToWorldPoint(targetPosition + new Vector3(0, 0, 10f));

        // �̵� ����� �Ÿ� ���
        Vector3 direction = (movePosition - currentPosition).normalized;
        float distance = Vector3.Distance(movePosition, currentPosition);

        // Rigidbody2D�� ����Ͽ� ������ ����
        rb.velocity = direction * moveSpeed * distance;
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
    }
}