using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public float timer = 1;
    public float radius = 1;
    public int damage = 1;

    private Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        
        GameObject player = GameObject.Find("Player");
        if(player.transform.localScale.x < 0)
        {
            rb.velocity = new Vector2(-3f, 5f);
        }
        else
        {
            rb.velocity = new Vector2(3f, 5f);
        }
    }

    float timePassed = 0f;
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > timer)
        {
            timePassed = -9999999;
            Detonate();
        }
    }

    void Detonate()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D collider in hitColliders)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
