using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    
    public float speed = 40.0f;
    private float randSpeed;
    private float leaveSpeed;
    private Vector2 target;
    private Vector2 position;
    public bool isClicked;
    public bool reachedCenter;

    public int score = 0;
  

    void Start()
    {
        randSpeed = Random.Range(speed-10, speed+10);
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    void OnMouseDown()
    {

        isClicked = true;
        score++;
        //Destroy(gameObject);
        //Instantiate(gameObject, spawnPos, transform.rotation);
        
    }

    void Update()
    {
        int randNum = Random.Range(1, 5);
        Vector2 spawnPos = new Vector2(0.0f, 0.0f);
        if (randNum == 1) { spawnPos = new Vector2(-125, Random.Range(-100, 80)); }
        if (randNum == 2) { spawnPos = new Vector2(Random.Range(-120, 115), -100); }
        if (randNum == 3) { spawnPos = new Vector2(115, Random.Range(-100, 80)); }
        if (randNum == 4) { spawnPos = new Vector2(Random.Range(80, 115), 80); }

        float step = randSpeed * Time.deltaTime;

        if(transform.position.x == 0 && transform.position.y == 0)
        {
            isClicked = true;
            reachedCenter = true;
        }


        if (isClicked)
        {
            randSpeed = Random.Range(speed - 10, speed + 10);
            leaveSpeed = 50.0f * Time.deltaTime;
            if (reachedCenter) { leaveSpeed *= 4.0f; }

            transform.position = Vector2.MoveTowards(transform.position, position, leaveSpeed);
            
            if (transform.position.x > -125 && transform.position.x < 115 && transform.position.y > -100 && transform.position.y < 80)
            {
                isClicked = true;
                
            }
            else
            {
                isClicked = false;
                reachedCenter = false;
                transform.position = spawnPos;
                position = transform.position;
            }

        }
         // move sprite towards the target location
        else
        {
            if(isClicked == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, step);
            }
        }
       


    }



    


}


