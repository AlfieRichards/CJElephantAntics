using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    public GameObject theEnemy;
    public float killDelay;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Invoke("Destroy", killDelay);
        }
    }
    private void Destroy()
    {
        theEnemy.SetActive(false);
    }
}
