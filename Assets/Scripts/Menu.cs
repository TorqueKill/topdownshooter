using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;


    // Start is called before the first frame update
    void Start()
    {
        //find 'start' button component
        startButton = GameObject.Find("Start").GetComponent<Button>();
        //add listener to button
        startButton.onClick.AddListener(StartGame);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        //load scene
        SceneManager.LoadScene("SampleScene");
    }
}
