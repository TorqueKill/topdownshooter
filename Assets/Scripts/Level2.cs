using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//scenes
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{

    private Text levelText;

    // Start is called before the first frame update
    void Start()
    {


        //set level text
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        levelText.text = "Level 2";
        
    }

}
