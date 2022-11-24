using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public int lives;

    public TextMeshProUGUI livesText;

    public GameObject thePlayer;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        livesText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && lives != 0)
        {
            lives--;
            livesText.text = lives.ToString();
            currentHealth = startingHealth;
        }
        if (currentHealth <= 0 && lives == 0)
        {
            thePlayer.SetActive(false);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
        healthBar.SetHealth(currentHealth);

    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
    }
}