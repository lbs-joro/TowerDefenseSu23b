using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float timer = 3f;

    public List<GameObject> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        
        if(timer < 0)
        {
            Vector2 spawnLocation = waypoints[0].transform.position; 
            GameObject enemyClone = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);

            // Här måste vi säga till nya fienden vilka waypoints den ska ha. 

            EnemyMovement enemyMovement = enemyClone.GetComponent<EnemyMovement>();
            enemyMovement.waypoints = waypoints;


            //Återställa timern

            timer = 3f;

        }
    }
}
