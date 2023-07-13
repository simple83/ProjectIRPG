using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
    }
    void Move() {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 curpos = this.gameObject.transform.position;
        Vector3 movePosition = Camera.main.ScreenToWorldPoint(mousePosition + new Vector3(0, 0, 10f));

        transform.position += (movePosition-curpos) * moveSpeed * Time.deltaTime * 2;
    }
}
