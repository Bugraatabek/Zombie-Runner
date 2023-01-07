using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText;
   
    public void PlayerTakeDamage(float damage)
    {
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0)  {GetComponent<DeathHandler>().HandleDeath();}    
    }

    private void Update()
    {
        float currentHealth = hitPoints;
        healthText.text = "Health:" + currentHealth.ToString();
    }
}
