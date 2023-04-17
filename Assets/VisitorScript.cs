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
    public GameObject recievedToken;
    public GameObject backgroundAnimator;
    public DialogueTrigger trigger;
    public GameObject nextSentence;

    public GameObject[] visitors;
    public GameObject currentVisitor;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        action = "going";
        VisitorSpawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<PeopleSpawnerScript>();
        backgroundAnimator = GameObject.FindGameObjectWithTag("Animator");
        

        int index = Random.Range(0, visitors.Length-1);
        currentVisitor = Instantiate(visitors[index], transform.position, transform.rotation);

        currentVisitor.transform.SetParent(transform);
        animator = currentVisitor.GetComponent<Animator>();
        trigger = GetComponent<DialogueTrigger>();
        trigger.TriggerDialogue(); //Dialogue should trigger as soon as visitor is created 
    }

    // Update is called once per frame
    void Update()
    {
        if (action.Equals("going")) Moving(false);
        if (action.Equals("leaving"))
        {
            animator.SetTrigger("WalkAway");
            Moving(true);
        }
        if (action.Equals("praying"))
        {
            animator.SetTrigger("Standing");
        }
        // play animation of prayer, display dialogue (from random selection)
    }

    void Moving(bool leaving)
    {
        if (leaving)
        {
            transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

            //nextSentence = GetComponent<DialogueManager>();
            nextSentence = GameObject.FindGameObjectWithTag("Dialogue");
            nextSentence.GetComponent<DialogueManager>().DisplayNextSentence();


            if (transform.position.y < deadZone)
            {
                VisitorSpawner.shouldSpawn = true;
                recievedToken.SetActive(true);
                //Instantiate(recievedToken, tokenloc, transform.rotation);


                backgroundAnimator.GetComponent<SceneLoaderScript>().numOfVisitors++;
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


