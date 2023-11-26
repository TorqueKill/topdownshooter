using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //get text component

    public Text Kills;
    public int kills = 0;

    // Start is called before the first frame update
    void Start()
    {
        //first find the text component
        Kills = GameObject.Find("Kills").GetComponent<Text>();

        if (Kills == null)
        {
            Debug.Log("Could not find Kills text component");
        }else{

            //set text to 0
            Kills.text = "Kills: " + kills.ToString();

        }
    }

    void Update()
    {
        if (Kills != null)
        {
            //set text to 0
            Kills.text = "Kills: " + kills.ToString();

        }
    }
}
