using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunn : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    //choose shooting button
    public KeyCode shootButton = KeyCode.Space;

    void Update()
    {
        if(Input.GetKeyDown(shootButton))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

}
