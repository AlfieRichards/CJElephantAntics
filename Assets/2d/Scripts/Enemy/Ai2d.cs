using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai2d : MonoBehaviour
{
 public Transform thePlayer;

    public float agroRange;

    public float moveSpeed;

    Rigidbody2D rb;
    public Animator anim;

    public int damage;

    bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance between the player
        float distToPlayer = Vector2.Distance(transform.position, thePlayer.position);
        //Debug.Log("Distbeteenplayer:" + distToPlayer);

        if(distToPlayer < agroRange)
        {
            chasePlayer();
        }
        else
        {
            if(!moving){RandomMove();}
            //else{anim.SetBool("isRunning", false);}
        }

        //flips sprite to face correct direction
        if(rb.velocity.x > 0){ flip(1);}
        if(rb.velocity.x < 0){ flip(0);}
    }

    private void chasePlayer()
    {
        if(transform.position.x < thePlayer.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        //anim.SetBool("isRunning", true);
    }

    void RandomMove()
    {
        moving = true;
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(Random.Range(-moveSpeed * 2, moveSpeed * 2), rb.velocity.y);
        Invoke("ResetMove", 1f);
    }

    void ResetMove()
    {
        moving = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage);
            Debug.Log("Touched Player");
        }
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage);
            Debug.Log("Touching Player");
        }
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
