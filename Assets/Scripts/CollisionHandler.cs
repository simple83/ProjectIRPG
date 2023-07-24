using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // �̺�Ʈ�� ������ ��������Ʈ ����
    public delegate void CollisionEvent(GameObject other);

    // ���� �̺�Ʈ �ν��Ͻ� ����
    public static event CollisionEvent OnCollisionOccurred;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� �߻��� ��� ������Ʈ�� �̺�Ʈ�� ����
        OnCollisionOccurred?.Invoke(other.gameObject);
    }
}