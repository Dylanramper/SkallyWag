using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_JoyStick : MonoBehaviour
{
    public P_Controls controls;
    public FixedJoystick moveJoystick;
    public float moveSpeed = 7.0f;

    // Update is called once per frame
    void Update()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector2 dir = new Vector2(hoz, ver).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
    }

}
