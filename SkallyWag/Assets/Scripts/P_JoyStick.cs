using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_JoyStick : MonoBehaviour
{
    public Transform player;

    public float speed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }


    void moveCharacter(Vector2 direction)
    {
        player.transform.Translate(direction * speed * Time.deltaTime);
    }

}
