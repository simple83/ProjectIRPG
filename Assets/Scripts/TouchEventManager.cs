using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchEventManager : MonoBehaviour
{
    // 터치 시작 시 이벤트를 처리할 델리게이트 선언
    public delegate void TouchStartEvent(Vector2 touchPosition);

    // 터치 종료 시 이벤트를 처리할 델리게이트 선언
    public delegate void TouchEndEvent();

    // 실제 이벤트 인스턴스 생성
    public static event TouchStartEvent OnTouchStart;
    public static event TouchEndEvent OnTouchEnd;

    private bool isTouching = false;

    private void Update()
    {
#if UNITY_EDITOR
        // 유니티 에디터에서만 마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) 
            {
                Vector2 touchPosition = Input.mousePosition;
                OnTouchStart?.Invoke(touchPosition);
                isTouching = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnTouchEnd?.Invoke();
            isTouching = false;
        }
#endif

        // 터치가 발생한 경우
        if (Input.touchCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Touch touch = Input.GetTouch(0); // 첫 번째 터치에 대한 정보 가져오기

                if (touch.phase == TouchPhase.Began) // 터치가 시작된 경우
                {
                    Vector2 touchPosition = touch.position;
                    OnTouchStart?.Invoke(touchPosition);
                    isTouching = true;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) // 터치가 종료된 경우
                {
                    OnTouchEnd?.Invoke();
                    isTouching = false;
                }
            }
        }
    }

    public bool IsTouching()
    {
        return isTouching;
    }
}