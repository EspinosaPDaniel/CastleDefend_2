using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    public int maxHealth;
    public float currentHealth;
    public Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Alive();
        if(currentHealth<=0){
            Destroy(gameObject);
            SceneManager.LoadScene("CArga");
            
        }
    }

    public void Alive ()
    {
        
            healthBar.fillAmount = currentHealth / maxHealth;
    }
}






