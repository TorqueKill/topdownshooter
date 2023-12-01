using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//scenes
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{

    private GameObject player;

    private Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        //set player
        player = GameObject.Find("Player");

        //set level text
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        levelText.text = "Level 1";
        
    }

    // Update is called once per frame
    void Update()
    {
        //if player kills 40 enemies goto level 2
        if (player.GetComponent<PlayerStats>().kills >= 10){
            SceneManager.LoadScene("Level2");
        }
        
    }
}
