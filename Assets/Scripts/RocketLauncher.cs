using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour
{
    public Transform rocketSpawnPoint;
    public GameObject rocketPrefab;
    public float bulletSpeed = 10;
    public float shootRate = 0.2f;

    public int level2Kills = 10;
    public int level3Kills = 20;

    public float textLife = 1f;

    public Text text;



    public KeyCode shootButton = KeyCode.Space;
    public KeyCode shootButton2 = KeyCode.Mouse0;

    private float shootDelta;
    private float shootInterval;

    private float textDelta;

    private bool upgrade1 = false;
    private bool upgrade2 = false;

    public AudioSource audioName;


    void Start()
    {
        shootInterval = 1f / shootRate;
        shootDelta = shootInterval;

        text.text = "";
    }

    void Update()
    {

        Upgrade();

        displayText();

        if (shootDelta < shootInterval)
        {
            shootDelta += Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(shootButton) || Input.GetKey(shootButton2))
            {
                Shoot1();
            }
            shootDelta = 0;
        }
    }

    void Shoot1()
    {   
        //rotate rocket 90 degrees in direction of rocketSpawnPoint
        var rocket = Instantiate(rocketPrefab, rocketSpawnPoint.position, rocketSpawnPoint.rotation * Quaternion.Euler(90, 0, 0));
        rocket.GetComponent<Rigidbody>().velocity = rocketSpawnPoint.forward * bulletSpeed;


        PlayAudio();
    }

    public void PlayAudio()
    {
        if (audioName != null)
        {
            audioName.Play();
        }
    }


    void Upgrade(){
        if (!upgrade1){
            if (GameObject.Find("Player").GetComponent<PlayerStats>().kills > level2Kills)
            {
                //increase shoot rate
                shootRate += 0.2f;
                shootInterval = 1f / shootRate;
                upgrade1 = true;
                text.text = "Rocket Upgraded: Increased fire rate";
                textDelta = 0;
            }
        }
        else if (!upgrade2){
            if (GameObject.Find("Player").GetComponent<PlayerStats>().kills > level3Kills)
            {
                //increase shoot rate
                shootRate += 0.2f;
                shootInterval = 1f / shootRate;
                upgrade2 = true;
                text.text = "Rocket Upgraded: Increased fire rate";
                textDelta = 0;
            }
        }
    }

    void displayText(){

        if (textDelta < textLife)
        {
            textDelta += Time.deltaTime;
        }
        else
        {
            text.text = "";
            textDelta = 0;
        }

        
    }
}
