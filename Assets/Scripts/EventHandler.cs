using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private BattleScreen battleScreen;

    private void OnEnable()
    {
        // CollisionHandler Ŭ������ �̺�Ʈ �ڵ鷯 ���
        CollisionHandler.OnCollisionOccurred += HandleCollision;
    }

    private void OnDisable()
    {
        // CollisionHandler Ŭ������ �̺�Ʈ �ڵ鷯 ��� ���� (�޸� ���� ����)
        CollisionHandler.OnCollisionOccurred -= HandleCollision;
    }

    // �̺�Ʈ �ڵ鷯
    private void HandleCollision(GameObject other)
    {
        // ���Ϳ� �浹���� �� ���� ȭ������ ��ȯ
        if (other.CompareTag("Monster"))
        {
            battleScreen.StartBattle(other);
        }
    }
}
