using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float healthRegen = 0f;

    public Image healthBar;

    private void Update()
    {
        if (health <= 0)
        {
            if (healthBar != null){
                healthBar.fillAmount = health / maxHealth;
            }
            Destroy(gameObject);
        }else {
            if (healthBar != null){
                healthBar.fillAmount = health / maxHealth;
            }
        }
    }
}
