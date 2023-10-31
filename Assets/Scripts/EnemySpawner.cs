using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    
    public int spawnRate = 1; // 1 enemy per second
    public int maxEnemies = 10;
    public int currentEnemies = 0;


    private bool spawnedEnemy = false;




    

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        if (currentEnemies < maxEnemies){
            if (!spawnedEnemy){
                SpawnEnemy();
            }
        }
        

    
    }

    void SpawnEnemy(){
        //spawn enemy
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        currentEnemies++;
        OnEnable();
        spawnedEnemy = true;
        //Debug.Log("Spawned Enemy");
    }

    IEnumerator SpawnEnemyRoutine(){
        yield return new WaitForSeconds(spawnRate);
        spawnedEnemy = false;
    }

    void OnEnable(){
        StartCoroutine(SpawnEnemyRoutine());
    }


}
