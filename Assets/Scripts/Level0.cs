using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use ui
using UnityEngine.UI;

public class Level0 : MonoBehaviour
{
    public string startText = "Survive as long as you can! Or kill 200";

    public int killsToWin = 200;

    public float textLife = 5f;

    private float textDelta;

    public Text startTextUI;
    public Text endTextUI;


    private bool startTextCheck = true;

    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        textDelta = 0;
        //find the LevelText object
        startTextUI = GameObject.Find("levelText").GetComponent<Text>();
        //set the text
        startTextUI.text = startText;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (startTextCheck)
        {
            displayText(startTextUI);
        }
        else
        {
            player = GameObject.Find("Player");
            if (player == null)
            {
                endTextUI.text = "You Lose!";
            }
            else
            {
                if (player.GetComponent<PlayerStats>().kills >= killsToWin)
                {
                    endTextUI.text = "You Win!";
                }
            }
           
        }

        
    }

    void displayText(Text text){

        if (textDelta < textLife)
        {
            textDelta += Time.deltaTime;
        }
        else
        {
            text.text = "";
            textDelta = 0;
            startTextCheck = false;
        }

    
    }
}
