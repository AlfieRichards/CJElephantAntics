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


    Animator anim;
    bool falling, jumping, walking, idle;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
        rb = GetComponent<Rigidbody2D>();
        cursor = cursorObject.GetComponent<cursorScript>();
        anim = gameObject.GetComponent<Animator>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        //does anims
        SetAnims();
        AnimHandler();
        
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
        if(rb.velocity.x > 0.5){ flip(1);}
        if(rb.velocity.x < -0.5){ flip(0);}
    }

    public void Jump()
    {
        if(rb.velocity.y != 0){return;}
        rb.AddForce(transform.up * jumpPower);
    }


    void SetAnims()
    {
        //Debug.Log(rb.velocity.x);
        //Debug.Log(rb.velocity.y);
        if(rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            ResetAnims();
            //Debug.Log("idle");
            idle = true;
            return;
        }

        if(rb.velocity.x != 0 && !jumping)
        {
            ResetAnims();
            //Debug.Log("walking");
            walking = true;
            return;
        }

        if(rb.velocity.y > 0)
        {
            ResetAnims();
            //Debug.Log("jumping");
            jumping = true;
            return;
        }

        if(rb.velocity.y < 0)
        {
            ResetAnims();
            //Debug.Log("falling");
            falling = true;
            return;
        }
    }
    
    void AnimHandler()
    {
        if(idle){anim.SetBool("idle", true);}

        if(walking){anim.SetBool("walk", true);}

        if(jumping){anim.SetBool("jump", true);}

        if(falling){anim.SetBool("fall", true);}
    }

    void ResetAnims()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("fall", false);
        idle = false;
        walking = false;
        jumping = false;
        falling = false;
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
