using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchEventManager : MonoBehaviour
{
    // ��ġ ���� �� �̺�Ʈ�� ó���� ��������Ʈ ����
    public delegate void TouchStartEvent(Vector2 touchPosition);

    // ��ġ ���� �� �̺�Ʈ�� ó���� ��������Ʈ ����
    public delegate void TouchEndEvent();

    // ���� �̺�Ʈ �ν��Ͻ� ����
    public static event TouchStartEvent OnTouchStart;
    public static event TouchEndEvent OnTouchEnd;

    private bool isTouching = false;

    private void Update()
    {
#if UNITY_EDITOR
        // ����Ƽ �����Ϳ����� ���콺 Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPosition = Input.mousePosition;
            OnTouchStart?.Invoke(touchPosition);
            isTouching = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnTouchEnd?.Invoke();
            isTouching = false;
        }
#endif

        // ��ġ�� �߻��� ���
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // ù ��° ��ġ�� ���� ���� ��������

            if (touch.phase == TouchPhase.Began) // ��ġ�� ���۵� ���
            {
                Vector2 touchPosition = touch.position;
                OnTouchStart?.Invoke(touchPosition);
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) // ��ġ�� ����� ���
            {
                OnTouchEnd?.Invoke();
                isTouching = false;
            }
        }
    }

    public bool IsTouching()
    {
        return isTouching;
    }
}