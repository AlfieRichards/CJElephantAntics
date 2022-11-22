using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    public float speed = 1;
    public float maxSpeed = 1;
    public float jumpPower = 1;
    public float trackingRange = 1;

    private Rigidbody2D rb;

    Animator anim;
    bool walking, idle;

    GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        //bounces out if not in tracking range
        if(Vector3.Distance(player.transform.position, transform.position) > trackingRange){return;}

        
    }

    void FixedUpdate() 
    {
        Vector2 velocity = new Vector2(1.75f, 1.1f);
        rb.MovePosition(rb.position);
    }

    void SetAnims()
    {
        Debug.Log(rb.velocity.x);
        if(rb.velocity.x == 0)
        {
            ResetAnims();
            Debug.Log("idle");
            idle = true;
            return;
        }

        if(rb.velocity.x != 0)
        {
            ResetAnims();
            Debug.Log("walking");
            walking = true;
            return;
        }
    }

    void AnimHandler()
    {
        if(idle){anim.SetBool("idle", true);}

        if(walking){anim.SetBool("walk", true);}
    }

    void ResetAnims()
    {
        anim.SetBool("idle", false);
        anim.SetBool("walk", false);
        idle = false;
        walking = false;
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
