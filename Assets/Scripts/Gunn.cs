using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Gunn : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float shootRate = 1f;

    public int level2Kills = 10;
    public int level3Kills = 20;

    public float spreadAngle = 45f;

    public KeyCode shootButton = KeyCode.Space;
    public KeyCode shootButton2 = KeyCode.Mouse0;

    private float shootDelta;
    private float shootInterval;

    private float textLife = 1f;

    private bool upgrade1 = false;
    private bool upgrade2 = false;

    private float textDelta;

    public Text text;
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
                if (upgrade2)
                {
                    Shoot3();
                }
                else if (upgrade1)
                {
                    Shoot2();
                }
                else
                {
                    Shoot1();
                }
            }
            shootDelta = 0;
        }
    }

    void Shoot1()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        PlayAudio();

    }

    void Shoot2()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        
        var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, spreadAngle, 0) * bulletSpawnPoint.rotation);
        bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * bulletSpeed;

        var bullet3 = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, -spreadAngle, 0) * bulletSpawnPoint.rotation);
        bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * bulletSpeed;

        PlayAudio();
    }

    void Shoot3()
    {
        Shoot2(); // Call Shoot2 to create 2 bullets at 45 degrees.


        var bullet4 = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, spreadAngle * 2, 0) * bulletSpawnPoint.rotation);
        bullet4.GetComponent<Rigidbody>().velocity = bullet4.transform.forward * bulletSpeed;

        var bullet5 = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, -spreadAngle * 2, 0) * bulletSpawnPoint.rotation);
        bullet5.GetComponent<Rigidbody>().velocity = bullet5.transform.forward * bulletSpeed;

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
            if (GameObject.Find("Player").GetComponent<PlayerStats>().kills > level2Kills){
                upgrade1 = true;
                text.text = "Gun Upgraded: extra bullets";
                textDelta = 0;
            }
        }
        else if (!upgrade2){
            if (GameObject.Find("Player").GetComponent<PlayerStats>().kills > level3Kills){
                upgrade2 = true;
                text.text = "Gun Upgraded: extra bullets";
                textDelta = 0;
            }
        }     

    }

    void displayText()
    {
        if (textDelta < textLife)
        {
            textDelta += Time.deltaTime;
        }
        else
        {
            text.text = "";
        }
    }
}
