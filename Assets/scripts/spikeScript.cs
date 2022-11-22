using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
