using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Image healthBar;
    public float health;
    public float startHealth;

    public void onTakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
    }

  
}
