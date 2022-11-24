using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerAttack : MonoBehaviour
{
    public GameObject bomb;
    public GameObject peanut;
    public TextMeshProUGUI bombsText;

    public int bombs = 9;

    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        bombsText.text = bombs.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowBomb()
    {
        if(bombs <= 0)
        {
            bombsText.text = bombs.ToString();
            return;
        }
        bombsText.text = bombs.ToString();
        Instantiate(bomb, firePoint.position, firePoint.rotation);
        bombs -= 1;
    }

    public void FirePeanut()
    {
        Instantiate(peanut, firePoint.position, firePoint.rotation);
    }
}
