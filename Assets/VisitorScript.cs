using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorScript : MonoBehaviour
{
    public string action;
    public float moveSpeed = 10;
    public float deadZone=-100;
    public float prayZone=-20; //this could be changed later to the hit box location of the tokens
    public PeopleSpawnerScript VisitorSpawner;

    // Start is called before the first frame update
    void Start()
    {
        action = "going";
        VisitorSpawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<PeopleSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (action.Equals("going")) Moving(false);
        if (action.Equals("leaving")) Moving(true);
        //if (action.Equals("praying"))
        // play animation of prayer, display dialogue (from random selection)
    }

    void Moving(bool leaving)
    {
        if (leaving)
        {
            transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
            if (transform.position.y < deadZone)
            {
                VisitorSpawner.shouldSpawn = true;
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
            if (transform.position.y > prayZone)
            {
                action="praying";
            }
        }
        //delta time to have the postion change based on time not frame rate
        
    }


}


