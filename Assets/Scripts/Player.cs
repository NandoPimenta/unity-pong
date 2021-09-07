using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     
    [Header("Key control")]
    public KeyCode KeyMoveUp = KeyCode.W;
    public KeyCode KeyMoveDown = KeyCode.S;

    [Header("General Config")]
    public float speed = 20f;
    
    [HideInInspector] Rigidbody2D playerRigidbody2D;
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }


    void Controller()
    {
        if (Input.GetKey(KeyMoveUp))
        {
            playerRigidbody2D.MovePosition(transform.position + transform.up *  speed * Time.deltaTime );

        }
        else if (Input.GetKey(KeyMoveDown))
        {
            playerRigidbody2D.MovePosition(transform.position  + transform.up * -speed * Time.deltaTime);

        }
    }
}
