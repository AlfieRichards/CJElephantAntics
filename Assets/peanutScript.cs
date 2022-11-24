using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peanutScript : MonoBehaviour
{
    public int damage = 6;
    public float speed = 1;
    GameObject player;
    Vector3 moveThing = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if(player.transform.localScale.x < 0)
        {
            moveThing.x = -5;
        }
        else
        {
            moveThing.x = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((moveThing * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);

        if(collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        
        if(collider.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }

    }
}
