using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbody : MonoBehaviour
{
    public float moveSpeed = 1f;
    void Start()
    {

    }

    void Update()
    {

        if (Input.touchCount > 0) // 터치가 발생한 경우
        {
            Debug.Log(Input.touchCount);
            Touch touch = Input.GetTouch(0); // 첫 번째 터치에 대한 정보 가져오기

            if (touch.phase == TouchPhase.Began) // 터치가 시작된 경우
            {
                Move();
            }
            else if (touch.phase == TouchPhase.Ended) // 터치가 종료된 경우
            {
                Stop();
            }
            
        }
    }


        void Move()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 curpos = this.gameObject.transform.position;
        Vector3 movePosition = Camera.main.ScreenToWorldPoint(mousePosition + new Vector3(0, 0, 10f));

        GetComponent<Rigidbody2D>().velocity = (movePosition - curpos);
    }

    void Stop()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3();
    }
}
