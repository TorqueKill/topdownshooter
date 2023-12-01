using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{

    public GameObject enemyPrefab;
    public int numberOfEnemies = 10;
    private MeshRenderer mRenderer;
    private float xmin = 0.0f;
    private float xmax = 5.0f;
    private float zmin = 0.0f;
    private float zmax = 5.0f;
    private float y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //get the mesh renderer
        mRenderer = GetComponent<MeshRenderer>();
        
        //get the bounds of the mesh for XZ Plane
        Bounds bounds = mRenderer.bounds;

        //get the min and max of the bounds
        xmin = bounds.min.x;
        xmax = bounds.max.x;
        zmin = bounds.min.z;
        zmax = bounds.max.z;
        y = bounds.max.y;

        //spawn enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            //get random position
            Vector3 randomPosition = new Vector3(Random.Range(xmin, xmax), y, Random.Range(zmin, zmax));

            //spawn enemy
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            //set the parent of the enemy to the spawner
            //enemy.transform.parent = transform;
        }


        //disable the mesh renderer
        mRenderer.enabled = false;

        
        
    }

}
