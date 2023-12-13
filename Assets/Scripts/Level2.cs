using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//scenes
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{




    public int enemyKillRequirement = 40;

    private GameObject player;

    private Text levelText;

    private Text ObjectiveText1;
    private Text ObjectiveText2;

    private int totalEnemies;
    private int totalObjectives;

    private int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {

        //set player
        player = GameObject.Find("Player");



        //set level text
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        levelText.text = "Level 2";


        //set objective text
        ObjectiveText1 = GameObject.Find("ObjectiveText1").GetComponent<Text>(); 
        ObjectiveText2 = GameObject.Find("ObjectiveText2").GetComponent<Text>();

        if (player != null)
        {
            //get enemies killed
            enemiesKilled = player.GetComponent<PlayerStats>().kills;

            ObjectiveText1.text = "Kill " + enemyKillRequirement + " enemies";
        }


        //find total objectives
        findTotalObjectives();


        ObjectiveText2.text = "Find " + totalObjectives + " objectives";    
        
    }

    // Update is called once per frame
    void Update()
    {   

        if (player == null)
        {
            levelText.text = "You Died";
            return;
        }



        findTotalObjectives();
        
        findKills();

        levelComplete();

        setText();
        
    }


    void findTotalObjectives()
    {
        //find total objectives
        GameObject[] objectives = GameObject.FindGameObjectsWithTag("Objective");

        if (objectives == null)
        {   
            totalObjectives = 0;
            return;
        }
        totalObjectives = objectives.Length;
    }

    void findKills()
    {
        if (player == null)
        {
            return;
        }

        enemiesKilled = player.GetComponent<PlayerStats>().kills;
    }

    void levelComplete()
    {
       if (player == null)
        {
            return;
        }

        if ((enemiesKilled >= enemyKillRequirement) && (totalObjectives == 0))
        {
            levelText.text = "Level 2 Complete";
        }
    }


    void setText()
    {
        if (enemiesKilled < enemyKillRequirement)
        {
            ObjectiveText1.text = "Kill " + (enemyKillRequirement - enemiesKilled) + " enemies";
        }
        else
        {
            ObjectiveText1.text = "Kill " + 0 + " enemies";
        }


        ObjectiveText2.text = "Find " + totalObjectives + " objectives";
    }


}

