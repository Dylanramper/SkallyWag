using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Drag : MonoBehaviour
{
    private Vector3 touchPos;
    public Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToViewportPoint(touch.position);
            touchPos.z = 0;
            direction = (touchPos - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if(touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
            
        }
    }
}
