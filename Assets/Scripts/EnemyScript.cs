using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    
    public float speed = 20.0f;
    private float randSpeed;
    private Vector2 target;
    private Vector2 position;
    public bool isClicked = false;
  

    void Start()
    {
        randSpeed = Random.Range(speed-10, speed+10);
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    void OnMouseDown()
    {

        isClicked = true;
        //Destroy(gameObject);
        //Instantiate(gameObject, spawnPos, transform.rotation);
        
    }

    void Update()
    {
        int randNum = Random.Range(1, 5);
        Vector2 spawnPos = transform.position;
        if (randNum == 1) { spawnPos = new Vector2(-125, Random.Range(-100, 80)); }
        if (randNum == 2) { spawnPos = new Vector2(Random.Range(-120, 115), -100); }
        if (randNum == 3) { spawnPos = new Vector2(115, Random.Range(-100, 80)); }
        if (randNum == 4) { spawnPos = new Vector2(Random.Range(80, 115), 80); }

        float step = randSpeed * Time.deltaTime;
        if (isClicked)
        {
            randSpeed = Random.Range(speed - 10, speed + 10);
            transform.position = Vector2.MoveTowards(spawnPos, target, step);
            isClicked = false;
        }
         // move sprite towards the target location
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
       


    }



    


}


