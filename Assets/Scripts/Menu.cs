using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;

    public Button keyboardOnlySelect;


    // Start is called before the first frame update
    void Start()
    {
        //find 'start' button component
        startButton = GameObject.Find("Start").GetComponent<Button>();
        //add listener to button
        startButton.onClick.AddListener(StartGame);

        //find 'keyboard only' button component
        keyboardOnlySelect = GameObject.Find("keyboardOnly").GetComponent<Button>();
        //add listener to button
        keyboardOnlySelect.onClick.AddListener(KeyboardOnly);

        keyboardOnlySelect.GetComponentInChildren<Text>().text = StaticData.mouseKeyboardControl ? "KeyboardMouse" : "Keyboard Only";


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        //load scene
        SceneManager.LoadScene("Level1");
    }

    void KeyboardOnly()
    {
        //flip static bool 'mouseKeyboardControl' and flip state of button
        StaticData.mouseKeyboardControl = !StaticData.mouseKeyboardControl;
        keyboardOnlySelect.GetComponentInChildren<Text>().text = StaticData.mouseKeyboardControl ? "KeyboardMouse" : "Keyboard Only";
        
    }
}
