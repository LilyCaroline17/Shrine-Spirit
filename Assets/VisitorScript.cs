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
    public bool triggered = false;

    public GameObject[] visitors;
    public GameObject currentVisitor;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        action = "going";
        VisitorSpawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<PeopleSpawnerScript>();
        backgroundAnimator = GameObject.FindGameObjectWithTag("Animator");
        

        int index = Random.Range(0, visitors.Length);
        Debug.Log(index);
        currentVisitor = Instantiate(visitors[index], transform.position, transform.rotation);

        currentVisitor.transform.SetParent(transform);
        animator = currentVisitor.GetComponent<Animator>();
        trigger = currentVisitor.GetComponent<DialogueTrigger>();
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
            trigger.TriggerDialogue();
        }
        // play animation of prayer, display dialogue (from random selection)
    }

    void Moving(bool leaving)
    {
        if (leaving)
        {
            transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

            //nextSentence = GetComponent<DialogueManager>();
            //nextSentence = GameObject.FindGameObjectWithTag("Dialogue");
            //nextSentence.GetComponent<DialogueManager>().DisplayNextSentence();
            if (!triggered)
            {
                print(recievedToken.name.Substring(0, 10));
                if (recievedToken.name.Substring(0, 10).Equals(trigger.wanted)) trigger.mangager.sentences.Enqueue("Oh thank you for the gift!");
                else trigger.mangager.sentences.Enqueue("Oh thanks ... ");
                trigger.NextSentence();
                triggered = true;
            }
            if(transform.position.y < -40)
            {
                trigger.NextSentence();
            }


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


