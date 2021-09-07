using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction : MonoBehaviour
{
    
    public Vector2 speed = new Vector2(1, 1);

    [Header("Randomize")]
    public Vector2 randSpeedY = new Vector2(1, 3);
    public Vector2 randSpeedX = new Vector2(1, 3);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Wall")
        {
            OnPlayerCollision();
        }
        else
        {
            speed.y *= -1;
        }


    }


    public void OnPlayerCollision()
    {

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if (speed.x < 0)
            rand = -rand;
        speed.x = -1 * rand;

        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        if (speed.y < 0)
            rand = -rand;
        speed.y = -1 * rand;

    }
}
