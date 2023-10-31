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
        //set text to 0
        Kills.text = "Kills: " + kills.ToString();
    }

    void Update()
    {
        //update text
        Kills.text = "Kills: " + kills.ToString();
    }
}
