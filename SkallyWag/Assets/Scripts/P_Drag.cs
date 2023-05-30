using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Drag : MonoBehaviour
{
    private Vector3 dir;
    private Vector3 touchPos;
    float moveSpeed = .02f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            dir = (touchPos - transform.position);
            transform.Translate(new Vector3(dir.x, dir.y, 0) * moveSpeed);
        }
    }
}
