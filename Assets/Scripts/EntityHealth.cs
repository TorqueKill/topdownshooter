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


    private GameObject player;


    new public string tag;

    void Start()
    {
        tag = gameObject.transform.parent.gameObject.tag;

        //try to find health bar only if its a player
        if (tag == "Player"){
            healthBar = GameObject.Find("green").GetComponent<Image>();
        }

        //set player
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (health <= 0)
        {
            if (healthBar != null){
                healthBar.fillAmount = health / maxHealth;
            }
            //destroy parent object
            Destroy(gameObject.transform.parent.gameObject);
            //add kill to player
            //only add kill if enemy
            if (tag == "ENEMY"){
                if (player != null){
                    player.GetComponent<PlayerStats>().kills += 1;
                }
            }
        }else {
            if (healthBar != null){
                healthBar.fillAmount = health / maxHealth;
            }
        }
    }
}
