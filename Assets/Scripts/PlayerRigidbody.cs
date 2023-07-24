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

        if (Input.touchCount > 0) // ��ġ�� �߻��� ���
        {
            Debug.Log(Input.touchCount);
            Touch touch = Input.GetTouch(0); // ù ��° ��ġ�� ���� ���� ��������

            if (touch.phase == TouchPhase.Began) // ��ġ�� ���۵� ���
            {
                Move();
            }
            else if (touch.phase == TouchPhase.Ended) // ��ġ�� ����� ���
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
