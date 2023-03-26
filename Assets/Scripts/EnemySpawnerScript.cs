using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update

    void Start()
    {

        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(spawnEnemy());
        int i = 0;
        while(i < 6)
        { 
            spawnEnemy();
            i++;
        }  
          
    }



    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(1);

        int randNum = Random.Range(1, 5);
        Vector2 spawnPos = transform.position;
        if(randNum == 1) { spawnPos = new Vector2(-125, Random.Range(-100, 80)); }
        if(randNum == 2) { spawnPos = new Vector2(Random.Range(-120, 115), -100); }
        if(randNum == 3) { spawnPos = new Vector2(115, Random.Range(-100, 80)); }
        if(randNum == 4) { spawnPos = new Vector2(Random.Range(80, 115), 80); }
        Instantiate(enemyPrefab, spawnPos, transform.rotation);


    }

}