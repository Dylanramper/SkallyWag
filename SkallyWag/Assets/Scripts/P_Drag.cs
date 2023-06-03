using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Drag : MonoBehaviour
{
    private Vector3 dir;
    private Vector3 touchPos;
    float moveSpeed = .7f;

    public Buttons buttons;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && buttons.paused == false)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            dir = (touchPos - transform.position);
            transform.Translate(new Vector3(dir.x, dir.y, 0) * moveSpeed);
        }
    }
}
