using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject gameplayObject; 

    public void StartGameplay()
    {
        gameplayObject.SetActive(true); 
    }
}

