using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject cursorObject;
    private cursorScript cursor;

    public float speed = 1;
    public float maxSpeed = 1;
    public float jumpPower = 1;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cursor = cursorObject.GetComponent<cursorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculates distance moved
        Vector2 cursorMovement = cursor.finalPosition - cursor.originPos;

        //checks if cursor has moved
        if(cursorMovement.x == 0)
        {
            //gradually slows because sudden stop looks bad
            rb.velocity = new Vector2(rb.velocity.x * 0.99f * Time.deltaTime, rb.velocity.y);
            return;
        }

        //works out what direction to move the player

        //calculates movement speed
        float tSpeed = cursorMovement.x * speed;

        //limits movement speed
        if(tSpeed > maxSpeed && tSpeed > 0){tSpeed = maxSpeed;}
        if(tSpeed > maxSpeed && tSpeed < 0){tSpeed = -maxSpeed;}

        //moves it at that speed
        rb.velocity = new Vector2(tSpeed, rb.velocity.y);

        //flips sprite to face correct direction
        if(rb.velocity.x > 0){ flip(1);}
        if(rb.velocity.x < 0){ flip(0);}
    }

    public void Jump()
    {
        if(rb.velocity.y != 0){return;}
        rb.AddForce(transform.up * jumpPower);
    }

    void flip(int direction)
    {
        //left
        if(direction == 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //right
        if(direction == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
